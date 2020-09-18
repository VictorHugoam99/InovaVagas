using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface ICurriculoRepository
    {
        /// <summary>
        /// lista todos os curriculos
        /// </summary>
        /// <returns></returns>
        List<Curriculo> Listar();

        /// <summary>
        /// busca um curriculo pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Curriculo BuscarPorId(int id);

        /// <summary>
        /// cadastra um curriculo
        /// </summary>
        /// <param name="novoCurriculo"></param>
        void Cadastrar(Curriculo novoCurriculo);

        /// <summary>
        /// atualiza um curricuo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curriculoAtualizado"></param>
        void Atualizar(int id, Curriculo curriculoAtualizado);

        /// <summary>
        /// deleta um curriculo
        /// </summary>
        /// <param name="id"></param>
        void Excluir(int id);
    }
}