using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Roman.api.Domains;
using Desafio_Roman.api.Interfaces;
using Desafio_Roman.api.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Desafio_Roman.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private IProjetoRepository _projetoRepository { get; set; }
        public ProjetosController()
        {
            _projetoRepository = new ProjetoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Projeto novoProjeto)
        {
            try
            {
                _projetoRepository.Cadastrar(novoProjeto);

                return StatusCode(202);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }

        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Projeto projetoAtualizado)
        {
            try
            {
                _projetoRepository.Atualizar(id, projetoAtualizado);

                return StatusCode(204);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _projetoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

    }
}
