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
    public class FormaContratacaoController : ControllerBase
    {
        private IFormaContratacaoRepository _formaContratacaoRepository;

        public FormaContratacaoController()
        {
            _formaContratacaoRepository = new FormaContratacaoRepository();
        }

        /// <summary>
        /// lista todas as formas de contratação
        /// </summary>
        /// <returns>Ok(Lista)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_formaContratacaoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// inscreve uma nova forma de contratação
        /// </summary>
        /// <param name="novaFormaContratacao"></param>
        /// <returns>Created(novaFormaContratacao)</returns>
        [HttpPost]
        public IActionResult Post(FormaContratacao novaFormaContratacao)
        {
            if (novaFormaContratacao != null)
            {
                try
                {
                    _formaContratacaoRepository.Cadastrar(novaFormaContratacao);

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
        /// atualiza os dados de uma forma de contratacao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formaContratacaoAtualizada"></param>
        /// <returns>NoContent(formaContratacaoAtualizada)</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, FormaContratacao formaContratacaoAtualizada)
        {
            try
            {
                FormaContratacao formaContratacaoBuscada = _formaContratacaoRepository.BuscarPorId(id);

                if (formaContratacaoBuscada != null)
                {
                    _formaContratacaoRepository.Atualizar(id, formaContratacaoAtualizada);

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
        /// exclui uma forma de contratacao pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                FormaContratacao fcBuscada = _formaContratacaoRepository.BuscarPorId(id);

                if (fcBuscada != null)
                {
                    _formaContratacaoRepository.Deletar(id);

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