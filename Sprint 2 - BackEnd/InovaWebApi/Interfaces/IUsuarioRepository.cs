using InovaWebApi.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();
        void Excluir(int id);
        Usuario BuscarPorId(int id);
        Object VerificarTipoUsuario(string email, string senha);
        IActionResult CricaoToken(string email, int id, string tipoRole);
    }
}
