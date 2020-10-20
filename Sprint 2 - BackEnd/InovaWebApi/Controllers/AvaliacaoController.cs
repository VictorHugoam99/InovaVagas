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
    public class AvaliacaoController : ControllerBase
    {
        private IAvaliacaoRepository _avaliacaoRepository { get; set; }

        public AvaliacaoController()
        {
            _avaliacaoRepository = new AvaliacaoRepository();
        }

        /// <summary>
        /// Retorna todos as avaliações.
        /// </summary>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET: api/<Avaliacao>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_avaliacaoRepository.GetAll());

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// Retorna uma avaliação por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Avaliacao Object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        // GET api/<Avaliacao>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (_avaliacaoRepository.GetById(id) != null)
            {
                return Ok(_avaliacaoRepository.GetById(id));
            }
            else
            {
                return BadRequest("Avaliação não encontrada.");
            }
        }

        /// <summary>
        /// Cadastra uma avaliação.
        /// </summary>
        /// <param name="avaliacao"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<Avaliacao>
        [HttpPost]
        public IActionResult Post(Avaliacao avaliacao)
        {
            try
            {
                _avaliacaoRepository.Add(avaliacao);
                return Ok("Avaliação cadastrada com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar avaliação.");
            }
        }

        /// <summary>
        /// Atualiza um avaliação passando o seu id na url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="avaliacao"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // PUT api/<Avaliacao>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Avaliacao avaliacao)
        {
            try
            {
                Avaliacao avaliacaoAtualizada = new Avaliacao
                {
                    IdAvaliacao = id,
                    IdContrato = avaliacao.IdContrato,
                    Avaliacao1Data = avaliacao.Avaliacao1Data,
                    Avaliacao1Realizada = avaliacao.Avaliacao1Realizada,
                    Avaliacao2Data = avaliacao.Avaliacao2Data,
                    Avaliacao2Realizada = avaliacao.Avaliacao2Realizada,
                    IdContratoNavigation = avaliacao.IdContratoNavigation,
                    VisitaTecnicaData = avaliacao.VisitaTecnicaData,
                    VisitaTecnicaRealizada = avaliacao.VisitaTecnicaRealizada,
                    Resposta = avaliacao.Resposta
                };

                _avaliacaoRepository.Update(id, avaliacaoAtualizada);
                return Ok("Avaliação atualizada.");

            }
            catch
            {
                return BadRequest("Erro ao atualizar a avaliação.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Avaliacao avaliacaoBuscada = _avaliacaoRepository.GetById(id);
                _avaliacaoRepository.Delete(id);
                return Ok("Avaliação deletada.");
            }
            catch
            {
                return BadRequest("Erro ao deletar.");
            }
        }
    }
}
