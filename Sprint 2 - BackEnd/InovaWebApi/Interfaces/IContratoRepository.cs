using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IContratoRepository
    {
        void Cadastrar(Contrato novoContrato);
        List<Contrato> ListarTodos();
        Contrato ListarPorId(int id);
        List<Contrato> ListarPorDataInicio(DateTime dataInicio);
        List<Contrato> ListarPorDataTermino(DateTime dataTermino);
        List<Contrato> ListarPorRequerimentoAssinatura(bool requirimentoAssinatura);
        List<Contrato> ListarPorCopiaContrato(bool copiaContrato);
        List<Contrato> ListarPorPlanoEstagio(bool planoEstagio);
        List<Contrato> ListarPorMotivoEvasao(string motivoEvasao);
        void Atualizar(int id, Contrato contratoAtualizado);
        void Excluir(int id);
    }
}
