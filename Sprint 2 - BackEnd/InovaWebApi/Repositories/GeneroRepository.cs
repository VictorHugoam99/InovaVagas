using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Atualizar(int id, Genero generoAtualizado)
        {
            Genero generoBuscado = ctx.Genero.Find(id);

            if (generoBuscado != null)
            {
                if (generoAtualizado.NomeGenero != null)
                {
                    generoBuscado.NomeGenero = generoAtualizado.NomeGenero;
                }

            }
            ctx.Genero.Update(generoBuscado);

            ctx.SaveChanges();
        }

        public Genero BuscarPorId(int id)
        {
            Genero generoBuscado = ctx.Genero.Find(id);

            if (generoBuscado == null)
            {
                return null;
            }

            return generoBuscado;
        }

        public void Cadastrar(Genero novoGenero)
        {
            ctx.Genero.Add(novoGenero);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Genero generoBuscado = ctx.Genero.Find(id);

            ctx.Genero.Remove(generoBuscado);

            ctx.SaveChanges();
        }

        public List<Genero> Listar()
        {
            return ctx.Genero.ToList();
        }
    }
}



