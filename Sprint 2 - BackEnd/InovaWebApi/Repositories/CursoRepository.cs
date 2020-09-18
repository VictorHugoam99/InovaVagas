using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, Curso cursoAtualizado)
        {
            Curso cursoBuscado = ctx.Curso.FirstOrDefault(c => c.IdCurso == id);

            if (cursoBuscado != null)
            {
                if (cursoAtualizado.NomeCurso != null)
                {
                    cursoBuscado.NomeCurso = cursoAtualizado.NomeCurso;
                }

                if (cursoAtualizado.IdTurno != null)
                {
                    cursoBuscado.IdTurno = cursoAtualizado.IdTurno;
                }

                if (cursoAtualizado.IdTermo != null)
                {
                    cursoBuscado.IdTermo = cursoAtualizado.IdTermo;
                }

                if (cursoAtualizado.IdTipoCurso != null)
                {
                    cursoBuscado.IdTipoCurso = cursoAtualizado.IdTipoCurso;
                }
            }

            ctx.Curso.Update(cursoBuscado);

            ctx.SaveChanges();
        }

        public Curso BuscarPorId(int id)
        {
            Curso cursoBuscado = ctx.Curso.FirstOrDefault(c => c.IdCurso == id);

            if (cursoBuscado == null)
            {
                return null;
            }

            return cursoBuscado;
        }

        public void Cadastrar(Curso novoCurso)
        {
            ctx.Curso.Add(novoCurso);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Curso cursoBuscado = ctx.Curso.Find(id);

            ctx.Curso.Remove(cursoBuscado);

            ctx.SaveChanges();

        }

        public List<Curso> Listar()
        {
            return ctx.Curso
                .Select( c => new Curso()
                {
                    IdCurso = c.IdCurso,
                    NomeCurso = c.NomeCurso,
                    IdTurno = c.IdTurno,
                    IdTermo = c.IdTermo,
                    IdTipoCurso = c.IdTipoCurso,

                    IdTurnoNavigation = new Turno()
                    {
                        IdTurno = c.IdTurnoNavigation.IdTurno,
                        NomeTurno = c.IdTurnoNavigation.NomeTurno,
                    },

                    IdTermoNavigation = new Termo()
                    {
                        IdTermo = c.IdTermoNavigation.IdTermo,
                        NumeroTermo = c.IdTermoNavigation.NumeroTermo,
                    },

                    IdTipoCursoNavigation = new TipoCurso()
                    {
                        IdTipoCurso = c.IdTipoCursoNavigation.IdTipoCurso,
                        NomeTipoCurso = c.IdTipoCursoNavigation.NomeTipoCurso
                    }
                })
                .ToList();
        }

        public List<Curso> ListarPorNomeCurso(string nomeCurso)
        {
            return ctx.Curso.Where(c => c.NomeCurso == nomeCurso).ToList();
        }

        public List<Curso> ListarPorTermo(int idTermo)
        {
            return ctx.Curso.Where(c => c.IdTermo == idTermo).ToList();
        }

        public List<Curso> ListarPorTipoCurso(int idTipoCurso)
        {
            return ctx.Curso.Where(c => c.IdTipoCurso == idTipoCurso).ToList();
        }

        public List<Curso> ListarPorTurno(int idTurno)
        {
            return ctx.Curso.Where(c => c.IdTermo == idTurno).ToList();
        }
    }
}