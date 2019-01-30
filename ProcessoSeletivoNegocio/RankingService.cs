using ProcessoSeletivoDataContext;
using ProcessoSeletivoDataContext.Interfaces;
using ProcessoSeletivoModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProcessoSeletivoDataService
{
    public class RankingService : IDisposable
    {
        private readonly IVagaDAL _instanciaVaga;
        private readonly IPessoaDAL _instanciaPessoa;
        private readonly ICandidaturaDAL _instanciaCandidatura;

        public RankingService()
        {
            _instanciaVaga = IoC<IVagaDAL>.ObterInstancia();
            _instanciaPessoa = IoC<IPessoaDAL>.ObterInstancia();
            _instanciaCandidatura = IoC<ICandidaturaDAL>.ObterInstancia();
        }

        public List<RankingModel> GetRanking(int IdVaga)
        {
            List<RankingModel> response = null;

            VagaModel vagaModel = _instanciaVaga.GetById(IdVaga);
            if (vagaModel == null)
            {
                throw new Exception("Vaga não existe.");
            }

            List<CandidaturaModel> listaCandidatura = _instanciaCandidatura
                .Query()
                .Where(w => w.IdVaga == IdVaga)
                .ToList();

            if (listaCandidatura == null || listaCandidatura.Any() == false)
            {
                throw new Exception("Não existem candidatos para essa vaga.");
            }

            List<int> listaIdPessoa = listaCandidatura
                .Select(s => s.IdPessoa)
                .ToList();


            response = _instanciaPessoa
                .Query()
                .Where(w => listaIdPessoa.Contains(w.Id))
                .OrderBy(o => o.Id)
                .Select(s => new RankingModel()
                {
                    Nome = s.Nome,
                    Profissao = s.Profissao,
                    Localizacao = s.Localizacao,
                    Nivel = s.Nivel,
                    Score = CalculaScoreCandidatura(vagaModel, s)
                })
            .ToList();

            if (response != null && response.Any())
            {
                response = response.OrderByDescending(o => o.Score).ToList();
            }

            return response;
        }

        private int CalculaScoreCandidatura(VagaModel vagaModel, PessoaModel pessoaModel)
        {
            List<int> listDistancias = new List<int>();

            int score = 0;
            if (vagaModel.Localizacao == pessoaModel.Localizacao)
            {
                listDistancias.Add(0);
            }
            else
            {
                List<DistanciaModel> listaDistanciaModel = null;

                using (var distanciaService = new DistanciaService())
                {
                    listaDistanciaModel = distanciaService.ListAll().ToList();
                }

                var listaDistanciaModelTemp = listaDistanciaModel.Where(w => w.LocalizacaoOrigem == pessoaModel.Localizacao || w.LocalizacaoDestino == pessoaModel.Localizacao).ToList();

                if (listaDistanciaModelTemp == null || listaDistanciaModelTemp.Any() == false)
                    return 0;

                foreach (var itemDistancia in listaDistanciaModelTemp)
                {
                    if (itemDistancia.LocalizacaoOrigem == pessoaModel.Localizacao)
                    {
                        if (itemDistancia.LocalizacaoDestino == vagaModel.Localizacao)
                        {
                            listDistancias.Add(itemDistancia.Distancia);
                        }
                        else
                        {
                            int novaDistancia = itemDistancia.Distancia;
                            listDistancias.Add(CalculaDistancia(ref listaDistanciaModel, new List<int>() { itemDistancia.Id }, itemDistancia.LocalizacaoDestino, vagaModel.Localizacao, ref novaDistancia));
                        }
                    }

                    if (itemDistancia.LocalizacaoDestino == pessoaModel.Localizacao)
                    {
                        if (itemDistancia.LocalizacaoOrigem == vagaModel.Localizacao)
                        {
                            listDistancias.Add(itemDistancia.Distancia);
                        }
                        else
                        {
                            int novaDistancia = itemDistancia.Distancia;
                            listDistancias.Add(CalculaDistancia(ref listaDistanciaModel, new List<int>() { itemDistancia.Id }, itemDistancia.LocalizacaoOrigem, vagaModel.Localizacao, ref novaDistancia));
                        }
                    }
                }
            }

            int Distancia = listDistancias.Min();
            int D = 0;
            if (Distancia >=0 && Distancia  <= 5)
            {
                D = 100;
            }
            else if (Distancia >5 && Distancia <= 10)
            {
                D = 75;
            }
            else if (Distancia > 10 && Distancia <= 15)
            {
                D = 50;
            }
            else if (Distancia > 15 && Distancia <= 20)
            {
                D = 25;
            }

            int N = 100 - 25 * (vagaModel.Nivel - pessoaModel.Nivel);

            score = (N + D) / 2;

            return score;
        }

        private int CalculaDistancia(ref List<DistanciaModel> listaDistanciaModel, List<int> listFoundID, string localizacaoInicial, string localizacalFinal, ref int ultimaDistancia)
        {
            List<int> listDistancias = new List<int>();
          
            listaDistanciaModel = listaDistanciaModel.Where(w => listFoundID.Contains(w.Id) == false).ToList();

            var listaDistanciaModelTemp = listaDistanciaModel.Where(w => w.LocalizacaoOrigem == localizacaoInicial || w.LocalizacaoDestino == localizacaoInicial).ToList();
            if (listaDistanciaModelTemp == null || listaDistanciaModelTemp.Any() == false)
            {
                return 999;
            }

            var listaDistanciaModelRef = listaDistanciaModel.ToList();

            foreach (var itemDistancia in listaDistanciaModelTemp)
            {
                if (itemDistancia.LocalizacaoOrigem == localizacaoInicial)
                {
                    listFoundID.Add(itemDistancia.Id);

                    if (itemDistancia.LocalizacaoDestino == localizacalFinal)
                    {
                        return ultimaDistancia + itemDistancia.Distancia;
                    }
                    else
                    {
                        int novaDistancia = ultimaDistancia + itemDistancia.Distancia;
                        listDistancias.Add(CalculaDistancia(ref listaDistanciaModelRef, listFoundID, itemDistancia.LocalizacaoDestino, localizacalFinal, ref novaDistancia));
                    }
                }
                if (itemDistancia.LocalizacaoDestino == localizacaoInicial)
                {
                    listFoundID.Add(itemDistancia.Id);

                    if (itemDistancia.LocalizacaoOrigem == localizacalFinal)
                    {
                        return ultimaDistancia + itemDistancia.Distancia;
                    }
                    else
                    {
                        int novaDistancia = ultimaDistancia + itemDistancia.Distancia;
                        listDistancias.Add(CalculaDistancia(ref listaDistanciaModelRef, listFoundID, itemDistancia.LocalizacaoOrigem, localizacalFinal, ref novaDistancia));
                    }
                }
            }

            if (listDistancias.Any())
            {
                return listDistancias.Min();
            }
            else
            {
                return ultimaDistancia;
            }            
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~VagaService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
