using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IEmpresaRepository
    {
        void Cadastrar(Empresa novaEmpresa);
        List<Empresa> Listar();
        List<Empresa> ListarEmpresasAprovadas(bool status);
        Empresa BuscarPorId(int id);
        void Atualizar(int id, Empresa empresaAtualizada);
        void Deletar(int id);
        List<Empresa> ListarPorOrdemAlfabetica();
        void Aprovar(int id);
        Empresa Login(string email, string senha);
    }
}
