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
    public class RespostaRepository : IRespostaRepository
    {

        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, Resposta respostaAtualizada)
        {
            Resposta respostaBuscada = ctx.Resposta.Find(id);

            if (respostaBuscada != null)
            {
                if (respostaAtualizada.IdPergunta != null)
                {
                    respostaBuscada.IdPergunta = respostaAtualizada.IdPergunta;
                }

                if (respostaAtualizada.IdTipoResposta != null)
                {
                    respostaBuscada.IdTipoResposta = respostaAtualizada.IdTipoResposta;
                }

                if (respostaAtualizada.IdAvaliacao != null)
                {
                    respostaBuscada.IdAvaliacao = respostaAtualizada.IdAvaliacao;
                }
            }

            ctx.Resposta.Update(respostaBuscada);
            ctx.SaveChanges();

        }

        public Resposta BuscarPorId(int id)
        {
            Resposta respostaBuscada = ctx.Resposta.FirstOrDefault(r => r.IdResposta == id);

            return respostaBuscada;
        }

        public void Cadastrar(Resposta novaResposta)
        {
            if (novaResposta != null)
            {
                ctx.Resposta.Add(novaResposta);
                ctx.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            Resposta respostaBuscada = ctx.Resposta.Find(id);

            ctx.Resposta.Remove(respostaBuscada);

            ctx.SaveChanges();
        }

        public List<Resposta> Listar()
        {
            return ctx.Resposta
                .Include(r => r.IdPerguntaNavigation)
                .Include(r => r.IdTipoRespostaNavigation)
                .Include(r => r.IdAvaliacaoNavigation)
                .ToList();
        }
    }
}