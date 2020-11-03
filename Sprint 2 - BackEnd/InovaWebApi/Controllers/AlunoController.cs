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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private IAlunoRepository _alunoRepository { get; set; }

        public AlunoController()
        {
            _alunoRepository = new AlunoRepository();
        }

        /// <summary>
        /// Retorna todos os alunos.
        /// </summary>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize(Roles= "Administrador, Empresa")]
        // GET: api/<Aluno>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_alunoRepository.GetAll());
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Retorna um aluno por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Aluno Object</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Authorize]
        // GET api/<Aluno>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Aluno alunoBuscado = _alunoRepository.GetById(id);

            try
            {
                if (alunoBuscado != null)
                {
                    return Ok(_alunoRepository.GetById(id));
                }

                return NotFound("Aluno especificado não existe");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }            
        }

        /// <summary>
        /// Cadastra um aluno.
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // POST api/<Aluno>
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            try
            {
                _alunoRepository.Add(aluno);
                return Ok("Aluno cadastrado com sucesso");
            }
            catch
            {
                return BadRequest("Erro ao cadastrar aluno.");
            }
        }

        /// <summary>
        /// Atualiza um aluno passando o seu id na url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="aluno"></param>
        /// <returns>null</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador, Aluno")]
        // PUT api/<Aluno>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            try
            {
                _alunoRepository.Update(id, aluno);
                return Ok("Aluno atualizado.");

            }
            catch
            {
                return BadRequest("Erro ao atualizar o aluno ");

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Administrador, Aluno")]
        //dominio/api/Aluno/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Aluno alunoBuscado = _alunoRepository.GetById(id);
                //if (alunoBuscado != null)
                //{
                //    _alunoRepository.Delete(id)
                //}
                _alunoRepository.Delete(id);
                return Ok("Aluno Deletado.");
            }
            catch
            {
                return BadRequest("Erro ao deletar.");
            }
        }
    }
}
