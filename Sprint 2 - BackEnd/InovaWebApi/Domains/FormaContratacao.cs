using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class FormaContratacao
    {
        public FormaContratacao()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdFormaContratacao { get; set; }
        public string NomeFormaContratacao { get; set; }

        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
