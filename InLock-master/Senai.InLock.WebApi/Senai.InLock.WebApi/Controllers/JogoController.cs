using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        JogoRepository jogosRepository = new JogoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(jogosRepository.Listar());
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Jogos jogo)
        {
            try
            {
                jogosRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro: " + ex.Message });
            }
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            jogosRepository.Deletar(id);
            return Ok();
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(jogosRepository.BuscarPorId(id));
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Jogos jogo)
        {
            try
            {                
                Jogos jogoBuscado = jogosRepository.BuscarPorId(jogo.IdJogo);
                jogosRepository.Atualizar(jogo);
                return Ok();
            }
            catch
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }
    }
}