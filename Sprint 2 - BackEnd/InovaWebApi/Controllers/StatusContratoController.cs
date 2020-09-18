using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InovaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusContratoController : ControllerBase
    {
        private IStatusContratoRepository _statusContratoRepository;

        public StatusContratoController()
        {
            _statusContratoRepository = new StatusContratoRepository();
        }

        /// <summary>
        /// lista todos os status de contrato
        /// </summary>
        /// <returns>Ok(lista)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_statusContratoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// cadastra um novo status contrato
        /// </summary>
        /// <param name="novoStatusContrato"></param>
        /// <returns>Created(novoStatusContrato)</returns>
        [HttpPost]
        public IActionResult Post(StatusContrato novoStatusContrato)
        {
            if (novoStatusContrato != null)
            {
                try
                {
                    _statusContratoRepository.Cadastrar(novoStatusContrato);

                    return StatusCode(201);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return NotFound("Não foi encontrado nenhum valor para cadastrar");
        }

        /// <summary>
        /// atuaiza os dados de um status contrato
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusContratoAtualizado"></param>
        /// <returns>NoContent(statusContartoAtualizado)</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, StatusContrato statusContratoAtualizado)
        {
            try
            {
                StatusContrato scBuscado = _statusContratoRepository.BuscarPorId(id);

                if (scBuscado != null)
                {
                    _statusContratoRepository.Atualizar(id, statusContratoAtualizado);

                    return NoContent();
                }

                return NotFound("O identificador informado não existe");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// exclui um status de contrato
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                StatusContrato scBuscado = _statusContratoRepository.BuscarPorId(id);

                if (scBuscado == null)
                {
                    return NotFound("O identificador informado não existe");
                }

                _statusContratoRepository.Deletar(id);

                return StatusCode(202);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}