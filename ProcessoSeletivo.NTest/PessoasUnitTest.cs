using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using ProcessoSeletivoModel;
using ProcessoSeletivoAPI.Controllers;
using System.ComponentModel.DataAnnotations;
using ProcessoSeletivo.NTest;
using System.Collections.Generic;

namespace Tests
{
    public class PessoasUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PessoasModelVazio()
        {
            var controller = new ProcessoSeletivoController();

            var model = new PessoaModel()
            {

            };

            IList<ValidationResult> modelError = (ModelStateTest.ValidateModel(model));
            if (modelError.Count > 0)
            {
                Assert.Fail("Model preenchido incorretamente.", modelError);
            }
            else
            {
                var result = controller.Pessoas(model);
                ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.PessoaModel> o = (ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.PessoaModel>)JsonConvert.DeserializeObject(result, typeof(ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.PessoaModel>));
                Assert.IsTrue(o.IsSuccess);
            }
        }

        [Test]
        public void PessoasInclusaoOK()
        {
            var controller = new ProcessoSeletivoController();

            var model = new PessoaModel()
            {
                Nome = "Lucio Rogerio dos Santos Pinto",
                Profissao = "Arquiteto Senior",
                Localizacao = "C",
                Nivel = 5
            };

            IList<ValidationResult> modelError = (ModelStateTest.ValidateModel(model));
            if (modelError.Count > 0)
            {
                Assert.Fail("Model preenchido incorretamente.", modelError);
            }
            else
            {
                var result = controller.Pessoas(model);
                ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.PessoaModel> o = (ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.PessoaModel>)JsonConvert.DeserializeObject(result, typeof(ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.PessoaModel>));
                Assert.IsTrue(o.IsSuccess);
            }
        }
    }
}