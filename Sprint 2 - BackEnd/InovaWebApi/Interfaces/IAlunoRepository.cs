using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IAlunoRepository
    {

        /// <summary>
        /// Lista todos os alunos
        /// </summary>
        /// <returns>Uma lista de alunos</returns>  
        List<Aluno> GetAll();

        /// <summary>
        /// Busca um aluno por ID
        /// </summary>
        /// <param name="id">ID do aluno que será buscado</param>
        /// <returns>Um usuário buscado</returns>
        Aluno GetById(int id);

        /// <summary>
        /// Cadastra um novo aluno
        /// </summary>
        /// <param name="Aluno">Objeto com as informações de cadastro</param>
        void Add(Aluno Aluno);

        /// <summary>
        /// Atualiza um aluno existente
        /// </summary>
        /// <param name="id">ID do aluno que será atualizado</param>
        /// <param name="alunoAtualizado">Objeto com as novas informações</param>
        void Update(int id, Aluno alunoAtualizado);

        /// <summary>
        /// Deleta um aluno
        /// </summary>
        /// <param name="id">ID do aluno que será deletado</param>
        void Delete(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        Aluno Login(string email, string senha);
    }
}
