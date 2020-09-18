using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IStatusContratoRepository
    {
        /// <summary>
        /// Lista todos os status de contrato
        /// </summary>
        /// <returns> lista de todos os estatus de contrato </returns>
        List<StatusContrato> Listar();

        /// <summary>
        /// Cadastra novos status de contrato
        /// </summary>
        /// <param name="novoStatusContrato"></param>
        void Cadastrar(StatusContrato novoStatusContrato);

        /// <summary>
        /// busca um status de contrato por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        StatusContrato BuscarPorId(int id);

        /// <summary>
        /// Atualiza status de contrato
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusContratoAtualizado"></param>
        void Atualizar(int id, StatusContrato statusContratoAtualizado);

        /// <summary>
        /// Remove um status de contrato
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

    }
}