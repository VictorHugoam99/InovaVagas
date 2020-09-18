using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class TermoRepository : ITermoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();
        public List<Termo> Listar()
        {
            return ctx.Termo.ToList();
        }
        public Termo BuscarPorId(int id)
        {
            return ctx.Termo.FirstOrDefault(c => c.IdTermo == id);
        }
        public void Cadastrar(Termo novoTermo)
        {
            ctx.Termo.Add(novoTermo);

            ctx.SaveChanges();
        }

        public void Atualizar(int Id, Termo termoAtualizado)
        {
            Termo termoBuscado = ctx.Termo.Find(Id);

            if (termoAtualizado.NumeroTermo != null)
            {
                termoBuscado.NumeroTermo = termoAtualizado.NumeroTermo;
            }

            ctx.Termo.Update(termoBuscado);

            ctx.SaveChanges();
        }


        public void Deletar(int Id)
        {
            Termo termoBuscado = ctx.Termo.Find(Id);

            ctx.Termo.Remove(termoBuscado);

            ctx.SaveChanges();
        }
    }
}