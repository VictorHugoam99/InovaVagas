using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Vaga
    {
        public Vaga()
        {
            Candidatura = new HashSet<Candidatura>();
        }

        public int IdVaga { get; set; }
        public string NomeVaga { get; set; }
        public string Descricao { get; set; }
        public string Requisitos { get; set; }
        public string Endereco { get; set; }
        public int? NumeroCandidatos { get; set; }
        public bool? VagaAtiva { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string Salario { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdFormaContratacao { get; set; }
        public int? IdAreaVaga { get; set; }

        public virtual AreaVaga IdAreaVagaNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual FormaContratacao IdFormaContratacaoNavigation { get; set; }
        public virtual ICollection<Candidatura> Candidatura { get; set; }
    }
}
