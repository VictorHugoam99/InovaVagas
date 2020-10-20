using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovaWebApi.Controllers
{
    //[Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IAdministradorRepository _administradorRepository;

        /// <summary>
        /// 
        /// </summary>
        public AdministradorController()
        {
            _administradorRepository = new AdministradorRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_administradorRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.BuscarPorId(id);

                if (administradorBuscado != null)
                {
                    return Ok(administradorBuscado);
                }

                return NotFound("Nenhum administrador foi encontrado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoAdministrador"></param>
        /// <returns></returns>
        [Authorize(Roles ="Administrador")]
        [HttpPost]
        public IActionResult Post(Administrador novoAdministrador)
        {
            try
            {
                if (novoAdministrador != null)
                {
                    _administradorRepository.Cadastrar(novoAdministrador);
                    return StatusCode(201);
                }

                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="administradorAtualizado"></param>
        /// <returns></returns>
        [Authorize(Roles ="Administrador")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Administrador administradorAtualizado)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.BuscarPorId(id);

                if (administradorBuscado != null)
                {
                    _administradorRepository.Atualizar(id, administradorAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum administrador foi encontrado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize("Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Administrador administradorBuscado = _administradorRepository.BuscarPorId(id);

                if (administradorBuscado != null)
                {
                    _administradorRepository.Excluir(id);

                    return Ok($"O administrador {id} foi deletado com sucesso");
                }

                return NotFound("Nenhum administrador foi encontrado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
