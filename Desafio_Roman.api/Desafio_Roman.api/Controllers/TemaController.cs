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
    public class TemaController : ControllerBase
    {
        private ITemaRepository _temaRepository { get; set; }

        public TemaController()
        {
            _temaRepository = new TemaRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_temaRepository.Listar());
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Tema novoTema)
        {
            try
            {
                _temaRepository.Cadastrar(novoTema);

                return StatusCode(202);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Tema temaAtualizado)
        {
            try
            {
                _temaRepository.Atualizar(id, temaAtualizado);

                return StatusCode(201);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _temaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
