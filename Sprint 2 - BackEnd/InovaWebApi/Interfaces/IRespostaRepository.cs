using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IRespostaRepository
    {
        /// <summary>
        /// lista todas as respostas
        /// </summary>
        /// <returns></returns>
        List<Resposta> Listar();

        /// <summary>
        /// busca um resposta especifica por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Resposta BuscarPorId(int id);

        /// <summary>
        /// cadastra uma resposta nova
        /// </summary>
        /// <param name="novaResposta"></param>
        void Cadastrar(Resposta novaResposta);

        /// <summary>
        /// atualiza um resposta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="respostaAtualizada"></param>
        void Atualizar(int id, Resposta respostaAtualizada);

        /// <summary>
        /// exclui uma resposta
        /// </summary>
        /// <param name="id"></param>
        void Excluir(int id);
    }
}