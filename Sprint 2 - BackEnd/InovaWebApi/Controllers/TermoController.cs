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
    public class TermoController : ControllerBase
    {
        private ITermoRepository _termoRepository;

        public TermoController()
        {
            _termoRepository = new TermoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_termoRepository.Listar());
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
                return Ok(_termoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        //[Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Termo novoTermo)
        {
            try
            {
                _termoRepository.Cadastrar(novoTermo);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }

        }

        //[Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int Id, Termo termoAtualizado)
        {
            try
            {
                _termoRepository.Atualizar(Id, termoAtualizado);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }

        }

        //[Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _termoRepository.Deletar(Id);
                return StatusCode(204);

            }
            catch (Exception e)
            {
                return BadRequest(e);

            }

        }
    }
}