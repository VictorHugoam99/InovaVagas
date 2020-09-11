using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class StatusCandidatura
    {
        public StatusCandidatura()
        {
            Candidatura = new HashSet<Candidatura>();
        }

        public int IdStatusCandidatura { get; set; }
        public string NomeStatusCandidatura { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Candidatura> Candidatura { get; set; }
    }
}
