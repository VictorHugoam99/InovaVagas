using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class TipoCursoRepository : ITipoCursoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, TipoCurso tipoCursoAtualizado)
        {
            TipoCurso tipoCursoBuscado = ctx.TipoCurso.Find(id);

            if (tipoCursoBuscado != null)
            {
                if (tipoCursoAtualizado.NomeTipoCurso != null)
                {
                    tipoCursoBuscado.NomeTipoCurso = tipoCursoAtualizado.NomeTipoCurso;
                }

                ctx.TipoCurso.Update(tipoCursoBuscado);
                ctx.SaveChanges();
            }
        }

        public TipoCurso BuscarPorId(int id)
        {
            TipoCurso tipoCursoBuscado = ctx.TipoCurso.FirstOrDefault(tc => tc.IdTipoCurso == id);

            if (tipoCursoBuscado != null)
            {
                return tipoCursoBuscado;
            }

            return null;
        }

        public void Cadastrar(TipoCurso novoTipoCurso)
        {
            ctx.TipoCurso.Add(novoTipoCurso);
            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            TipoCurso tipoCursoBuscado = ctx.TipoCurso.Find(id);
            ctx.TipoCurso.Remove(tipoCursoBuscado);
            ctx.SaveChanges();
        }

        public List<TipoCurso> ListarTodos()
        {
            return ctx.TipoCurso.ToList();
        }
    }
}
