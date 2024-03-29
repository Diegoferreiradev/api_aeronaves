﻿using APICiaAerea.Services;
using APICiaAerea.ViewModels.Aeronave;
using Microsoft.AspNetCore.Mvc;

namespace APICiaAerea.Controllers
{
    [Route("api/aeronaves")]
    [ApiController]
    public class AeronaveController : ControllerBase
    {
        private readonly AeronaveService _aeronaveService;

        public AeronaveController(AeronaveService aeronaveService)
        {
            _aeronaveService = aeronaveService;
        }

        [HttpPost]
        public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
        {
           var aeronave = _aeronaveService.Adicionar(dados);
            return CreatedAtAction(nameof(ListarAeronaves), new { Id = aeronave.Id }, aeronave);
        }

        [HttpGet]
        public IActionResult ListarAeronaves()
        {
            return Ok(_aeronaveService.ListarAeronaves());
        }

        [HttpGet("{id}")]
        public IActionResult ListarAeronaves(int id)
        {
            var aeronave = _aeronaveService.ListarAeronaveId(id);

            if (aeronave != null)
            {
                return Ok(aeronave);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarAeronave(int id, AtualizarAeronaveViewModel dados)
        {
            if (id != dados.Id)
                return BadRequest("O Id informado na URL é diferente do id informado no corpo da requisição.");

            var aeronave = _aeronaveService.AtualizarAeronave(dados);
            return Ok(aeronave);
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirAeronave(int id)
        {
           _aeronaveService.ExcluirAeronave(id);
            return NoContent();
        }
    }
}
  