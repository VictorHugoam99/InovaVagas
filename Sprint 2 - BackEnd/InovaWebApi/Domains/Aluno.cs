using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Aluno
    {
        public Aluno()
        {
            Candidatura = new HashSet<Candidatura>();
            Curriculo = new HashSet<Curriculo>();
        }

        public int IdAluno { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string NumeroMatricula { get; set; }
        public DateTime DataNasc { get; set; }
        public string TituloPerfil { get; set; }
        public bool Empregado { get; set; }
        public int? NumeroVagasInscritas { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCurso { get; set; }
        public int? IdGenero { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Genero IdGeneroNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Candidatura> Candidatura { get; set; }
        public virtual ICollection<Curriculo> Curriculo { get; set; }
    }
}
