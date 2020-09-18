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
    public class EmpresaRepository : IEmpresaRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Aprovar(int id, bool respostaVerificacao)
        {
            respostaVerificacao = true;
            Empresa empresaBuscada = ctx.Empresa.Find(id);

            if (empresaBuscada != null)
            {
                if (empresaBuscada.CadastroAprovado == false)
                {
                    empresaBuscada.CadastroAprovado = respostaVerificacao;
                }
            }
        }

        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(a => a.IdEmpresa == id);
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == empresaBuscada.IdUsuario);

            if (empresaBuscada != null)
            {
                empresaBuscada.IdUsuarioNavigation = usuarioBuscado;
                empresaAtualizada.IdUsuarioNavigation = new Usuario();

                if (empresaAtualizada.RazaoSocial != null)
                {
                    empresaBuscada.RazaoSocial = empresaAtualizada.RazaoSocial;
                }

                if (empresaAtualizada.NomeFantasia != null)
                {
                    empresaBuscada.NomeFantasia = empresaAtualizada.NomeFantasia;
                }

                if (empresaAtualizada.RamoAtuacao != null)
                {
                    empresaBuscada.RamoAtuacao = empresaAtualizada.RamoAtuacao;
                }

                if (empresaAtualizada.TamanhoEmpresa != null)
                {
                    empresaBuscada.TamanhoEmpresa = empresaAtualizada.TamanhoEmpresa;
                }

                if (empresaAtualizada.Cnpj != null)
                {
                    empresaBuscada.Cnpj = empresaAtualizada.Cnpj;
                }

                if (empresaAtualizada.Cnae != null)
                {
                    empresaBuscada.Cnae = empresaAtualizada.Cnae;
                }

                if (empresaAtualizada.PessoaResponsavel != null)
                {
                    empresaBuscada.PessoaResponsavel = empresaAtualizada.PessoaResponsavel;
                }

                if (empresaAtualizada.IdUsuarioNavigation.Email != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Email = empresaAtualizada.IdUsuarioNavigation.Email;
                }

                if (empresaAtualizada.IdUsuarioNavigation.Senha != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Senha = empresaAtualizada.IdUsuarioNavigation.Senha;
                }

                if (empresaAtualizada.IdUsuarioNavigation.EmailContato != null)
                {
                    empresaBuscada.IdUsuarioNavigation.EmailContato = empresaAtualizada.IdUsuarioNavigation.EmailContato;
                }

                if (empresaAtualizada.IdUsuarioNavigation.Endereco != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Endereco = empresaAtualizada.IdUsuarioNavigation.Endereco;
                }

                if (empresaAtualizada.IdUsuarioNavigation.Telefone != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Telefone = empresaAtualizada.IdUsuarioNavigation.Telefone;
                }

                if (empresaAtualizada.IdUsuarioNavigation.Celular != null)
                {
                    empresaBuscada.IdUsuarioNavigation.Celular = empresaAtualizada.IdUsuarioNavigation.Celular;
                }

                ctx.Empresa.Update(empresaBuscada);

                ctx.SaveChanges();
            }
        }

        public Empresa BuscarPorId(int id)
        {
            Empresa empresaBuscada = ctx.Empresa
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefault(e => e.IdEmpresa == id);

            if (empresaBuscada != null)
            {
                return empresaBuscada;
            }
            return null;
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            novaEmpresa.CadastroAprovado = false;
            ctx.Empresa.Add(novaEmpresa);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresa empresaBuscada = ctx.Empresa.FirstOrDefault(a => a.IdEmpresa == id);
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == empresaBuscada.IdUsuario);
            if (empresaBuscada.IdUsuario == usuarioBuscado.IdUsuario)
            {
                ctx.Usuario.Remove(usuarioBuscado);
                ctx.Empresa.Remove(empresaBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Empresa> Listar()
        {
            return ctx.Empresa
                .Select(e => new Empresa() 
                { 
                    IdEmpresa = e.IdEmpresa,
                    RazaoSocial = e.RazaoSocial,
                    NomeFantasia = e.NomeFantasia,
                    RamoAtuacao = e.RamoAtuacao,
                    TamanhoEmpresa = e.TamanhoEmpresa,
                    Cnpj = e.Cnpj,
                    Cnae = e.Cnae,
                    CadastroAprovado = e.CadastroAprovado,
                    PessoaResponsavel = e.PessoaResponsavel,
                    VagasTotais = e.VagasTotais,
                    VagasDisponiveis = e.VagasDisponiveis,
                    VagasEncerradas = e.VagasEncerradas,

                    IdUsuarioNavigation = new Usuario()
                    {
                        IdUsuario = e.IdUsuarioNavigation.IdUsuario,
                        Email = e.IdUsuarioNavigation.Email,
                        Senha = e.IdUsuarioNavigation.Senha,
                        Endereco = e.IdUsuarioNavigation.Endereco,
                        Telefone = e.IdUsuarioNavigation.Telefone,
                        Celular = e.IdUsuarioNavigation.Celular,
                        EmailContato = e.IdUsuarioNavigation.EmailContato,
                        DataCadastro = e.IdUsuarioNavigation.DataCadastro
                    }
                })
                .ToList();
        }

        public List<Empresa> ListarEmpresasAprovadas(bool status)
        {
            return ctx.Empresa
                .Select(e => new Empresa()
                {
                    IdEmpresa = e.IdEmpresa,
                    RazaoSocial = e.RazaoSocial,
                    NomeFantasia = e.NomeFantasia,
                    RamoAtuacao = e.RamoAtuacao,
                    TamanhoEmpresa = e.TamanhoEmpresa,
                    Cnpj = e.Cnpj,
                    Cnae = e.Cnae,
                    CadastroAprovado = e.CadastroAprovado,
                    PessoaResponsavel = e.PessoaResponsavel,
                    VagasTotais = e.VagasTotais,
                    VagasDisponiveis = e.VagasDisponiveis,
                    VagasEncerradas = e.VagasEncerradas,

                    IdUsuarioNavigation = new Usuario()
                    {
                        IdUsuario = e.IdUsuarioNavigation.IdUsuario,
                        Email = e.IdUsuarioNavigation.Email,
                        Senha = e.IdUsuarioNavigation.Senha,
                        Endereco = e.IdUsuarioNavigation.Endereco,
                        Telefone = e.IdUsuarioNavigation.Telefone,
                        Celular = e.IdUsuarioNavigation.Celular,
                        EmailContato = e.IdUsuarioNavigation.EmailContato,
                        DataCadastro = e.IdUsuarioNavigation.DataCadastro
                    }
                })
                .ToList().FindAll(e => e.CadastroAprovado == status);
        }

        public List<Empresa> ListarPorOrdemAlfabetica()
        {
            return ctx.Empresa
               //.Include(e => e.IdUsuarioNavigation)
               .OrderBy(e => e.NomeFantasia)

               .ToList();
        }

        public Empresa Login(string email, string senha)
        {
                Empresa empresaBuscado = ctx.Empresa
                // Busca as informações referentes ao tipo de usuário
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefault(a => a.IdUsuarioNavigation.Email == email && a.IdUsuarioNavigation.Senha == senha);

            // Verifica se o usuário foi encontrado
            if (empresaBuscado != null)
            {
                // Retorna o usuário encontrado
                return empresaBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        public void Reprovar(int id, bool respostaVerificacao)
        {
            respostaVerificacao = false;
            Empresa empresaBuscada = ctx.Empresa.Find(id);

            if (empresaBuscada != null)
            {
                if (empresaBuscada.CadastroAprovado == false)
                {
                    empresaBuscada.CadastroAprovado = respostaVerificacao;
                }
            }
        }
    }
}
