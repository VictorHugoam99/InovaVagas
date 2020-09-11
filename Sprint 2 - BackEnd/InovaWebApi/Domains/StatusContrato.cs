using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class StatusContrato
    {
        public StatusContrato()
        {
            Contrato = new HashSet<Contrato>();
        }

        public int IdStatusContrato { get; set; }
        public string NomeStatusContrato { get; set; }

        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
