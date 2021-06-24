using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_Roman.api.Domains;
using Desafio_Roman.api.Interfaces;
using Desafio_Roman.api.Repositories;
using Desafio_Roman.api.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Desafio_Roman.api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario usuarioLogin = _usuarioRepository.Login(login.Email, login.Senha);

                if(usuarioLogin == null)
                {
                    return NotFound("Email ou senha inválidos");
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioLogin.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioLogin.IdUsuario.ToString() ),

                    new Claim(ClaimTypes.Role, usuarioLogin.IdTipoUsuario.ToString()),

                    new Claim("role", usuarioLogin.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("RomanApi_chave_de_autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "RomanApi",
                    audience: "RomanApi",
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
               );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
