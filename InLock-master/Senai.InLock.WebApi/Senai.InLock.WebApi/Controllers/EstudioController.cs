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
    public class EstudioController : ControllerBase
    {
        EstudioRepository estudioRepository = new EstudioRepository();

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(estudioRepository.Listar());
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            estudioRepository.Deletar(id);
            return Ok();
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                estudioRepository.Cadastrar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro: " + ex.Message });
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarId(int id)
        {
            return Ok(estudioRepository.BuscarPorId(id));
        }
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult Atualizar(Estudios estudio)
        {
            try
            {
                Estudios estudioBuscado = estudioRepository.BuscarPorId(estudio.IdEstudio);
                estudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch
            {
                return BadRequest(new { mensagem = "Erro" });
            }
        }
    }
}