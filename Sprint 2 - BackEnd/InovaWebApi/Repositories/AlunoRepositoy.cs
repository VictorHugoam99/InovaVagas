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

    public class AlunoRepository : IAlunoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();
        //IAlunoRepository _alunoRepository = new AlunoRepository();

        public void Update(int id, Aluno alunoAtualizado)
        {
            Aluno alunoBuscado = ctx.Aluno.FirstOrDefault(a => a.IdAluno == id);
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == alunoBuscado.IdUsuario);
            //Curso cursoBuscado = ctx.Curso.FirstOrDefault(c => c.IdCurso == alunoBuscado.IdCurso);
            alunoBuscado.IdUsuarioNavigation = usuarioBuscado;
/*          alunoBuscado.IdCursoNavigation = cursoBuscado;
            alunoBuscado.IdCursoNavigation.IdTurnoNavigation = turnoBuscado;
            alunoBuscado.IdCursoNavigation.IdTermoNavigation = termoBuscado;
            alunoBuscado.IdCursoNavigation.IdTipoCursoNavigation = tipoCursoBuscado;*/

            if (alunoBuscado != null)
            {
                if (alunoAtualizado.Nome != null && alunoAtualizado.Nome != "")
                {
                    alunoBuscado.Nome = alunoAtualizado.Nome;
                }

                if (alunoAtualizado.Cpf != null && alunoAtualizado.Cpf != "")
                {
                    alunoBuscado.Cpf = alunoAtualizado.Cpf;
                }

                if (alunoAtualizado.Rg != null && alunoAtualizado.Rg != "")
                {
                    alunoBuscado.Rg = alunoAtualizado.Rg;
                }

                if (alunoAtualizado.NumeroMatricula != null && alunoAtualizado.NumeroMatricula != "")
                {
                    alunoBuscado.NumeroMatricula = alunoAtualizado.NumeroMatricula;
                }

                if (alunoAtualizado.DataNasc != null && alunoAtualizado.DataNasc != Convert.ToDateTime("01/01/0001"))
                {
                    alunoBuscado.DataNasc = alunoAtualizado.DataNasc;
                }

                if (alunoAtualizado.TituloPerfil != null && alunoAtualizado.TituloPerfil != "")
                {
                    alunoBuscado.TituloPerfil = alunoAtualizado.TituloPerfil;
                }

                if (alunoAtualizado.Empregado != alunoBuscado.Empregado)
                {
                    alunoBuscado.Empregado = alunoAtualizado.Empregado;
                }

                if (alunoAtualizado.IdCurso != null && alunoAtualizado.IdCurso != 0)
                {
                    alunoBuscado.IdCurso = alunoAtualizado.IdCurso;
                }

                if (alunoAtualizado.IdUsuarioNavigation.Email != null && alunoAtualizado.IdUsuarioNavigation.Email != "")
                {
                    alunoBuscado.IdUsuarioNavigation.Email = alunoAtualizado.IdUsuarioNavigation.Email;
                }

                if (alunoAtualizado.IdUsuarioNavigation.Senha != null && alunoAtualizado.IdUsuarioNavigation.Senha != "")
                {
                    alunoBuscado.IdUsuarioNavigation.Senha = alunoAtualizado.IdUsuarioNavigation.Senha;
                }

                if (alunoAtualizado.IdUsuarioNavigation.EmailContato != null && alunoAtualizado.IdUsuarioNavigation.EmailContato != "")
                {
                    alunoBuscado.IdUsuarioNavigation.EmailContato = alunoAtualizado.IdUsuarioNavigation.EmailContato;
                }

                if (alunoAtualizado.IdUsuarioNavigation.Endereco != null && alunoAtualizado.IdUsuarioNavigation.Endereco != "")
                {
                    alunoBuscado.IdUsuarioNavigation.Endereco = alunoAtualizado.IdUsuarioNavigation.Endereco;
                }

                if (alunoAtualizado.IdUsuarioNavigation.Telefone != null && alunoAtualizado.IdUsuarioNavigation.Telefone != "")
                {
                    alunoBuscado.IdUsuarioNavigation.Telefone = alunoAtualizado.IdUsuarioNavigation.Telefone;
                }

                if (alunoAtualizado.IdUsuarioNavigation.Celular != null && alunoAtualizado.IdUsuarioNavigation.Celular != "")
                {
                    alunoBuscado.IdUsuarioNavigation.Celular = alunoAtualizado.IdUsuarioNavigation.Celular;
                }

                if (alunoAtualizado.IdGenero != null && alunoAtualizado.IdGenero != 0)
                {
                    alunoBuscado.IdGenero = alunoAtualizado.IdGenero;
                }

                ctx.Aluno.Update(alunoBuscado);
                ctx.SaveChanges();
            }
        }

        public void Add(Aluno aluno)
        {
            ctx.Aluno.Add(aluno);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Aluno alunoBuscado = ctx.Aluno.FirstOrDefault(a => a.IdAluno == id);
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == alunoBuscado.IdUsuario);
            if (alunoBuscado.IdUsuario == usuarioBuscado.IdUsuario)
            {
                ctx.Usuario.Remove(usuarioBuscado);
                ctx.Aluno.Remove(alunoBuscado);
                ctx.SaveChanges();
            }
        }

        public Aluno GetById(int id)
        {
            Aluno alunoBuscado = ctx.Aluno.FirstOrDefault(a => a.IdAluno == id);

            if (alunoBuscado != null)
            {
                return alunoBuscado;
            }

            return null;
        }

        public List<Aluno> GetAll()
        {

            return ctx.Aluno
                .Select(a => new Aluno()
                {
                    IdAluno = a.IdAluno,
                    Nome = a.Nome,
                    Cpf = a.Cpf,
                    Rg = a.Rg,
                    NumeroMatricula = a.NumeroMatricula,
                    DataNasc = a.DataNasc,
                    TituloPerfil = a.TituloPerfil,
                    Empregado = a.Empregado,
                    NumeroVagasInscritas = a.NumeroVagasInscritas,

                    IdUsuarioNavigation = new Usuario()
                    {
                        IdUsuario = a.IdUsuarioNavigation.IdUsuario,
                        Email = a.IdUsuarioNavigation.Email,
                        Senha = a.IdUsuarioNavigation.Senha,
                        Endereco = a.IdUsuarioNavigation.Endereco,
                        Telefone = a.IdUsuarioNavigation.Telefone,
                        Celular = a.IdUsuarioNavigation.Celular,
                        EmailContato = a.IdUsuarioNavigation.EmailContato,
                        DataCadastro = a.IdUsuarioNavigation.DataCadastro
                    },

                    IdCursoNavigation = new Curso()
                    {
                        IdCurso = a.IdCursoNavigation.IdCurso,
                        NomeCurso = a.IdCursoNavigation.NomeCurso,

                        IdTurnoNavigation = new Turno()
                        {
                            IdTurno = a.IdCursoNavigation.IdTurnoNavigation.IdTurno,
                            NomeTurno = a.IdCursoNavigation.IdTurnoNavigation.NomeTurno,
                        },

                        IdTermoNavigation = new Termo()
                        {
                            IdTermo = a.IdCursoNavigation.IdTermoNavigation.IdTermo,
                            NumeroTermo = a.IdCursoNavigation.IdTermoNavigation.NumeroTermo,
                        },

                        IdTipoCursoNavigation = new TipoCurso()
                        {
                            IdTipoCurso = a.IdCursoNavigation.IdTipoCursoNavigation.IdTipoCurso,
                            NomeTipoCurso = a.IdCursoNavigation.IdTipoCursoNavigation.NomeTipoCurso
                        }
                    },

                    IdGeneroNavigation = new Genero()
                    {
                        IdGenero = a.IdGeneroNavigation.IdGenero,
                        NomeGenero = a.IdGeneroNavigation.NomeGenero
                    }
                })
                .ToList();
        }

        public Aluno Login(string email, string senha)
        {
            Aluno alunoBuscado = ctx.Aluno
                // Busca as informações referentes ao tipo de usuário
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefault(a => a.IdUsuarioNavigation.Email == email && a.IdUsuarioNavigation.Senha == senha);

            // Verifica se o usuário foi encontrado
            if (alunoBuscado != null)
            {
                // Retorna o usuário encontrado
                return alunoBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }
    }
}
