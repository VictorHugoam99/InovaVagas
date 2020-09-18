using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IAvaliacaoRepository
    {
        /// <summary>
        /// Retorna todos as avaliações.
        /// </summary>
        /// <returns>null</returns>
        List<Avaliacao> GetAll();

        /// <summary>
        /// Retorna uma avaliação por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Avaliacao Object</returns>
        Avaliacao GetById(int id);

        /// <summary>
        /// Cadastra uma avaliação.
        /// </summary>
        /// <param name="avaliacao"></param>
        /// <returns>null</returns>
        void Add(Avaliacao avaliacao);

        /// <summary>
        /// Atualiza um avaliação passando o seu id na url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="avaliacaoAtualizada"></param>
        /// <returns>null</returns>
        void Update(int id, Avaliacao avaliacaoAtualizada);

        /// <summary>
        /// Deleta um aluno
        /// </summary>
        /// <param name="id">ID do aluno que será deletado</param>
        void Delete(int id);
    }
}