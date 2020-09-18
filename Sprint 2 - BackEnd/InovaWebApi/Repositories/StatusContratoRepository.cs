using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class StatusContratoRepository : IStatusContratoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();
        public void Atualizar(int id, StatusContrato statusContratoAtualizado)
        {
            StatusContrato statusContratoBuscado = ctx.StatusContrato.Find(id);

            if (statusContratoBuscado != null)
            {
                if (statusContratoAtualizado.NomeStatusContrato != null)
                {
                    statusContratoBuscado.NomeStatusContrato = statusContratoAtualizado.NomeStatusContrato;
                }
            }

            ctx.StatusContrato.Update(statusContratoBuscado);

            ctx.SaveChanges();
        }

        public StatusContrato BuscarPorId(int id)
        {
            StatusContrato scBuscada = ctx.StatusContrato.FirstOrDefault(sc => sc.IdStatusContrato == id);

            if (scBuscada != null)
            {
                return scBuscada;
            }

            return null;
        }

        public void Cadastrar(StatusContrato novoStatusContrato)
        {
            ctx.StatusContrato.Add(novoStatusContrato);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            StatusContrato statusContratoBuscado = ctx.StatusContrato.Find(id);

            ctx.StatusContrato.Remove(statusContratoBuscado);
            ctx.SaveChanges();
        }

        public List<StatusContrato> Listar()
        {
            return ctx.StatusContrato.ToList();
        }
    }
}