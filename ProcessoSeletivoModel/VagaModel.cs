using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ProcessoSeletivoModel
{
    [Serializable]
    [DataContract]
    public class VagaModel
    {
        [DataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a Empresa.")]
        [DataMember]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Informe o Título.")]
        [DataMember]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a Descrição.")]
        [DataMember]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Localização.")]
        [DataMember]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "Informe o Nível.")]
        [DataMember]
        public int Nivel { get; set; }
    }
}
