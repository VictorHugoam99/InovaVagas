using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IVagaRepository
    {
        /// <summary>
        /// lista todas vagas
        /// </summary>
        /// <returns></returns>
        List<Vaga> Listar();

        /// <summary>
        /// exibe uma vaga especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Vaga BuscarPorId(int id);

        /// <summary>
        /// lista a vaga pela seu nome
        /// </summary>
        /// <param name="nomeVaga"></param>
        /// <returns></returns>
        List<Vaga> ListarPorNome(string nomeVaga);

        /// <summary>
        /// lista a vaga pelo endereco
        /// </summary>
        /// <param name="endereco"></param>
        /// <returns></returns>
        List<Vaga> ListarPorEndereco(string endereco);

        /// <summary>
        /// lista a vaga pelo salario
        /// </summary>
        /// <param name="salario"></param>
        /// <returns></returns>
        List<Vaga> ListarPorSalario(string salario);

        /// <summary>
        /// lista a vaga pela empresa
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        List<Vaga> ListarPorEmpresa(int idEmpresa);

        /// <summary>
        /// Cadastra uma nova vaga
        /// </summary>
        /// <param name="novaVaga"></param>
        void Cadastrar(Vaga novaVaga);

        /// <summary>
        /// atualiza uma vaga
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vagaAtualizada"></param>
        void Atualizar(int id, Vaga vagaAtualizada);

        /// <summary>
        /// deleta uma vaga
        /// </summary>
        /// <param name="id"></param>
        void Excluir(int id);
    }
}