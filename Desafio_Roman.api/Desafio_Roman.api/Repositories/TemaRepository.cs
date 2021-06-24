using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Roman.api.Domains;
using Desafio_Roman.api.Context;
using Desafio_Roman.api.Interfaces;

namespace Desafio_Roman.api.Repositories
{
    public class TemaRepository : ITemaRepository
    {

        RomanContext ctx = new RomanContext();

        public void Atualizar(int id, Tema temaAtualizado)
        {
            Tema temaBuscado = ctx.Temas.Find(id);

            if(temaBuscado.Tema1 != null)
            {
                temaBuscado.Tema1 = temaAtualizado.Tema1;
            }

            ctx.Temas.Update(temaBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Tema novoTema)
        {
            ctx.Temas.Add(novoTema);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Tema temaBuscado = ctx.Temas.Find(id);
            ctx.Temas.Remove(temaBuscado);
            ctx.SaveChanges();
            
        }

        public List<Tema> Listar()
        {
            return ctx.Temas.ToList();
        }
    }
}
