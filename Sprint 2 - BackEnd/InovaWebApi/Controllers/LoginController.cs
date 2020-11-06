using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using InovaWebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InovaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IUsuarioRepository _usuarioRepository;
        IAdministradorRepository _administradorRepository;
        IAlunoRepository _alunoRepository;
        IEmpresaRepository _empresaRepository;

        public LoginController()
        {
            _administradorRepository = new AdministradorRepository();
            _usuarioRepository = new UsuarioRepository();
            _alunoRepository = new AlunoRepository();
            _empresaRepository = new EmpresaRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                var usuarioGenerico = _usuarioRepository.VerificarTipoUsuario(login.Email, login.Senha);

                string tipoRole;
                if (usuarioGenerico != null)
                {
                    if (usuarioGenerico is Administrador)
                    {
                        tipoRole = "Administrador";
                        Administrador administradorBuscado = _administradorRepository.Login(login.Email, login.Senha);

                        return Ok(CriacaoToken(administradorBuscado.IdUsuarioNavigation.Email, Convert.ToInt32(administradorBuscado.IdAdministrador), tipoRole));
                    }
                    if (usuarioGenerico is Aluno)
                    {
                        tipoRole = "Aluno";
                        Aluno alunoBuscado = _alunoRepository.Login(login.Email, login.Senha);

                        return Ok(CriacaoToken(alunoBuscado.IdUsuarioNavigation.Email, Convert.ToInt32(alunoBuscado.IdAluno), tipoRole));
                    }
                    if (usuarioGenerico is Empresa)
                    {
                        tipoRole = "Empresa";
                        Empresa empresaBuscado = _empresaRepository.Login(login.Email, login.Senha);

                        return Ok(CriacaoToken(empresaBuscado.IdUsuarioNavigation.Email, Convert.ToInt32(empresaBuscado.IdEmpresa), tipoRole));
                    }
                    else
                    {
                        return NotFound("Email ou senha inválidos");
                    }
                }
                else
                {
                    return NotFound("Usuário Informado não existe");
                }
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

        [NonAction]
        private IActionResult CriacaoToken(string email, int id, string tipoRole)
        {
            try
            {
                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, id.ToString()),

                    // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                    new Claim(ClaimTypes.Role, tipoRole),

                    new Claim("Role", tipoRole),

                    new Claim("Id", id.ToString())

                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Inova-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "InovaWebApi",                 // emissor do token
                    audience: "InovaWebApi",               // destinatário do token
                    claims: claims,                        // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),  // tempo de expiração
                    signingCredentials: creds              // credenciais do token
                );

                // Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception error)
            {
                return BadRequest(new
                {
                    mensagem = "Não foi possível gerar o token",
                    error
                });
            }
        }
    }
}
