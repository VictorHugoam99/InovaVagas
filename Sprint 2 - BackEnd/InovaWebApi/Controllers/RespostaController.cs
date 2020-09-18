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
    public class RespostaController : ControllerBase
    {
        private IRespostaRepository _respostaRepository;

        public RespostaController()
        {
            _respostaRepository = new RespostaRepository();
        }

        /// <summary>
        /// lista todos as respostas 
        /// </summary>
        /// <returns>Ok(lista)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_respostaRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// cadastra novas respostas
        /// </summary>
        /// <param name="novaResposta"></param>
        /// <returns>Created(novaResposta)</returns>
        [HttpPost]
        public IActionResult Post(Resposta novaResposta)
        {
            try
            {
                if (novaResposta != null)
                {
                    _respostaRepository.Cadastrar(novaResposta);

                    return StatusCode(201);
                }

                return BadRequest("Não existe valor para ser cadastrado");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// atualiza os dados da resposta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="respostaAtualizada"></param>
        /// <returns>NoContent(respostaAtualizada)</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Resposta respostaAtualizada)
        {
            Resposta respostaBuscada = _respostaRepository.BuscarPorId(id);

            if (respostaBuscada != null)
            {
                try
                {
                    _respostaRepository.Atualizar(id, respostaAtualizada);

                    return NoContent();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return NotFound("O identificador informado não existe");
        }

        /// <summary>
        /// exclui uma resposta
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Resposta respostaBuscada = _respostaRepository.BuscarPorId(id);

            if (respostaBuscada != null)
            {
                try
                {
                    _respostaRepository.Excluir(id);

                    return StatusCode(202);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return NotFound("O identificador informado não existe");
        }
    }
}