using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProcessoSeletivoDataService;

namespace ProcessoSeletivo.Controllers
{
    [Route("v1")]
    [ApiController]
    public class ProcessoSeletivoController : ControllerBase
    {
        [HttpGet("Vagas")]
        public ActionResult<IEnumerable<string>> Vagas()
        {
            new VagaService().ListAll();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("Vagas/{id}")]
        public ActionResult<string> Pessoas(int id)
        {
            return "value";
        }

        //// POST api/values
        //[HttpPost]
        //public void Candidaturas([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Ranking(int id, [FromBody] string value)
        //{
        //}
    }
}
