using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModels;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            Usuarios usuarioBuscado = usuarioRepository.BuscarEmailSenha(login);
            if (usuarioBuscado == null)
            {
                return NotFound(new { mensagem = "Email ou Senha Inválidos." });
            }
            else
            {

            var claims = new[]
              {
                    // chave customizada
                    new Claim("chave", "0123456789"),
                    new Claim("mari", "AgoraFoi"),
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    // permissao
                    new Claim(ClaimTypes.Role, usuarioBuscado.PermissaoUsuario),
                };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "InLock.WebApi",
                audience: "InLock.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

            }
        }
    }
}