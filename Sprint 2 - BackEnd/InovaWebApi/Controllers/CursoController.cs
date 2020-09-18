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
    public class CursoController : ControllerBase
    {
        private ICursoRepository _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_cursoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e);

            }
        }

        [HttpPost]
        public IActionResult Post(Curso novoCurso)
        {
            if (novoCurso != null)
            {
                try
                {
                    _cursoRepository.Cadastrar(novoCurso);

                    return StatusCode(201);
                
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return NotFound("Não foi fornecido nenhum valor para ser cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Curso cursoAtualizado)
        {
            Curso cursoBuscado = _cursoRepository.BuscarPorId(id);

            try
            {
                if (cursoBuscado != null)
                {
                    _cursoRepository.Atualizar(id, cursoAtualizado);

                    return NoContent();
                }

                return NotFound("O identificador informado não existe");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Curso cursoBuscado = _cursoRepository.BuscarPorId(id);

            try
            {
                if (cursoBuscado == null)
                {
                    return NotFound("O identificdor informado não existe");
                }

                _cursoRepository.Deletar(id);
                return Ok($"O curso {id} foi deletado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
