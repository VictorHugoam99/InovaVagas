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
    public class CurriculoRepository : ICurriculoRepository
    {

        InovaVagasContext ctx = new InovaVagasContext();
        public void Atualizar(int id, Curriculo curriculoAtualizado)
        {
            Curriculo cBuscado = ctx.Curriculo.FirstOrDefault(c => c.IdCurriculo == id);

            if (cBuscado != null)
            {
                if (curriculoAtualizado.NomeEmpresa != null)
                {
                    cBuscado.NomeEmpresa = curriculoAtualizado.NomeEmpresa;
                }

                if (curriculoAtualizado.DataInicioEmprego != null)
                {
                    cBuscado.DataInicioEmprego = curriculoAtualizado.DataInicioEmprego;
                }

                if (curriculoAtualizado.DataTerminoEmprego != null)
                {
                    cBuscado.DataTerminoEmprego = curriculoAtualizado.DataTerminoEmprego;
                }

                if (curriculoAtualizado.DescricaoEmprego != null)
                {
                    cBuscado.DescricaoEmprego = curriculoAtualizado.DescricaoEmprego;
                }

                if (curriculoAtualizado.NomeEscola != null)
                {
                    cBuscado.NomeEscola = curriculoAtualizado.NomeEscola;
                }

                if (curriculoAtualizado.NomeEscola != null)
                {
                    cBuscado.DataInicioEscola = curriculoAtualizado.DataInicioEscola;
                }

                if (curriculoAtualizado.DataTerminoEscola != null)
                {
                    cBuscado.DataTerminoEscola = curriculoAtualizado.DataTerminoEscola;
                }

                if (curriculoAtualizado.Competencia != null)
                {
                    cBuscado.Competencia = curriculoAtualizado.Competencia;
                }

                if (curriculoAtualizado.LinkLinkedIn != null)
                {
                    cBuscado.LinkLinkedIn = curriculoAtualizado.LinkLinkedIn;
                }

                if (curriculoAtualizado.LinkGitHub != null)
                {
                    cBuscado.LinkGitHub = curriculoAtualizado.LinkGitHub;
                }

                if (curriculoAtualizado.InformacoesAdicionais != null)
                {
                    cBuscado.InformacoesAdicionais = curriculoAtualizado.InformacoesAdicionais;
                }

                if (curriculoAtualizado.IdAluno != null)
                {
                    cBuscado.IdAluno = curriculoAtualizado.IdAluno;
                }

            }

            ctx.Curriculo.Update(cBuscado);
            ctx.SaveChanges();
        }

        public Curriculo BuscarPorId(int id)
        {
            Curriculo cBuscado = ctx.Curriculo.Find(id);

            return cBuscado;
        }

        public void Cadastrar(Curriculo novoCurriculo)
        {
            if (novoCurriculo != null)
            {
                ctx.Curriculo.Add(novoCurriculo);

                ctx.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            Curriculo cBuscada = ctx.Curriculo.Find(id);

            ctx.Curriculo.Remove(cBuscada);
            ctx.SaveChanges();
        }

        public List<Curriculo> Listar()
        {
            return ctx.Curriculo
                .Include(c => c.IdAlunoNavigation)
                .ToList();
        }
    }
}
