using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Roman.api.Domains;

namespace Desafio_Roman.api.Interfaces
{
    interface ITemaRepository
    {
        List<Tema> Listar();

        void Cadastrar(Tema novoTema);

        void Atualizar(int id, Tema temaAtualizado);

        void Deletar(int id);
    }
}
