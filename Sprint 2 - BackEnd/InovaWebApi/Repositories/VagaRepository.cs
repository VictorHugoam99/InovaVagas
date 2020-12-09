using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, Vaga vagaAtualizada)
        {
            Vaga vagaBuscada = ctx.Vaga.Find(id);

            if (vagaBuscada != null)
            {
                if (vagaAtualizada.NomeVaga != null)
                {
                    vagaBuscada.NomeVaga = vagaAtualizada.NomeVaga;
                }

                if (vagaAtualizada.Descricao != null)
                {
                    vagaBuscada.Descricao = vagaAtualizada.Descricao;
                }

                if (vagaAtualizada.Requisitos != null)
                {
                    vagaBuscada.Requisitos = vagaAtualizada.Requisitos;
                }

                if (vagaAtualizada.Endereco != null)
                {
                    vagaBuscada.Endereco = vagaAtualizada.Endereco;
                }

                if (vagaAtualizada.NumeroCandidatos != null)
                {
                    vagaBuscada.NumeroCandidatos = vagaAtualizada.NumeroCandidatos;
                }

                if (vagaAtualizada.NumeroCandidatos != null)
                {
                    vagaBuscada.VagaAtiva = vagaAtualizada.VagaAtiva;
                }

                if (vagaAtualizada.DataEncerramento != null)
                {
                    vagaBuscada.DataEncerramento = vagaAtualizada.DataEncerramento;
                }

                if (vagaAtualizada.DataCadastro != null)
                {
                    vagaBuscada.DataCadastro = vagaAtualizada.DataCadastro;
                }

                if (vagaAtualizada.Salario != null)
                {
                    vagaBuscada.Salario = vagaAtualizada.Salario;
                }

                if (vagaAtualizada.IdEmpresa != null)
                {
                    vagaBuscada.IdEmpresa = vagaAtualizada.IdEmpresa;
                }

                if (vagaAtualizada.IdFormaContratacao != null)
                {
                    vagaBuscada.IdFormaContratacao = vagaAtualizada.IdFormaContratacao;
                }

                if (vagaAtualizada.IdAreaVaga != null)
                {
                    vagaBuscada.IdAreaVaga = vagaAtualizada.IdAreaVaga;
                }
            }

            ctx.Vaga.Update(vagaBuscada);

            ctx.SaveChanges();

        }

        public Vaga BuscarPorId(int id)
        {
            Vaga vagaBuscada = ctx.Vaga.FirstOrDefault(v => v.IdVaga == id);

            return vagaBuscada;
        }

        public void Cadastrar(Vaga novaVaga)
        {
            ctx.Vaga.Add(novaVaga);

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            Vaga vagaBuscada = ctx.Vaga.Find(id);

            ctx.Vaga.Remove(vagaBuscada);

            ctx.SaveChanges();
        }

        public List<Vaga> Listar()
        {

            List<Vaga> vagas = ctx.Vaga
                .Include(v => v.IdEmpresaNavigation)
                .Include(v => v.IdFormaContratacaoNavigation)
                .Include(v => v.IdAreaVagaNavigation)
                .ToList();

            foreach (var vaga in vagas)
            {
                if (vaga.DataEncerramento == DateTime.Today)
                {
                    vaga.VagaAtiva = false;
                }
            }

            return vagas;
        }

        public List<Vaga> ListarPorEmpresa(int idEmpresa)
        {
            return ctx.Vaga.Where(v => v.IdEmpresa == idEmpresa).Include(v => v.IdEmpresaNavigation).ToList();
        }

        public List<Vaga> ListarPorEndereco(string endereco)
        {
            return ctx.Vaga.Where(v => v.Endereco == endereco).ToList();
        }

        public List<Vaga> ListarPorNome(string nomeVaga)
        {
            return ctx.Vaga.Where(v => v.NomeVaga == nomeVaga).ToList();
        }

        public List<Vaga> ListarPorSalario(string salario)
        {
            return ctx.Vaga.Where(v => v.Salario == salario).ToList();
        }
    }
}
