using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Resposta
    {
        public int IdResposta { get; set; }
        public int? IdPergunta { get; set; }
        public int? IdTipoResposta { get; set; }
        public int? IdAvaliacao { get; set; }

        public virtual Avaliacao IdAvaliacaoNavigation { get; set; }
        public virtual Pergunta IdPerguntaNavigation { get; set; }
        public virtual TipoResposta IdTipoRespostaNavigation { get; set; }
    }
}
