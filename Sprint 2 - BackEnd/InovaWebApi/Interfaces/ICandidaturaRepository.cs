using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface ICandidaturaRepository
    {   // Lista todos os Candidatos a uma vaga disponivel
        /// Uma lista de Candidatos
        List<Candidatura> GetAll();

        void AtualizarStatus(int id);

        void Contratar(int id);
        /// Busca um aluno por ID
        /// <param name="id">ID do aluno que será buscado</param>
        /// Um usuário buscado
        Candidatura GetById(int id);

        List<Candidatura> GetByVaga(int id);

        List<Candidatura> GetByIdAluno(int id);

        /// Cadastra um novo candidato
        /// <param name="candidatura">Objeto com as informações de cadastro</param>
        void Add(Candidatura candidatura);

        /// Atualiza um Candidato ja existente
        /// <param name="id">ID do candidato que será atualizado</param>
        /// <param name="CandidaturaAtualizado">Objeto com as novas informações</param>
        void Update(int id, Candidatura CandidaturaAtualizado);

        /// Deleta um Candidato
        /// <param name="id">ID do candidato que será deletado</param>
        void Delete(int id);
    }
}