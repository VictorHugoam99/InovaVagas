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
    // Controller responsável pelos endpoints referentes aos generos
    [Authorize]
    //gerar resposta json
    [Produces("application/json")]
    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]
    // Define que é um controlador de API
    [ApiController]
    public class GeneroController : ControllerBase
    {
        /// Cria um objeto _generoRepository que irá receber todos os métodos definidos na interface
        private IGeneroRepository _generoRepository { get; set; }

        ///Instancia este objeto para que haja a referência aos métodos no repositório
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Caso seja encontrado, retorna o gênero buscado
                return Ok(_generoRepository.Listar());
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }


        }

        // Cadastra um novo gênero
        /// <param name = "novoGenero " > Objeto genero recebido na requisição </param>
        // Retorna um status code 201 Created
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Genero novoGenero)
        {
            try
            {
                // Faz a chamada para o método .Cadastrar();
                _generoRepository.Cadastrar(novoGenero);
                // Retorna um status code 201 - Created
                return StatusCode(201);

            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        // Busca um gênero através do seu ID
        /// <param name =" id " > ID do gênero buscado </param>
        // Retorna um gênero buscado , Por exemplo dominio/api/Generos/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                Genero generoBuscado = _generoRepository.BuscarPorId(id);
                // Caso não seja encontrado, retorna um status code 404 com a mensagem personalizada
                return NotFound("Nenhum gênero encontrado");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }
        }

        // Atualiza um gênero existente passando o ID no recurso
        /// <param name = " id " > ID do gênero que será atualizado </param>
        /// <param name = "generoAtualizado" > Objeto gênero que será atualizado </param>
        // Retorna um status code , exemplo : dominio/api/Generos/1 
        [Authorize(Roles = "Administrador")]
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, Genero generoAtualizado)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            Genero generoBuscado = _generoRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (generoBuscado == null)
            {
                // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
                // e um bool para representar que houve erro
                return NotFound
                    (
                        new
                        {
                            mensagem = "Gênero não encontrado",
                            erro = true
                        }
                    );
            }
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl();
                _generoRepository.Atualizar(id, generoAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna BadRequest e o erro
                return BadRequest(erro);
            }
        }

        /// Deleta um gênero passando o ID
        /// <param name="id">ID do gênero que será deletado</param>
        /// Retorna um status code com uma mensagem personalizada 
        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método .Deletar();
                _generoRepository.Deletar(id);
                // Retorna um status code com uma mensagem personalizada
                return Ok("Gênero deletado");
            }
            catch (Exception error)
            {

                return BadRequest(error);
            }

        }

    }
}
