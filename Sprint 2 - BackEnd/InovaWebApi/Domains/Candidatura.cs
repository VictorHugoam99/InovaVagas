using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Candidatura
    {
        public Candidatura()
        {
            Contrato = new HashSet<Contrato>();
        }

        public int IdCandidatura { get; set; }
        public DateTime? DataCandidatura { get; set; }
        public bool? Contratado { get; set; }
        public int? IdStatusCandidatura { get; set; }
        public int? IdVaga { get; set; }
        public int? IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
        public virtual StatusCandidatura IdStatusCandidaturaNavigation { get; set; }
        public virtual Vaga IdVagaNavigation { get; set; }
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
