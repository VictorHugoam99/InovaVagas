using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IFormaContratacaoRepository
    {
        /// <summary>
        /// Lista todas as formas de contratação
        /// </summary>
        /// <returns> lista de todas as formas de contratação </returns>
        List<FormaContratacao> Listar();

        /// <summary>
        /// Inscreve novas formas de contratação
        /// </summary>
        /// <param name="novaFormaContratacao"></param>
        void Cadastrar(FormaContratacao novaFormaContratacao);

        /// <summary>
        /// busca um tipo de contratação por id
        /// </summary>
        FormaContratacao BuscarPorId(int id);

        /// <summary>
        /// Atualiza as formas de contratação
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formaContratacaoAtualizada"></param>
        void Atualizar(int id, FormaContratacao formaContratacaoAtualizada);

        /// <summary>
        /// Deleta uma forma de contratação
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);
    }
}
