using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Administrador = new HashSet<Administrador>();
            Aluno = new HashSet<Aluno>();
            Empresa = new HashSet<Empresa>();
        }

        public int IdUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte[] ImagemPerfil { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string EmailContato { get; set; }
        public DateTime? DataCadastro { get; set; }

        public virtual ICollection<Administrador> Administrador { get; set; }
        public virtual ICollection<Aluno> Aluno { get; set; }
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
