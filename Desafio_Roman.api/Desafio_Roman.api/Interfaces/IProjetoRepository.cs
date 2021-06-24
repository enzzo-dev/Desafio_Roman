using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Roman.api.Domains;
namespace Desafio_Roman.api.Interfaces
{
    interface IProjetoRepository
    {
        List<Projeto> Listar();

        void Cadastrar(Projeto novoProjeto);

        void Atualizar(int id, Projeto projetoAtualizado);

        void Deletar(int id);
    }
}
