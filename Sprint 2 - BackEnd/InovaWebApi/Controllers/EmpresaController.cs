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
    public class EmpresaController : ControllerBase
    {
        private IEmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }


        //[Authorize(Roles = "1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Empresa novaEmpresa)
        {
           
            try
            {
                _empresaRepository.Cadastrar(novaEmpresa);

                return StatusCode(201);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [HttpPut]
        public IActionResult AprovarEmpresa(int id)
        {
            try
            {
                Empresa empresaBuscada = _empresaRepository.BuscarPorId(id);

                if (empresaBuscada != null)
                {
                    _empresaRepository.Aprovar(id);

                    return StatusCode(204);
                }

                return NotFound("Nenhuma empresa encontrada para o ID informado");
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [Authorize(Roles = "Administrador, Aluno")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_empresaRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest( error);
            }            
        }

        [Authorize(Roles = "Administrador, Empresa")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_empresaRepository.BuscarPorId(id));
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            
        }

        [Authorize(Roles = "Empresa")]
        [HttpPut("{id}")]
        public IActionResult Put(int id,  Empresa empresaAtualizada)
        {
            try
            {
                _empresaRepository.Atualizar(id, empresaAtualizada);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
            
        }

        [Authorize(Roles = "Administrador, Empresa")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _empresaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        [Authorize]
        [HttpGet("OrdemAlfabetica")]
        public IActionResult GetByAlphabetical()
        {
            try
            {
                return Ok(_empresaRepository.ListarPorOrdemAlfabetica());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }
    }
}
