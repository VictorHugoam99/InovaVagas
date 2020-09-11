using System;
using System.Collections.Generic;

namespace InovaWebApi.Domains
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public string NomeAdministrador { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
