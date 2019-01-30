using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoDataService;
using ProcessoSeletivoModel;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;
using ProcessoSeletivoAPI.Helpers;

namespace ProcessoSeletivoAPI.Controllers
{
    [Route("v1")]
    public class ProcessoSeletivoController : ControllerBase
    {
        [HttpPost("vagas")]
        public string Vagas(VagaModel item)
        {
            CustomResponse<VagaModel> result;

            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new VagaService())
                    {
                        service.Add(item);
                    };

                    result = new CustomResponse<VagaModel>(true, item);
                }
                else
                {
                    result = new CustomResponse<VagaModel>(false, GetModelStateError(), item);
                }
            }
            catch (Exception ex)
            {
                result = new CustomResponse<VagaModel>(false, new string[] { ex.Message }, item);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpPost("pessoas")]
        public string Pessoas(PessoaModel item)
        {
            CustomResponse<PessoaModel> result;

            try
            {
                if (ModelState.IsValid)
                {
                    using (var service = new PessoaService())
                    {
                        service.Add(item);
                    };

                    result = new CustomResponse<PessoaModel>(true, item);
                }
                else
                {
                    result = new CustomResponse<PessoaModel>(false, GetModelStateError(), item);
                }
            }
            catch (Exception ex)
            {
                result = new CustomResponse<PessoaModel>(false, new string[] { ex.Message }, item);
            }

            return JsonConvert.SerializeObject(result);
        }

        [HttpGet("vagas/{id}/candidaturas/ranking")]
        public string Ranking(int id)
        {
            CustomResponse<List<RankingModel>> result;

            try
            {
                List<RankingModel> list = null;

                using (var service = new RankingService())
                {
                    list = service.GetRanking(id);
                };

                result = new CustomResponse<List<RankingModel>>(true, list);
            }
            catch (Exception ex)
            {
                result = new CustomResponse<List<RankingModel>>(false, new string[] { ex.Message });
            }

            return JsonConvert.SerializeObject(result);
        }

        private string[] GetModelStateError()
        {
            List<string> lista = new List<string>();

            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    lista.Add(error.ErrorMessage);
                }
            }

            return lista.ToArray();
        }
    }
}
