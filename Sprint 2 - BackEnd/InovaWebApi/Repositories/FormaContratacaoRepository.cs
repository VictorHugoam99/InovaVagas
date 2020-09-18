using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class FormaContratacaoRepository : IFormaContratacaoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, FormaContratacao formaContratacaoAtualizada)
        {
            FormaContratacao formaContratacaoBuscada = ctx.FormaContratacao.Find(id);

            if (formaContratacaoBuscada != null)
            {
                if (formaContratacaoAtualizada.NomeFormaContratacao != null)
                {
                    formaContratacaoBuscada.NomeFormaContratacao = formaContratacaoAtualizada.NomeFormaContratacao;
                }

            }
            ctx.FormaContratacao.Update(formaContratacaoBuscada);

            ctx.SaveChanges();
        }

        public FormaContratacao BuscarPorId(int id)
        {
            FormaContratacao fcBuscada = ctx.FormaContratacao.Find(id);

            if (fcBuscada == null)
            {
                return null;
            }

            return fcBuscada;
        }

        public void Cadastrar(FormaContratacao novaFormaContratacao)
        {
            ctx.FormaContratacao.Add(novaFormaContratacao);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            FormaContratacao formaContratacaoBuscada = ctx.FormaContratacao.Find(id);

            ctx.FormaContratacao.Remove(formaContratacaoBuscada);

            ctx.SaveChanges();
        }

        public List<FormaContratacao> Listar()
        {
            return ctx.FormaContratacao.ToList();
        }
    }
}