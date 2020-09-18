using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface ITipoCursoRepository
    {
        void Cadastrar(TipoCurso novoTipoCurso);
        List<TipoCurso> ListarTodos();
        void Atualizar(int id, TipoCurso tipoCursoAtualizado);
        void Excluir(int id);
        TipoCurso BuscarPorId(int id);
    }
}
