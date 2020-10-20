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
    //gerar resposta json
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidaturaController : ControllerBase
    {
        private ICandidaturaRepository _candidaturaRepository { get; set; }

        public CandidaturaController()
        {
            _candidaturaRepository = new CandidaturaRepository();
        }

        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Empresa")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Caso seja encontrado, retorna o candidatura buscado
                return Ok(_candidaturaRepository.GetAll());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [Authorize(Roles = "Administrador")]
        [Authorize(Roles = "Empresa")]
        [Authorize(Roles = "Aluno")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Candidatura candidaturaBuscado = _candidaturaRepository.GetById(id);
                if (candidaturaBuscado != null)
                {
                    return Ok(candidaturaBuscado);
                }
                return NotFound("Candidatura não encontrada");

            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

        //Cadastro
        [Authorize(Roles = "Aluno")]
        [HttpPost]
        public IActionResult Post(Candidatura candidatura)
        {
            try
            {
                _candidaturaRepository.Add(candidatura);
                return Ok();

            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        //Atualiza
        [HttpPut("{id}")]
        public IActionResult Put(int id, Candidatura candidatura)
        {
            try
            {
                Candidatura candidaturaBuscada = _candidaturaRepository.GetById(id);
                if (candidaturaBuscada != null)
                {
                    Candidatura candidaturaAtualizada = new Candidatura
                    {
                        Contratado = candidatura.Contratado,
                        IdStatusCandidatura = candidatura.IdStatusCandidatura
                    };

                    _candidaturaRepository.Update(id, candidaturaAtualizada);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        //Deletar uma candidatura 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Candidatura candidaturaBuscado = _candidaturaRepository.GetById(id);
                if (candidaturaBuscado != null)
                {
                    _candidaturaRepository.Delete(id);
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
