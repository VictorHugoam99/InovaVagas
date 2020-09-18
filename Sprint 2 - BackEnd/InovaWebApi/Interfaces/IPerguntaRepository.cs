using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IPerguntaRepository
    {
        /// <summary>
        /// lista todas as perguntas
        /// </summary>
        /// <returns></returns>
        List<Pergunta> Listar();

        /// <summary>
        /// busca uma pergunta pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pergunta BuscarPorId(int id);

        /// <summary>
        /// cadastra uma nova pergunta
        /// </summary>
        /// <param name="novaPergunta"></param>
        void Cadastrar(Pergunta novaPergunta);

        /// <summary>
        /// atualiza uma pergunta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="perguntaAtualizada"></param>
        void Atualizar(int id, Pergunta perguntaAtualizada);

        /// <summary>
        /// exclui uma pergunta
        /// </summary>
        /// <param name="id"></param>
        void Excluir(int id);

    }
}