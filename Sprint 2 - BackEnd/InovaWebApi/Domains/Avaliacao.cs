using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Avaliacao
    {
        public Avaliacao()
        {
            Resposta = new HashSet<Resposta>();
        }

        public int IdAvaliacao { get; set; }
        public DateTime? Avaliacao1Data { get; set; }
        public bool? Avaliacao1Realizada { get; set; }
        public DateTime? Avaliacao2Data { get; set; }
        public bool? Avaliacao2Realizada { get; set; }
        public DateTime? VisitaTecnicaData { get; set; }
        public bool? VisitaTecnicaRealizada { get; set; }
        public int? IdContrato { get; set; }

        public virtual Contrato IdContratoNavigation { get; set; }
        public virtual ICollection<Resposta> Resposta { get; set; }
    }
}
