using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace InovaWebApi.Domains
{
    public partial class AreaVaga
    {
        public AreaVaga()
        {
            Vaga = new HashSet<Vaga>();
        }

        public int IdAreaVaga { get; set; }
        public string NomeAreaVaga { get; set; }
        [JsonIgnore]

        public virtual ICollection<Vaga> Vaga { get; set; }
    }
}
