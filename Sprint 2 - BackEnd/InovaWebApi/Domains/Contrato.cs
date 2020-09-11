using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Contrato
    {
        public Contrato()
        {
            Avaliacao = new HashSet<Avaliacao>();
        }

        public int IdContrato { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string DiasContrato { get; set; }
        public bool RequerimentoAssinatura { get; set; }
        public bool CopiaContrato { get; set; }
        public bool? PlanoEstagio { get; set; }
        public string MotivoEvasao { get; set; }
        public int? IdCandidatura { get; set; }
        public int? IdStatusContrato { get; set; }

        public virtual Candidatura IdCandidaturaNavigation { get; set; }
        public virtual StatusContrato IdStatusContratoNavigation { get; set; }
        public virtual ICollection<Avaliacao> Avaliacao { get; set; }
    }
}
