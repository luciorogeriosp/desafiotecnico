using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ProcessoSeletivoModel
{
    [Serializable]
    [DataContract]
    public class PessoaModel
    {
        [DataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome.")]
        [DataMember]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Profissão.")]
        [DataMember]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "Informe a Localização.")]
        [DataMember]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "Informe o Nivel.")]
        [DataMember]
        public int Nivel { get; set; }
    }
}
