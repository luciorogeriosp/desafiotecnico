using System;
using System.Runtime.Serialization;

namespace ProcessoSeletivoModel
{
    [Serializable]
    [DataContract]
    public class NivelExperienciaModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Descricao { get; set; }
    }
}
