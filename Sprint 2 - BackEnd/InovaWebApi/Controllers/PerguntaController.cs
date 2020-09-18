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
    public class PerguntaController : ControllerBase
    {
        private IPerguntaRepository _perguntaRepository;

        public PerguntaController()
        {
            _perguntaRepository = new PerguntaRepository();
        }

        /// <summary>
        /// lista todas as perguntas
        /// </summary>
        /// <returns>Ok(lista)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_perguntaRepository.Listar());

            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }

        /// <summary>
        /// isncreve uma nova pergunta
        /// </summary>
        /// <param name="novaPergunta"></param>
        /// <returns>Created(novaPergunta)</returns>
        [HttpPost]
        public IActionResult Post(Pergunta novaPergunta)
        {
            if (novaPergunta != null)
            {
                try
                {
                    _perguntaRepository.Cadastrar(novaPergunta);

                    return StatusCode(201);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return NotFound("Não foi encontrdo nenhum valor para cadastrar");
        }

        /// <summary>
        /// atualiza os dados de uma pergunta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="perguntaAtualizada"></param>
        /// <returns>NoContent(perguntaAtualizada)</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pergunta perguntaAtualizada)
        {
            try
            {
                Pergunta perguntaBuscada = _perguntaRepository.BuscarPorId(id);

                if (perguntaBuscada != null)
                {
                    _perguntaRepository.Atualizar(id, perguntaAtualizada);

                    return StatusCode(204);
                }

                return NotFound("O identificador informado não existe");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// exclui uma pergunta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Pergunta perguntaBuscada = _perguntaRepository.BuscarPorId(id);

                if (perguntaBuscada != null)
                {
                    _perguntaRepository.Excluir(id);

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