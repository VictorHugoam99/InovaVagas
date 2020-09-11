using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Curriculo
    {
        public int IdCurriculo { get; set; }
        public string NomeEmpresa { get; set; }
        public DateTime? DataInicioEmprego { get; set; }
        public DateTime? DataTerminoEmprego { get; set; }
        public string DescricaoEmprego { get; set; }
        public string NomeEscola { get; set; }
        public DateTime? DataInicioEscola { get; set; }
        public DateTime? DataTerminoEscola { get; set; }
        public string Competencia { get; set; }
        public string LinkLinkedIn { get; set; }
        public string LinkGitHub { get; set; }
        public string InformacoesAdicionais { get; set; }
        public int? IdAluno { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
