using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string RamoAtuacao { get; set; }
        public string TamanhoEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string Cnae { get; set; }
        public bool CadastroAprovado { get; set; }
        public string PessoaResponsavel { get; set; }
        public int? VagasTotais { get; set; }
        public int? VagasDisponiveis { get; set; }
        public int? VagasEncerradas { get; set; }
        public int? NumeroContratacoes { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
