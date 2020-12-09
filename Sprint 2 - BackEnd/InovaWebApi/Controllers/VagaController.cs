using System;
using System.Collections.Generic;
using System.Linq;
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
    public class VagaController : ControllerBase
    {
        private IVagaRepository _vagaRepository;

        public VagaController()
        {
            _vagaRepository = new VagaRepository();
        }

        /// <summary>
        /// lista todas as vagas ativas
        /// </summary>
        /// <returns>Ok(lista)</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_vagaRepository.Listar());
        }

        /// <summary>
        /// lista vagas pelo nome
        /// </summary>
        /// <param name="nomeVaga"></param>
        /// <returns>Ok(lista)</returns>
        [HttpGet("nomeVaga/{nomeVaga}")]
        public IActionResult GetByName(string nomeVaga)
        {
            try
            {
                return Ok(_vagaRepository.ListarPorNome(nomeVaga));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
             {
                Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);

                if (vagaBuscada != null)
                {
                    return Ok(vagaBuscada);
                }

                return NotFound("Nenhuma vaga foi encontrada");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// lista vagas por endereco
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns>Ok(lista)</returns>
        [HttpGet("endereco/{endereco}")]
        public IActionResult GetByAdress(string endereco)
        {
            try
            {
                return Ok(_vagaRepository.ListarPorEndereco(endereco));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// lista vagas pelo salario
        /// </summary>
        /// <param name="salario"></param>
        /// <returns>Ok(lista)</returns>
        [HttpGet("salario/{salario}")]
        public IActionResult GetByPayment(string salario)
        {
            try
            {
                return Ok(_vagaRepository.ListarPorSalario(salario));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// lista vagas pela empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns>Ok(lista)</returns>
        [HttpGet("empresa/{idEmpresa}")]
        public IActionResult GetByCompany(int idEmpresa)
        {
            try
            {
                return Ok(_vagaRepository.ListarPorEmpresa(idEmpresa));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        /// <summary>
        /// inscreve uma nova vaga
        /// </summary>
        /// <param name="novaVaga"></param>
        /// <returns>Created(novaVaga)</returns>
        [HttpPost]
        public IActionResult Post(Vaga novaVaga)
        {
            if (novaVaga != null)
            {
                try
                {
                    _vagaRepository.Cadastrar(novaVaga);

                    return StatusCode(201);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return NotFound("Não há valor para se cadastrar");
        }

        /// <summary>
        /// atualiza os dados de uma vaga 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vagaAtualizada"></param>
        /// <returns>NoContent(vagaAtualizada)</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Vaga vagaAtualizada)
        {
            try
            {
                Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);

                if (vagaBuscada != null)
                {
                    _vagaRepository.Atualizar(id, vagaAtualizada);

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
        /// exclui uma vaga 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Vaga vagaBuscada = _vagaRepository.BuscarPorId(id);

                if (vagaBuscada != null)
                {
                    _vagaRepository.Excluir(id);

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