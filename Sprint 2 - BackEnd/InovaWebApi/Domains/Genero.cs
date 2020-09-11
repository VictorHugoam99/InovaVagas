using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Genero
    {
        public Genero()
        {
            Aluno = new HashSet<Aluno>();
        }

        public int IdGenero { get; set; }
        public string NomeGenero { get; set; }

        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}
