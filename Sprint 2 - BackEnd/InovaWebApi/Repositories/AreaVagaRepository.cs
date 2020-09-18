using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class AreaVagaRepository : IAreaVagaRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Update(int id, AreaVaga areaVagaAtualizada)
        {
            AreaVaga areaVagaBuscada = ctx.AreaVaga.Find(id);

            if (areaVagaBuscada != null)
            {
                if (areaVagaAtualizada.NomeAreaVaga != null)
                {
                    areaVagaBuscada.NomeAreaVaga = areaVagaAtualizada.NomeAreaVaga;
                }

                ctx.AreaVaga.Update(areaVagaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Add(AreaVaga areaVaga)
        {
            ctx.AreaVaga.Add(areaVaga);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.AreaVaga.Remove(GetById(id));
            ctx.SaveChanges();
        }

        public AreaVaga GetById(int id)
        {
            AreaVaga areaVagaBuscada = ctx.AreaVaga.FirstOrDefault(a => a.IdAreaVaga == id);

            if (areaVagaBuscada != null)
            {
                return areaVagaBuscada;
            }

            return null;
        }

        public List<AreaVaga> GetAll()
        {
            return ctx.AreaVaga.ToList();
        }
    }
}