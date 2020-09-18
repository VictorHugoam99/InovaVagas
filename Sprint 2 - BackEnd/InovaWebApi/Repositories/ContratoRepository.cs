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
    public class ContratoRepository : IContratoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();
        public void Atualizar(int id, Contrato contratoAtualizado)
        {
            Contrato contratoBuscado = ctx.Contrato.Find(id);

            if (contratoBuscado != null)
            {
                if (contratoAtualizado.DataInicio != null)
                {
                    contratoBuscado.DataInicio = contratoAtualizado.DataInicio;
                }

                if (contratoAtualizado.DataTermino != null)
                {
                    contratoBuscado.DataTermino = contratoAtualizado.DataTermino;
                }

                if (contratoAtualizado.DiasContrato != null)
                {
                    contratoBuscado.DiasContrato = contratoAtualizado.DiasContrato;
                }

                if (contratoAtualizado.RequerimentoAssinatura != contratoBuscado.RequerimentoAssinatura)
                {
                    contratoBuscado.RequerimentoAssinatura = contratoAtualizado.RequerimentoAssinatura;
                }

                if (contratoAtualizado.CopiaContrato != contratoBuscado.CopiaContrato)
                {
                    contratoBuscado.CopiaContrato = contratoAtualizado.CopiaContrato;
                }

                if (contratoAtualizado.PlanoEstagio != contratoBuscado.PlanoEstagio)
                {
                    contratoBuscado.PlanoEstagio = contratoAtualizado.PlanoEstagio;
                }

                if (contratoAtualizado.MotivoEvasao != null)
                {
                    contratoBuscado.MotivoEvasao = contratoAtualizado.MotivoEvasao;
                }

                if (contratoAtualizado.IdCandidatura != null)
                {
                    contratoBuscado.IdCandidatura = contratoAtualizado.IdCandidatura;
                }

                if (contratoAtualizado.IdStatusContrato != null)
                {
                    contratoBuscado.IdStatusContrato = contratoAtualizado.IdStatusContrato;
                }

                ctx.Contrato.Update(contratoBuscado);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Contrato novoContrato)
        {
            ctx.Contrato.Add(novoContrato);
            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            Contrato contratoBuscado = ctx.Contrato.Find(id);
            ctx.Contrato.Remove(contratoBuscado);
            ctx.SaveChanges();
        }

        public List<Contrato> ListarPorCopiaContrato(bool copiaContrato)
        {
            throw new NotImplementedException();
        }

        public List<Contrato> ListarPorDataInicio(DateTime dataInicio)
        {
            throw new NotImplementedException();
        }

        public List<Contrato> ListarPorDataTermino(DateTime dataTermino)
        {
            throw new NotImplementedException();
        }

        public Contrato ListarPorId(int id)
        {
            Contrato contratoBuscado = ctx.Contrato.FirstOrDefault(c => c.IdContrato == id);

            Candidatura candidaturaBuscada = ctx.Candidatura.FirstOrDefault(ca => ca.IdCandidatura == contratoBuscado.IdCandidatura);
            contratoBuscado.IdCandidaturaNavigation = candidaturaBuscada;

            Vaga vagaBuscada = ctx.Vaga.FirstOrDefault(ca => ca.IdVaga == contratoBuscado.IdCandidaturaNavigation.IdVaga);
            contratoBuscado.IdCandidaturaNavigation.IdVagaNavigation = vagaBuscada;

            Aluno alunoBuscado = ctx.Aluno.FirstOrDefault(ca => ca.IdAluno == contratoBuscado.IdCandidaturaNavigation.IdAluno);
            contratoBuscado.IdCandidaturaNavigation.IdAlunoNavigation = alunoBuscado;

            Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(ca => ca.IdEmpresa == contratoBuscado.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresa);
            contratoBuscado.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation = empresaBuscada;

            if (contratoBuscado != null)
            {
                return contratoBuscado;
            }

            return null;
        }

        public List<Contrato> ListarPorMotivoEvasao(string motivoEvasao)
        {
            throw new NotImplementedException();
        }

        public List<Contrato> ListarPorPlanoEstagio(bool planoEstagio)
        {
            throw new NotImplementedException();
        }

        public List<Contrato> ListarPorRequerimentoAssinatura(bool requirimentoAssinatura)
        {
            throw new NotImplementedException();
        }

        public List<Contrato> ListarTodos()
        {
            return ctx.Contrato.
                Select(c => new Contrato() 
                {
                    IdContrato = c.IdContrato,
                    DataInicio = c.DataInicio,
                    DataTermino = c.DataTermino,
                    DiasContrato = c.DiasContrato,
                    RequerimentoAssinatura = c.RequerimentoAssinatura,
                    CopiaContrato = c.CopiaContrato,
                    PlanoEstagio = c.PlanoEstagio,
                    MotivoEvasao = c.MotivoEvasao,
                    IdCandidatura = c.IdCandidatura,
                    IdStatusContrato = c.IdStatusContrato,

                    IdCandidaturaNavigation = new Candidatura()
                    {
                        IdCandidatura = c.IdCandidaturaNavigation.IdCandidatura,
                        DataCandidatura = c.IdCandidaturaNavigation.DataCandidatura,
                        Contratado = c.IdCandidaturaNavigation.Contratado,
                        IdStatusCandidatura = c.IdCandidaturaNavigation.IdStatusCandidatura,
                        IdAluno = c.IdCandidaturaNavigation.IdAluno,
                        IdVaga = c.IdCandidaturaNavigation.IdVaga,

                        IdStatusCandidaturaNavigation = new StatusCandidatura()
                        {
                            IdStatusCandidatura = c.IdCandidaturaNavigation.IdStatusCandidaturaNavigation.IdStatusCandidatura,
                            NomeStatusCandidatura = c.IdCandidaturaNavigation.IdStatusCandidaturaNavigation.NomeStatusCandidatura,
                            Descricao = c.IdCandidaturaNavigation.IdStatusCandidaturaNavigation.Descricao
                        },

                        IdAlunoNavigation = new Aluno()
                        {
                            IdAluno = c.IdCandidaturaNavigation.IdAlunoNavigation.IdAluno,
                            Nome = c.IdCandidaturaNavigation.IdAlunoNavigation.Nome,
                            Cpf = c.IdCandidaturaNavigation.IdAlunoNavigation.Cpf,
                            Rg = c.IdCandidaturaNavigation.IdAlunoNavigation.Rg,
                            NumeroMatricula = c.IdCandidaturaNavigation.IdAlunoNavigation.NumeroMatricula,
                            DataNasc = c.IdCandidaturaNavigation.IdAlunoNavigation.DataNasc,
                            TituloPerfil = c.IdCandidaturaNavigation.IdAlunoNavigation.TituloPerfil,
                            Empregado = c.IdCandidaturaNavigation.IdAlunoNavigation.Empregado,
                            NumeroVagasInscritas = c.IdCandidaturaNavigation.IdAlunoNavigation.NumeroVagasInscritas,
                            IdGenero = c.IdCandidaturaNavigation.IdAlunoNavigation.IdGenero,
                            IdUsuario = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuario,
                            IdCurso = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCurso,

                            IdUsuarioNavigation = new Usuario()
                            {
                                IdUsuario = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.IdUsuario,
                                Email = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.Email,
                                Senha = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.Senha,
                                Endereco = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.Endereco,
                                Telefone = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.Telefone,
                                Celular = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.Celular,
                                EmailContato = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.EmailContato,
                                DataCadastro = c.IdCandidaturaNavigation.IdAlunoNavigation.IdUsuarioNavigation.DataCadastro,
                            },

                            IdCursoNavigation = new Curso()
                            {
                                IdCurso = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdCurso,
                                NomeCurso = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.NomeCurso,
                                IdTurno = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTurno,
                                IdTermo = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTermo,
                                IdTipoCurso = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTipoCurso,

                                IdTurnoNavigation = new Turno()
                                {
                                    IdTurno = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTurnoNavigation.IdTurno,
                                    NomeTurno = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTurnoNavigation.NomeTurno,
                                },

                                IdTermoNavigation = new Termo()
                                {
                                    IdTermo = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTermoNavigation.IdTermo,
                                    NumeroTermo = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTermoNavigation.NumeroTermo,
                                },

                                IdTipoCursoNavigation = new TipoCurso()
                                {
                                    IdTipoCurso = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTipoCursoNavigation.IdTipoCurso,
                                    NomeTipoCurso = c.IdCandidaturaNavigation.IdAlunoNavigation.IdCursoNavigation.IdTipoCursoNavigation.NomeTipoCurso
                                }
                            },

                            IdGeneroNavigation = new Genero()
                            {
                                IdGenero = c.IdCandidaturaNavigation.IdAlunoNavigation.IdGeneroNavigation.IdGenero,
                                NomeGenero = c.IdCandidaturaNavigation.IdAlunoNavigation.IdGeneroNavigation.NomeGenero
                            }

                        },

                        IdVagaNavigation = new Vaga()
                        {
                            IdVaga = c.IdCandidaturaNavigation.IdVagaNavigation.IdVaga,
                            NomeVaga = c.IdCandidaturaNavigation.IdVagaNavigation.NomeVaga,
                            Descricao = c.IdCandidaturaNavigation.IdVagaNavigation.Descricao,
                            Requisitos = c.IdCandidaturaNavigation.IdVagaNavigation.Requisitos,
                            NumeroCandidatos = c.IdCandidaturaNavigation.IdVagaNavigation.NumeroCandidatos,
                            VagaAtiva = c.IdCandidaturaNavigation.IdVagaNavigation.VagaAtiva,
                            DataEncerramento = c.IdCandidaturaNavigation.IdVagaNavigation.DataEncerramento,
                            DataCadastro = c.IdCandidaturaNavigation.IdVagaNavigation.DataCadastro,
                            Salario = c.IdCandidaturaNavigation.IdVagaNavigation.Salario,
                            IdEmpresa = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresa,
                            IdAreaVaga = c.IdCandidaturaNavigation.IdVagaNavigation.IdAreaVaga,
                            IdFormaContratacao = c.IdCandidaturaNavigation.IdVagaNavigation.IdFormaContratacao,

                            IdAreaVagaNavigation = new AreaVaga()
                            {
                                IdAreaVaga = c.IdCandidaturaNavigation.IdVagaNavigation.IdAreaVagaNavigation.IdAreaVaga,
                                NomeAreaVaga = c.IdCandidaturaNavigation.IdVagaNavigation.IdAreaVagaNavigation.NomeAreaVaga
                            },

                            IdFormaContratacaoNavigation = new FormaContratacao()
                            {
                                IdFormaContratacao = c.IdCandidaturaNavigation.IdVagaNavigation.IdFormaContratacaoNavigation.IdFormaContratacao,
                                NomeFormaContratacao = c.IdCandidaturaNavigation.IdVagaNavigation.IdFormaContratacaoNavigation.NomeFormaContratacao
                            },

                            IdEmpresaNavigation = new Empresa()
                            {
                                IdEmpresa = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdEmpresa,
                                RazaoSocial = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.RazaoSocial,
                                NomeFantasia = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.NomeFantasia,
                                RamoAtuacao = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.RamoAtuacao,
                                TamanhoEmpresa = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.TamanhoEmpresa,
                                Cnpj = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.Cnpj,
                                Cnae = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.Cnae,
                                CadastroAprovado = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.CadastroAprovado,
                                PessoaResponsavel = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.PessoaResponsavel,
                                VagasTotais = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.VagasTotais,
                                VagasDisponiveis = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.VagasDisponiveis,
                                VagasEncerradas = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.VagasEncerradas,
                                IdUsuario = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuario,

                                IdUsuarioNavigation = new Usuario()
                                {
                                    IdUsuario = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.IdUsuario,
                                    Email = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Email,
                                    Senha = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Senha,
                                    Endereco = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Endereco,
                                    Telefone = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Telefone,
                                    Celular = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.Celular,
                                    EmailContato = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.EmailContato,
                                    DataCadastro = c.IdCandidaturaNavigation.IdVagaNavigation.IdEmpresaNavigation.IdUsuarioNavigation.DataCadastro
                                }
                            }
                        }
                    }
                })
                .ToList();
        }
    }
}
