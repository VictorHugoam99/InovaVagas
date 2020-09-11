using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class TipoCurso
    {
        public TipoCurso()
        {
            Curso = new HashSet<Curso>();
        }

        public int IdTipoCurso { get; set; }
        public string NomeTipoCurso { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
