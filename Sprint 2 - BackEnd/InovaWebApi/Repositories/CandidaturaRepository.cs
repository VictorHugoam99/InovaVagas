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
    public class CandidaturaRepository : ICandidaturaRepository
    {

        InovaVagasContext ctx = new InovaVagasContext();

        public void Add(Candidatura candidatura)
        {
            ctx.Candidatura.Add(candidatura);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            Candidatura candidaturaBuscada = ctx.Candidatura.Find(id);
            ctx.Candidatura.Remove(candidaturaBuscada);
            ctx.SaveChanges();
        }

        public List<Candidatura> GetAll()
        {
            return ctx.Candidatura
                .Select(c => new Candidatura()
                {
                    IdCandidatura = c.IdCandidatura,
                    DataCandidatura = c.DataCandidatura,
                    Contratado = c.Contratado,
                    IdStatusCandidatura = c.IdStatusCandidatura,
                    IdAluno = c.IdAluno,
                    IdVaga = c.IdVaga,

                    IdStatusCandidaturaNavigation = new StatusCandidatura()
                    {
                        IdStatusCandidatura = c.IdStatusCandidaturaNavigation.IdStatusCandidatura,
                        NomeStatusCandidatura = c.IdStatusCandidaturaNavigation.NomeStatusCandidatura,
                        Descricao = c.IdStatusCandidaturaNavigation.Descricao
                    },

                    IdAlunoNavigation = new Aluno()
                    {
                        IdAluno = c.IdAlunoNavigation.IdAluno,
                        Nome = c.IdAlunoNavigation.Nome,
                        Cpf = c.IdAlunoNavigation.Cpf,
                        Rg = c.IdAlunoNavigation.Rg,
                        NumeroMatricula = c.IdAlunoNavigation.NumeroMatricula,
                        DataNasc = c.IdAlunoNavigation.DataNasc,
                        TituloPerfil = c.IdAlunoNavigation.TituloPerfil,
                        Empregado = c.IdAlunoNavigation.Empregado,
                        NumeroVagasInscritas = c.IdAlunoNavigation.NumeroVagasInscritas,
                        IdGenero = c.IdAlunoNavigation.IdGenero,
                        IdUsuario = c.IdAlunoNavigation.IdUsuario,
                        IdCurso = c.IdAlunoNavigation.IdCurso,

                        IdUsuarioNavigation = new Usuario()
                        {
                            IdUsuario = c.IdAlunoNavigation.IdUsuarioNavigation.IdUsuario,
                            Email = c.IdAlunoNavigation.IdUsuarioNavigation.Email,
                            Senha = c.IdAlunoNavigation.IdUsuarioNavigation.Senha,
                            Endereco = c.IdAlunoNavigation.IdUsuarioNavigation.Endereco,
                            Telefone = c.IdAlunoNavigation.IdUsuarioNavigation.Telefone,
                            Celular = c.IdAlunoNavigation.IdUsuarioNavigation.Celular,
                            EmailContato = c.IdAlunoNavigation.IdUsuarioNavigation.EmailContato,
                            DataCadastro = c.IdAlunoNavigation.IdUsuarioNavigation.DataCadastro,
                        },

                        IdCursoNavigation = new Curso()
                        {
                            IdCurso = c.IdAlunoNavigation.IdCursoNavigation.IdCurso,
                            NomeCurso = c.IdAlunoNavigation.IdCursoNavigation.NomeCurso,
                            IdTurno = c.IdAlunoNavigation.IdCursoNavigation.IdTurno,
                            IdTermo = c.IdAlunoNavigation.IdCursoNavigation.IdTermo,
                            IdTipoCurso = c.IdAlunoNavigation.IdCursoNavigation.IdTipoCurso,

                            IdTurnoNavigation = new Turno()
                            {
                                IdTurno = c.IdAlunoNavigation.IdCursoNavigation.IdTurnoNavigation.IdTurno,
                                NomeTurno = c.IdAlunoNavigation.IdCursoNavigation.IdTurnoNavigation.NomeTurno,
                            },

                            IdTermoNavigation = new Termo()
                            {
                                IdTermo = c.IdAlunoNavigation.IdCursoNavigation.IdTermoNavigation.IdTermo,
                                NumeroTermo = c.IdAlunoNavigation.IdCursoNavigation.IdTermoNavigation.NumeroTermo,
                            },

                            IdTipoCursoNavigation = new TipoCurso()
                            {
                                IdTipoCurso = c.IdAlunoNavigation.IdCursoNavigation.IdTipoCursoNavigation.IdTipoCurso,
                                NomeTipoCurso = c.IdAlunoNavigation.IdCursoNavigation.IdTipoCursoNavigation.NomeTipoCurso
                            }
                        },

                        IdGeneroNavigation = new Genero()
                        {
                            IdGenero = c.IdAlunoNavigation.IdGeneroNavigation.IdGenero,
                            NomeGenero = c.IdAlunoNavigation.IdGeneroNavigation.NomeGenero
                        }

                    },

                    IdVagaNavigation = new Vaga()
                    {
                        IdVaga = c.IdVagaNavigation.IdVaga,
                        NomeVaga = c.IdVagaNavigation.NomeVaga,
                        Descricao = c.IdVagaNavigation.Descricao,
                        Requisitos = c.IdVagaNavigation.Requisitos,
                        NumeroCandidatos = c.IdVagaNavigation.NumeroCandidatos,
                        VagaAtiva = c.IdVagaNavigation.VagaAtiva,
                        DataEncerramento = c.IdVagaNavigation.DataEncerramento,
                        DataCadastro = c.IdVagaNavigation.DataCadastro,
                        Salario = c.IdVagaNavigation.Salario,
                        IdEmpresa = c.IdVagaNavigation.IdEmpresa,
                        IdAreaVaga = c.IdVagaNavigation.IdAreaVaga,
                        IdFormaContratacao = c.IdVagaNavigation.IdFormaContratacao,

                        IdAreaVagaNavigation = new AreaVaga()
                        {
                            IdAreaVaga = c.IdVagaNavigation.IdAreaVagaNavigation.IdAreaVaga,
                            NomeAreaVaga = c.IdVagaNavigation.IdAreaVagaNavigation.NomeAreaVaga
                        },

                        IdFormaContratacaoNavigation = new FormaContratacao()
                        {
                            IdFormaContratacao = c.IdVagaNavigation.IdFormaContratacaoNavigation.IdFormaContratacao,
                            NomeFormaContratacao = c.IdVagaNavigation.IdFormaContratacaoNavigation.NomeFormaContratacao
                        },

                        IdEmpresaNavigation = new Empresa()
                        {
                            IdEmpresa = c.IdVagaNavigation.IdEmpresaNavigation.IdEmpresa,
                            RazaoSocial = c.IdVagaNavigation.IdEmpresaNavigation.RazaoSocial,
                            NomeFantasia = c.IdVagaNavigation.IdEmpresaNavigation.NomeFantasia,
                            RamoAtuacao = c.IdVagaNavigation.IdEmpresaNavigation.RamoAtuacao,
                            TamanhoEmpresa = c.IdVagaNavigation.IdEmpresaNavigation.TamanhoEmpresa,
                            Cnpj = c.IdVagaNavigation.IdEmpresaNavigation.Cnpj,
                            Cnae = c.IdVagaNavigation.IdEmpresaNavigation.Cnae,
                            CadastroAprovado = c.IdVagaNavigation.IdEmpresaNavigation.CadastroAprovado,
                            PessoaResponsavel = c.IdVagaNavigation.IdEmpresaNavigation.PessoaResponsavel,
                            VagasTotais = c.IdVagaNavigation.IdEmpresaNavigation.VagasTotais,
                            VagasDisponiveis = c.IdVagaNavigation.IdEmpresaNavigation.VagasDisponiveis,
                            VagasEncerradas = c.IdVagaNavigation.IdEmpresaNavigation.VagasEncerradas,
                            IdUsuario = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuario,

                            IdUsuarioNavigation = new Usuario()
                            {
                                IdUsuario = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.IdUsuario,
                                Email = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Email,
                                Senha = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Senha,
                                Endereco = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Endereco,
                                Telefone = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Telefone,
                                Celular = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Celular,
                                EmailContato = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.EmailContato,
                                DataCadastro = c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.DataCadastro
                            }
                        }
                    }
                })
                .ToList();
        }

        public Candidatura GetById(int id)
        {
            Candidatura candidaturaBuscada = ctx.Candidatura
                .Include(c => c.IdAlunoNavigation)
                .Include(c => c.IdVagaNavigation)
                .Include(c => c.IdStatusCandidaturaNavigation)
                 /*.Include(c => c.IdAlunoNavigation.IdGeneroNavigation)
                .Include(c => c.IdAlunoNavigation.IdUsuarioNavigation)
                .Include(c => c.IdAlunoNavigation.IdCursoNavigation)
                .Include(c => c.IdAlunoNavigation.IdCursoNavigation.IdTipoCursoNavigation)
                .Include(c => c.IdAlunoNavigation.IdCursoNavigation.IdTermoNavigation)
                .Include(c => c.IdAlunoNavigation.IdCursoNavigation.IdTurnoNavigation)
                .Include(c => c.IdVagaNavigation.IdEmpresaNavigation)
                .Include(c => c.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation)
                .Include(c => c.IdVagaNavigation.IdAreaVagaNavigation)
                .Include(c => c.IdVagaNavigation.IdFormaContratacao)*/
                .FirstOrDefault(c => c.IdCandidatura == id);
            return candidaturaBuscada;
        }

        public void Update(int id, Candidatura candidaturaAtualizada)
        {
            Candidatura candidaturaBuscada = ctx.Candidatura.Find(id);

            if (candidaturaBuscada != null)
            {
                if (candidaturaAtualizada.Contratado != candidaturaBuscada.Contratado)
                {
                    candidaturaBuscada.Contratado = candidaturaAtualizada.Contratado;
                }

                if (candidaturaAtualizada.IdStatusCandidatura != null)
                {
                    candidaturaBuscada.IdStatusCandidatura = candidaturaAtualizada.IdStatusCandidatura;
                }

                ctx.Candidatura.Update(candidaturaBuscada);
                ctx.SaveChanges();
            }
        }
    }
}




