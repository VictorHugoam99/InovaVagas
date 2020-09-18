using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class StatusCandidaturaRepository : IStatusCandidaturaRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, StatusCandidatura statusCandidaturaAtualizado)
        {
            StatusCandidatura statusCandidaturaBuscado = ctx.StatusCandidatura.Find(id);

            if (statusCandidaturaBuscado != null)
            {
                if (statusCandidaturaAtualizado.NomeStatusCandidatura != null)
                {
                    statusCandidaturaBuscado.NomeStatusCandidatura = statusCandidaturaAtualizado.NomeStatusCandidatura;
                }

                if (statusCandidaturaAtualizado.Descricao != null)
                {
                    statusCandidaturaBuscado.Descricao = statusCandidaturaAtualizado.Descricao;
                }

                ctx.StatusCandidatura.Update(statusCandidaturaBuscado);
                ctx.SaveChanges();
            }
        }

        public StatusCandidatura BuscarPorId(int id)
        {
            StatusCandidatura statusCandidaturaBuscado = ctx.StatusCandidatura.FirstOrDefault(sc => sc.IdStatusCandidatura == id);

            if (statusCandidaturaBuscado != null)
            {
                return statusCandidaturaBuscado;
            }

            return null;
        }

        public void Cadastrar(StatusCandidatura novoStatusCandidatura)
        {
            ctx.StatusCandidatura.Add(novoStatusCandidatura);
            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            StatusCandidatura statusCandidaturaBuscado = ctx.StatusCandidatura.Find(id);
            ctx.StatusCandidatura.Remove(statusCandidaturaBuscado);
            ctx.SaveChanges();
        }

        public List<StatusCandidatura> ListarTodos()
        {
            return ctx.StatusCandidatura.ToList();
        }
    }
}
