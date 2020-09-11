using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Termo
    {
        public Termo()
        {
            Curso = new HashSet<Curso>();
        }

        public int IdTermo { get; set; }
        public byte? NumeroTermo { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
