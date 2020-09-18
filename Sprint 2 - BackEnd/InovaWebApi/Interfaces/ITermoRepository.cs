using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface ITermoRepository
    {
        // Lista todos os termos e retorna uma lista 
        List<Termo> Listar();

        // Cadastra um novo termo
        /// <param name = " novoTermo " > Objeto genero que será cadastrado </param>
        void Cadastrar(Termo novoTermo);

        // Atualiza um termo existente passando o id pelo corpo da requisição

        /// <param name="id"></param>
        /// <param name="termoAtualizado"></param>
        void Atualizar(int id, Termo termoAtualizado);

        // Deleta um termo
        /// <param name = " Id " > ID do termo que será deletado </param>
        void Deletar(int Id);

        // Busca um termo através do ID
        /// <param name = " Id " > ID do termo que será buscado </param>
        // Retorna um termo
        Termo BuscarPorId(int Id);

    }
}
