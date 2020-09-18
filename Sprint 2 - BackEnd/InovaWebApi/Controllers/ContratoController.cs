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
    public class ContratoController : ControllerBase
    {
        IContratoRepository _contratoRepository;

        public ContratoController()
        {
            _contratoRepository = new ContratoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_contratoRepository.ListarTodos());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Contrato contratoBuscado = _contratoRepository.ListarPorId(id);
                if (contratoBuscado != null)
                {
                    return Ok(contratoBuscado);
                }
                return NotFound("Contrato não encontrada");

            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        [HttpPost]
        public IActionResult Post(Contrato novoContrato)
        {
            try
            {
                if (novoContrato != null)
                {
                    Convert.ToDateTime(novoContrato.DataInicio);
                    Convert.ToDateTime(novoContrato.DataTermino);
                    _contratoRepository.Cadastrar(novoContrato);

                    return StatusCode(201);
                }

                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Contrato contratoAtualizado)
        {
            try
            {
                Contrato contratoBuscado = _contratoRepository.ListarPorId(id);

                if (contratoBuscado != null)
                {
                    _contratoRepository.Atualizar(id, contratoAtualizado);

                    return StatusCode(204);
                }

                return NotFound("Contrato informado não existe");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Contrato contratoBuscado = _contratoRepository.ListarPorId(id);

                if (contratoBuscado != null)
                {
                    _contratoRepository.Excluir(id);

                    return Ok($"O contrato {id} foi deletado com sucesso");
                }

                return NotFound("Contrato informado não existe");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }
    }
}
