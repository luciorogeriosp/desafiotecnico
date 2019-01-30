using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ProcessoSeletivoModel
{
    [Serializable]
    [DataContract]
    public class DistanciaModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string LocalizacaoOrigem { get; set; }

        [DataMember]
        public string LocalizacaoDestino { get; set; }

        [DataMember]
        public int Distancia { get; set; }
    }
}
