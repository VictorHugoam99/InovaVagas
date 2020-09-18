using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, Administrador administradorAtualizado)
        {
            Administrador administradorBuscado = ctx.Administrador.FirstOrDefault(a => a.IdAdministrador == id);
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == administradorBuscado.IdUsuario);
            administradorBuscado.IdUsuarioNavigation = usuarioBuscado;

            if (administradorBuscado != null)
            {
                if (administradorAtualizado.NomeAdministrador != null)
                {
                    administradorBuscado.NomeAdministrador = administradorAtualizado.NomeAdministrador;
                }

                if (administradorAtualizado.IdUsuarioNavigation.Email != null)
                {
                    administradorBuscado.IdUsuarioNavigation.Email = administradorAtualizado.IdUsuarioNavigation.Email;
                }

                if (administradorAtualizado.IdUsuarioNavigation.Senha != null)
                {
                    administradorBuscado.IdUsuarioNavigation.Senha = administradorAtualizado.IdUsuarioNavigation.Senha;
                }

                if (administradorAtualizado.IdUsuarioNavigation.EmailContato != null)
                {
                    administradorBuscado.IdUsuarioNavigation.EmailContato = administradorAtualizado.IdUsuarioNavigation.EmailContato;
                }

                if (administradorAtualizado.IdUsuarioNavigation.Endereco != null)
                {
                    administradorBuscado.IdUsuarioNavigation.Endereco = administradorAtualizado.IdUsuarioNavigation.Endereco;
                }

                if (administradorAtualizado.IdUsuarioNavigation.Telefone != null)
                {
                    administradorBuscado.IdUsuarioNavigation.Telefone = administradorAtualizado.IdUsuarioNavigation.Telefone;
                }

                if (administradorAtualizado.IdUsuarioNavigation.Celular != null)
                {
                    administradorBuscado.IdUsuarioNavigation.Celular = administradorAtualizado.IdUsuarioNavigation.Celular;
                }

                ctx.Administrador.Update(administradorBuscado);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Administrador novoAdministrador)
        {
            //ctx.Administrador.Add(novoAdministrador);
            //ctx.SaveChanges();

            if (novoAdministrador.NomeAdministrador != null && novoAdministrador.IdUsuarioNavigation.Email != null && novoAdministrador.IdUsuarioNavigation.Senha != null)
            {
                ctx.Administrador.Add(novoAdministrador);
                ctx.SaveChanges();
            }
        }
            
        public void Excluir(int id)
        {
            Administrador administradorBuscado = ctx.Administrador.FirstOrDefault(a => a.IdAdministrador == id);
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.IdUsuario == administradorBuscado.IdUsuario);
            if (administradorBuscado.IdUsuario == usuarioBuscado.IdUsuario)
            {
                ctx.Usuario.Remove(usuarioBuscado);
                ctx.Administrador.Remove(administradorBuscado);
                ctx.SaveChanges();
            }
        }

        public Administrador BuscarPorId(int id)
        {
            Administrador administradorBuscado = ctx.Administrador.Include(a => a.IdUsuarioNavigation).FirstOrDefault(a => a.IdAdministrador == id);

            if (administradorBuscado != null)
            {
                return administradorBuscado;
            }

            return null;
        }

        public List<Administrador> ListarTodos()
        {
            //return ctx.Administrador.Include(a => a.IdUsuarioNavigation.Email).ToList();

            return ctx.Administrador
                .Select(a => new Administrador()
                {
                    IdAdministrador = a.IdAdministrador,
                    NomeAdministrador = a.NomeAdministrador,

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
                    }
                })
                .ToList();
        }

        public Administrador Login(string email, string senha)
        {
            Administrador administradorBuscado = ctx.Administrador
                // Busca as informações referentes ao tipo de usuário
                .Include(a => a.IdUsuarioNavigation)
                .FirstOrDefault(a => a.IdUsuarioNavigation.Email == email && a.IdUsuarioNavigation.Senha == senha);

            // Verifica se o usuário foi encontrado
            if (administradorBuscado != null)
            {
                // Retorna o usuário encontrado
                return administradorBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }
    }
}
