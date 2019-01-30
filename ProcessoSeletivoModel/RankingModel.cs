using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProcessoSeletivoModel
{
    [Serializable]
    [DataContract]
    public class RankingModel
    {
        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public string Profissao { get; set; }

        [DataMember]
        public string Localizacao { get; set; }

        [DataMember]
        public int Nivel { get; set; }

        [DataMember]
        public int Score { get; set; }
    }
}
