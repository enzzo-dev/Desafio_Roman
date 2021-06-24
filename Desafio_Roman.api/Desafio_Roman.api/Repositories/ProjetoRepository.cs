using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Roman.api.Interfaces;
using Desafio_Roman.api.Domains;
using Desafio_Roman.api.Context;

namespace Desafio_Roman.api.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {

        RomanContext ctx = new RomanContext();

        public void Atualizar(int id, Projeto projetoAtualizado)
        {
            Projeto projetoBuscado = ctx.Projetos.Find(id);

            if(projetoBuscado.Nome != null || projetoBuscado.Descricao != null)
            {
                projetoBuscado.Nome = projetoAtualizado.Nome;
                projetoBuscado.Descricao = projetoAtualizado.Descricao;
            }

            ctx.Projetos.Update(projetoBuscado);

            ctx.SaveChanges();
        }

        public void Cadastrar(Projeto novoProjeto)
        {
            ctx.Projetos.Add(novoProjeto);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Projeto projetoBuscado = ctx.Projetos.Find(id);

            ctx.Projetos.Remove(projetoBuscado);

            ctx.SaveChanges();
        }

        public List<Projeto> Listar()
        {
            return ctx.Projetos.ToList();
        }
    }
}
