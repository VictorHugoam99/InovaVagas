using InovaWebApi.Domains;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IAreaVagaRepository
    {

        /// <summary>
        /// Lista todas as areas
        /// </summary>
        /// <returns>Uma lista das areas</returns>
        List<AreaVaga> GetAll();

        /// <summary>
        /// Busca uma area por ID
        /// </summary>
        /// <param name="id">ID da vaga que será buscada</param>
        /// <returns>Uma area vaga buscada</returns>
        AreaVaga GetById(int id);

        /// <summary>
        /// Cadastra uma nova area 
        /// </summary>
        /// <param name="AreaVaga">Objeto com as informações de cadastro</param>
        void Add(AreaVaga AreaVaga);

        /// <summary>
        /// Atualiza uma area vaga existente
        /// </summary>
        /// <param name="id">ID da area vaga que será atualizada</param>
        /// <param name="areaVagaAtualizada">Objeto com as novas informações</param>
        void Update(int id, AreaVaga areaVagaAtualizada);

        /// <summary>
        /// Deleta uma area
        /// </summary>
        /// <param name="id">ID da area que será deletada</param>
        void Delete(int id);
    }
}