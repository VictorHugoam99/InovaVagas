using System;
using System.Collections.Generic;

namespace InovaVagasWebApi.Domains
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
