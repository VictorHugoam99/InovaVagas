using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using InovaWebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AreaVagaController : ControllerBase
    {
        private IAreaVagaRepository _areaVagaRepository { get; set; }

        public AreaVagaController()
        {
            _areaVagaRepository = new AreaVagaRepository();
        }

        /// <summary>
        /// Retorna todas as Areas.
        /// </summary>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_areaVagaRepository.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Retorna uma area por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Area Object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (_areaVagaRepository.GetById(id) != null)
                {
                    return Ok(_areaVagaRepository.GetById(id));
                }

                return NotFound("AreaVaga não encontrada");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Cadastra uma area.
        /// </summary>
        /// <param name="areaVaga"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<Area>
        [HttpPost]
        public IActionResult Post(AreaVaga areaVaga)
        {
            try
            {
                _areaVagaRepository.Add(areaVaga);
                return Ok("Area cadastrada com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar area.");
            }
        }

        /// <summary>
        /// Atualiza uma area passando o seu id na url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="areaVaga"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // PUT api/<AreaVaga>/5
        [HttpPut("{id}")]

        public IActionResult Put(int id, AreaVaga areaVaga)
        {
            try
            {
                AreaVaga areaVagaAtualizada = new AreaVaga
                {
                    IdAreaVaga = id,
                    NomeAreaVaga = areaVaga.NomeAreaVaga
                };

                _areaVagaRepository.Update(id, areaVagaAtualizada);
                return Ok("Area atualizada.");

            }
            catch
            {
                return BadRequest("Erro ao atualizar a area");

            }
        }
        /// <summary>
        /// Deleta uma area
        /// </summary>
        /// <param name="id">ID da area que será deletada</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                AreaVaga areaVagaBuscada = _areaVagaRepository.GetById(id);
                _areaVagaRepository.Delete(id);
                return Ok("Area deletada.");
            }
            catch
            {
                return BadRequest("Erro ao deletar.");
            }
        }
    }
}