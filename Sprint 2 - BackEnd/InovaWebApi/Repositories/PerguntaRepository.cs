using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class PerguntaRepository : IPerguntaRepository
    {

        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, Pergunta perguntaAtualizada)
        {
            Pergunta perguntaBuscada = ctx.Pergunta.Find(id);

            if (perguntaBuscada != null)
            {
                if (perguntaAtualizada.NomePergunta != null)
                {
                    perguntaBuscada.NomePergunta = perguntaAtualizada.NomePergunta;
                }

                if (perguntaAtualizada.IdTipoPergunta != null)
                {
                    perguntaBuscada.IdTipoPergunta = perguntaAtualizada.IdTipoPergunta;
                }

            }

            ctx.Pergunta.Update(perguntaBuscada);
            ctx.SaveChanges();
        }

        public Pergunta BuscarPorId(int id)
        {
            Pergunta perguntaBuscada = ctx.Pergunta.FirstOrDefault(p => p.IdPergunta == id);

            return perguntaBuscada;
        }

        public void Cadastrar(Pergunta novaPergunta)
        {
            ctx.Pergunta.Add(novaPergunta);
            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            Pergunta perguntaBuscada = ctx.Pergunta.Find(id);

            ctx.Pergunta.Remove(perguntaBuscada);

            ctx.SaveChanges();
        }

        public List<Pergunta> Listar()
        {
            return ctx.Pergunta.ToList();
        }
    }
}