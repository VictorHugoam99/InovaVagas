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
    public class CurriculoController : ControllerBase
    {
        private ICurriculoRepository _curriculoRepository;

        public CurriculoController()
        {
            _curriculoRepository = new CurriculoRepository();
        }

        /// <summary>
        /// lista todos os curriculos
        /// </summary>
        /// <returns>Ok(Lista de curriculos)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_curriculoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        /// <summary>
        /// inscreve um novo curriculo
        /// </summary>
        /// <param name="novoCurriculo"></param>
        /// <returns>Created(novoCurriculo)</returns>
        [HttpPost]
        public IActionResult Post(Curriculo novoCurriculo)
        {
            if (novoCurriculo != null)
            {
                try
                {
                    _curriculoRepository.Cadastrar(novoCurriculo);

                    return StatusCode(201);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest("Não foi informado nenhum valor para ser cadastrado");
        }

        /// <summary>
        /// altera um curriculo existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curriculoAtualizado"></param>
        /// <returns>NoContent(curriculoAtualizado)</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Curriculo curriculoAtualizado)
        {
            try
            {
                Curriculo cBuscado = _curriculoRepository.BuscarPorId(id);

                if (cBuscado != null)
                {
                    _curriculoRepository.Atualizar(id, curriculoAtualizado);

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
        /// exclui um curriculo existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent()</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Curriculo cBuscado = _curriculoRepository.BuscarPorId(id);

                if (cBuscado != null)
                {
                    _curriculoRepository.Excluir(id);

                    return StatusCode(202);
                }

                return NotFound("O identificador informado não existe");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
