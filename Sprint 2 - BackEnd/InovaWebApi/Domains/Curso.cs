using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Curso
    {
        public Curso()
        {
            Aluno = new HashSet<Aluno>();
        }

        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public int? IdTurno { get; set; }
        public int? IdTermo { get; set; }
        public int? IdTipoCurso { get; set; }

        public virtual Termo IdTermoNavigation { get; set; }
        public virtual TipoCurso IdTipoCursoNavigation { get; set; }
        public virtual Turno IdTurnoNavigation { get; set; }
        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}
