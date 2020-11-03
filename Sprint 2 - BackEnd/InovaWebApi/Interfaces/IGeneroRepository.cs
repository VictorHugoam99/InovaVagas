using InovaWebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InovaWebApi.Interfaces
{
    interface IGeneroRepository
    {
        void Atualizar(int id, Genero generoAtualizado);
        Genero BuscarPorId(int id);
        void Cadastrar(Genero novoGenero);
        void Deletar(int id);
        List<Genero> Listar();
    }
}
