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
    public class VagasUnitTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void VagasModelVazio()
        {
            var controller = new ProcessoSeletivoController();

            var model = new VagaModel()
            {

            };

            IList<ValidationResult> modelError = (ModelStateTest.ValidateModel(model));
            if (modelError.Count > 0)
            {
                Assert.Fail("Model preenchido incorretamente.", modelError);
            }
            else
            {
                var result = controller.Vagas(model);
                ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.VagaModel> o = (ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.VagaModel>)JsonConvert.DeserializeObject(result, typeof(ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.VagaModel>));
                Assert.IsTrue(o.IsSuccess);
            }
        }

        [Test]
        public void VagasInclusaoOK()
        {
            var controller = new ProcessoSeletivoController();

            var model = new VagaModel()
            {
                Empresa = "Tropical Internet",
                Descricao = "Arquiteto Senior",
                Localizacao = "C",
                Nivel = 5,
                Titulo = "Arquiteto Senior de Operações"
            };

            IList<ValidationResult> modelError = (ModelStateTest.ValidateModel(model));
            if (modelError.Count > 0)
            {
                Assert.Fail("Model preenchido incorretamente.", modelError);
            }
            else
            {
                var result = controller.Vagas(model);
                ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.VagaModel> o = (ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.VagaModel>)JsonConvert.DeserializeObject(result, typeof(ProcessoSeletivoAPI.Helpers.CustomResponse<ProcessoSeletivoModel.VagaModel>));
                Assert.IsTrue(o.IsSuccess);
            }
        }
    }
}