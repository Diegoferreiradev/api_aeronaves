using APICiaAerea.Services;
using APICiaAerea.ViewModels.Voo;
using Microsoft.AspNetCore.Mvc;

namespace APICiaAerea.Controllers
{
    [Route("api/voos")]
    [ApiController]
    public class VooController : ControllerBase
    {
       private readonly VooService _vooService;

        public VooController(VooService vooService)
        {
            _vooService = vooService;
        }

        [HttpPost]
        public IActionResult AdicionarVoo(AdicionarVooViewModel dados)
        {
            var voo = _vooService.AdicionarVoo(dados);
            return CreatedAtAction(nameof(ListarVooId), new { voo.Id }, voo);
        }

        [HttpGet]
        public IActionResult ListarVoos(string? origem, string? destino, DateTime? partida, DateTime? chegada)
        {
            return Ok(_vooService.ListarVoos(origem, destino, partida, chegada));
        }

        [HttpGet("{id}")]
        public IActionResult ListarVooId(int id)
        {
            var voo = _vooService.ListarVooId(id);

            if (voo != null)
            {
                return Ok(voo);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarVoo(int id, AtualizarVooViewModel dados)
        {
            if (id != dados.Id)
                return BadRequest("O id informado na URL é diferente do id informado na requisição.");

            var voo = _vooService.AtualizarVoo(dados);

            if (voo != null)
            {
                return Ok(voo);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
          _vooService.ExcluirVoo(id);
            return NoContent();
        }
    }
}
