using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IStatusCandidaturaRepository
    {
        void Cadastrar(StatusCandidatura novoStatusCandidatura);
        List<StatusCandidatura> ListarTodos();
        void Atualizar(int id, StatusCandidatura statusCandidaturaAtualizado);
        void Excluir(int id);
        StatusCandidatura BuscarPorId(int id);
    }
}
