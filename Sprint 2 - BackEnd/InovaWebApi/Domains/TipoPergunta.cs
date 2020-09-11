using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class TipoPergunta
    {
        public TipoPergunta()
        {
            Pergunta = new HashSet<Pergunta>();
        }

        public int IdTipoPergunta { get; set; }
        public string NomeTipoPergunta { get; set; }

        public virtual ICollection<Pergunta> Pergunta { get; set; }
    }
}
