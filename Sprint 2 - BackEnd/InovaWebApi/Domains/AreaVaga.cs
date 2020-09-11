using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class AreaVaga
    {
        public AreaVaga()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdAreaVaga { get; set; }
        public string NomeAreaVaga { get; set; }

        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
