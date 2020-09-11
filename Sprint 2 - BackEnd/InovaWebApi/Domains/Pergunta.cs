using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Pergunta
    {
        public Pergunta()
        {
            Resposta = new HashSet<Resposta>();
        }

        public int IdPergunta { get; set; }
        public string NomePergunta { get; set; }
        public int? IdTipoPergunta { get; set; }

        public virtual TipoPergunta IdTipoPerguntaNavigation { get; set; }
        public virtual ICollection<Resposta> Resposta { get; set; }
    }
}
