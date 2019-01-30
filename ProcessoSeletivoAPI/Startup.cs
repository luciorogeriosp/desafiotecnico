using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ProcessoSeletivoDataService;

namespace ProcessoSeletivoAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            #region Initialize Data

            #region Nivel de experiencia
            using (NivelExperienciaService nivelExperienciaService = new NivelExperienciaService())
            {
                nivelExperienciaService.Add(new ProcessoSeletivoModel.NivelExperienciaModel()
                {
                    Id = 1,
                    Descricao = "estagiário"
                });
                nivelExperienciaService.Add(new ProcessoSeletivoModel.NivelExperienciaModel()
                {
                    Id = 2,
                    Descricao = "júnior"
                });
                nivelExperienciaService.Add(new ProcessoSeletivoModel.NivelExperienciaModel()
                {
                    Id = 3,
                    Descricao = "pleno"
                });
                nivelExperienciaService.Add(new ProcessoSeletivoModel.NivelExperienciaModel()
                {
                    Id = 4,
                    Descricao = "sênior"
                });
                nivelExperienciaService.Add(new ProcessoSeletivoModel.NivelExperienciaModel()
                {
                    Id = 5,
                    Descricao = "especialista"
                });
            }
            #endregion

            #region Vaga
            using (VagaService vagaService = new VagaService())
            {
                vagaService.Add(new ProcessoSeletivoModel.VagaModel()
                {
                    Empresa = "Teste",
                    Titulo = "Vaga teste",
                    Descricao = "Criar os mais diferentes tipos de teste",
                    Localizacao = "A",
                    Nivel = 3
                });

                vagaService.Add(new ProcessoSeletivoModel.VagaModel()
                {
                    Empresa = "Vagas",
                    Titulo = "F#",
                    Descricao = "Vaga F",
                    Localizacao = "F",
                    Nivel = 3
                });
            }
            #endregion

            #region Pessoa
            using (PessoaService pessoaService = new PessoaService())
            {
                pessoaService.Add(new ProcessoSeletivoModel.PessoaModel()
                {
                    Nome = "Mary Jan",
                    Profissao = "Engenheira de Software",
                    Localizacao = "A",
                    Nivel = 4

                });

                pessoaService.Add(new ProcessoSeletivoModel.PessoaModel()
                {
                    Nome = "John Doe",
                    Profissao = "Engenheiro de Software",
                    Localizacao = "C",
                    Nivel = 2

                });
            }
            #endregion

            #region Candidatura
            using (CandidaturaService candidaturaService = new CandidaturaService())
            {
                candidaturaService.Add(new ProcessoSeletivoModel.CandidaturaModel()
                {
                    IdVaga = 1,
                    IdPessoa = 1
                });

                candidaturaService.Add(new ProcessoSeletivoModel.CandidaturaModel()
                {
                    IdVaga = 1,
                    IdPessoa = 2
                });

                candidaturaService.Add(new ProcessoSeletivoModel.CandidaturaModel()
                {
                    IdVaga = 2,
                    IdPessoa = 1
                });
            }
            #endregion

            #region Distancia
            using (var service = new DistanciaService())
            {
                service.Add(new ProcessoSeletivoModel.DistanciaModel()
                {
                    LocalizacaoOrigem = "A",
                    LocalizacaoDestino = "B",                    
                    Distancia = 5
                });
                service.Add(new ProcessoSeletivoModel.DistanciaModel()
                {
                    LocalizacaoOrigem = "B",
                    LocalizacaoDestino = "C",
                    Distancia = 7
                });
                service.Add(new ProcessoSeletivoModel.DistanciaModel()
                {
                    LocalizacaoOrigem = "B",
                    LocalizacaoDestino = "D",
                    Distancia = 3
                });
                service.Add(new ProcessoSeletivoModel.DistanciaModel()
                {
                    LocalizacaoOrigem = "C",
                    LocalizacaoDestino = "E",
                    Distancia = 4
                });
                service.Add(new ProcessoSeletivoModel.DistanciaModel()
                {
                    LocalizacaoOrigem = "E",
                    LocalizacaoDestino = "D",
                    Distancia = 10
                });
                service.Add(new ProcessoSeletivoModel.DistanciaModel()
                {
                    LocalizacaoOrigem = "D",
                    LocalizacaoDestino = "F",
                    Distancia = 8
                });
            }
            #endregion

            #endregion
        }
    }
}
