using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Turno
    {
        public Turno()
        {
            Curso = new HashSet<Curso>();
        }

        public int IdTurno { get; set; }
        public string NomeTurno { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
