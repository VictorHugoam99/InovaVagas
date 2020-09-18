using InovaWebApi.Contexts;
using InovaWebApi.Domains;
using InovaWebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        InovaVagasContext ctx = new InovaVagasContext();

        public void Update(int id, Avaliacao avaliacaoAtualizada)
        {
            Avaliacao avaliacaoBuscada = ctx.Avaliacao.Find(id);

            if (avaliacaoBuscada != null)
            {
                if (avaliacaoAtualizada.Avaliacao1Data != null)
                {
                    avaliacaoBuscada.Avaliacao1Data = avaliacaoAtualizada.Avaliacao1Data;
                }
                if (avaliacaoAtualizada.Avaliacao1Realizada != null)
                {
                    avaliacaoBuscada.Avaliacao1Realizada = avaliacaoAtualizada.Avaliacao1Realizada;
                }
                if (avaliacaoAtualizada.Avaliacao2Data != null)
                {
                    avaliacaoBuscada.Avaliacao2Data = avaliacaoAtualizada.Avaliacao2Data;
                }
                if (avaliacaoAtualizada.Avaliacao2Realizada != null)
                {
                    avaliacaoBuscada.Avaliacao2Realizada = avaliacaoAtualizada.Avaliacao2Realizada;
                }
                if (avaliacaoAtualizada.IdContrato != null)
                {
                    avaliacaoBuscada.IdContrato = avaliacaoAtualizada.IdContrato;
                }
                if (avaliacaoAtualizada.VisitaTecnicaData != null)
                {
                    avaliacaoBuscada.VisitaTecnicaData = avaliacaoAtualizada.VisitaTecnicaData;
                }
                if (avaliacaoAtualizada.VisitaTecnicaRealizada != null)
                {
                    avaliacaoBuscada.VisitaTecnicaRealizada = avaliacaoAtualizada.VisitaTecnicaRealizada;
                }

                ctx.Avaliacao.Update(avaliacaoBuscada);
                ctx.SaveChanges();
            }
        }

        public void Add(Avaliacao avaliacao)
        {
            ctx.Avaliacao.Add(avaliacao);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Avaliacao.Remove(GetById(id));
            ctx.SaveChanges();
        }

        public Avaliacao GetById(int id)
        {
            Avaliacao avaliacaoBuscada = ctx.Avaliacao.FirstOrDefault(a => a.IdAvaliacao == id);

            if (avaliacaoBuscada != null)
            {
                return avaliacaoBuscada;
            }

            return null;
        }

        public List<Avaliacao> GetAll()
        {

            return ctx.Avaliacao
                .Select(a => new Avaliacao()
                {
                    IdAvaliacao = a.IdAvaliacao,
                    Avaliacao1Data = a.Avaliacao1Data,
                    Avaliacao1Realizada = a.Avaliacao1Realizada,
                    Avaliacao2Data = a.Avaliacao2Data,
                    Avaliacao2Realizada = a.Avaliacao2Realizada,

                    IdContratoNavigation = new Contrato()
                    {
                        IdContrato = a.IdContratoNavigation.IdContrato,
                        IdStatusContrato = a.IdContratoNavigation.IdStatusContrato,
                        DataInicio = a.IdContratoNavigation.DataInicio,
                        DataTermino = a.IdContratoNavigation.DataTermino,
                        DiasContrato = a.IdContratoNavigation.DiasContrato
                    }
                })
                .ToList();
        }
    }
}