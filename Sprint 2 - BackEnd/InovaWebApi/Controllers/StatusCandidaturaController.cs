using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InovaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCandidaturaController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private IStatusCandidaturaRepository _statusCandidaturaRepository;

        /// <summary>
        /// 
        /// </summary>
        public StatusCandidaturaController()
        {
            _statusCandidaturaRepository = new StatusCandidaturaRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_statusCandidaturaRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            try
            {
                StatusCandidatura statusCandidaturaBuscado = _statusCandidaturaRepository.BuscarPorId(id);

                if (statusCandidaturaBuscado != null)
                {
                    return Ok(statusCandidaturaBuscado);
                }

                return NotFound("Nenhum status de candidatura foi encontrado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoStatusCandidatura"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(StatusCandidatura novoStatusCandidatura)
        {
            try
            {
                _statusCandidaturaRepository.Cadastrar(novoStatusCandidatura);

                return StatusCode(201);
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
        /// <param name="statusCandidaturaAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, StatusCandidatura statusCandidaturaAtualizado)
        {
            try
            {
                StatusCandidatura statusCandidaturaBuscado = _statusCandidaturaRepository.BuscarPorId(id);

                if (statusCandidaturaBuscado != null)
                {
                    _statusCandidaturaRepository.Atualizar(id, statusCandidaturaAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Nenhum status de candidatura foi encontrado.");
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
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                StatusCandidatura statusCandidaturaBuscado = _statusCandidaturaRepository.BuscarPorId(id);

                if (statusCandidaturaBuscado != null)
                {
                    _statusCandidaturaRepository.Excluir(id);

                    return StatusCode(202);
                }

                return NotFound("Nenhum status de candidatura foi encontrado.");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
