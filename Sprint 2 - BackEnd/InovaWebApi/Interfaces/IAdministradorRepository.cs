using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IAdministradorRepository
    {
        void Cadastrar(Administrador novoAdministrador);
        List<Administrador> ListarTodos();
        Administrador BuscarPorId(int id);
        void Atualizar(int id, Administrador administradorAtualizado);
        void Excluir(int id);
        Administrador Login(string email, string senha);

        //add um metodo q coloca uma ft de perfil
    }
}
