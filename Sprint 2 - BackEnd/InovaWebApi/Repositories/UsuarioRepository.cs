using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();
        AdministradorRepository _administradorRepository = new AdministradorRepository();
        AlunoRepository _alunoRepository = new AlunoRepository();
        EmpresaRepository _empresaRepository = new EmpresaRepository();


        public Usuario BuscarPorId(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(a => a.IdUsuario == id);

            if (usuarioBuscado != null)
            {
                return usuarioBuscado;
            }

            return null;
        }

        public int Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
            return ctx.Usuario.FirstOrDefault(u => u.Email == novoUsuario.Email).IdUsuario;
        }

        public void Excluir(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);
            ctx.Usuario.Remove(usuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodos()
        {
            return ctx.Usuario.ToList();
        }

        public Object VerificarTipoUsuario(string email, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            List<Administrador> administradores = _administradorRepository.ListarTodos();
            List<Aluno> alunos = _alunoRepository.GetAll();
            List<Empresa> empresas = _empresaRepository.Listar();

            if (usuarioBuscado != null)
            {
                foreach (var tipoUsuario in administradores)
                {
                    if (usuarioBuscado.Email == tipoUsuario.IdUsuarioNavigation.Email &&
                        usuarioBuscado.Senha == tipoUsuario.IdUsuarioNavigation.Senha)
                    {
                        return tipoUsuario;
                    }
                }

                foreach (var tipoUsuario in alunos)
                {
                    if (usuarioBuscado.Email == tipoUsuario.IdUsuarioNavigation.Email &&
                        usuarioBuscado.Senha == tipoUsuario.IdUsuarioNavigation.Senha)
                    {
                        return tipoUsuario;
                    }
                }

                foreach (var tipoUsuario in empresas)
                {
                    if (usuarioBuscado.Email == tipoUsuario.IdUsuarioNavigation.Email && 
                        usuarioBuscado.Senha == tipoUsuario.IdUsuarioNavigation.Senha)
                    {
                        return tipoUsuario;
                    }
                }
            }

            return null;
        }

        //public Usuario Login(string email, string senha)
        //{

        //}
    }
}
