using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ProcessoSeletivoModel
{
    [Serializable]
    [DataContract]
    public class CandidaturaModel
    {
        [DataMember]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o ID da Vaga.")]
        [DataMember]
        public int IdVaga { get; set; }

        [Required(ErrorMessage = "Informe o ID da Pessoa.")]
        [DataMember]
        public int IdPessoa { get; set; }
    }
}
