using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class TipoResposta
    {
        public TipoResposta()
        {
            Resposta = new HashSet<Resposta>();
        }

        public int IdTipoResposta { get; set; }
        public string NomeTipoResposta { get; set; }

        public virtual ICollection<Resposta> Resposta { get; set; }
    }
}
