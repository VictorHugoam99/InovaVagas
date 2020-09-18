using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface ICursoRepository
    {
        /// <summary>
        /// lista todos os cursos
        /// </summary>
        /// <returns></returns>
        List<Curso> Listar();

        /// <summary>
        /// lista o curso pelo nome
        /// </summary>
        /// <returns></returns>
        List<Curso> ListarPorNomeCurso(string nomeCurso);

        /// <summary>
        /// lista o curso pelo termo
        /// </summary>
        /// <returns></returns>
        List<Curso> ListarPorTermo(int idTermo);

        /// <summary>
        /// lista o curso pelo turno
        /// </summary>
        /// <returns></returns>
        List<Curso> ListarPorTurno(int idTurno);

        /// <summary>
        /// lista o curso pelo tipo de curso
        /// </summary>
        /// <returns></returns>
        List<Curso> ListarPorTipoCurso(int idTipoCurso);


        /// <summary>
        /// lista um curso a partir do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Curso BuscarPorId(int id);

        /// <summary>
        /// inscreve um novo curso
        /// </summary>
        /// <param name="novoCurso"></param>
        void Cadastrar(Curso novoCurso);

        /// <summary>
        /// atualiza um curso
        /// </summary>
        /// <param name="id"></param>
        /// <param name=""></param>
        void Atualizar(int id, Curso cursoAtualizado);

        /// <summary>
        /// exclui um curso
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);


    }
}