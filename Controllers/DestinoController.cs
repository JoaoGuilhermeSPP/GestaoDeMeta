// Controllers/DestinoController.cs
using GestaoFinanceiro.DTOs.Destino;
using GestaoFinanceiro.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoFinanceiro.Controllers
{
    [ApiController]
    [Route(template: "v1/[Controller]")]
    public class DestinoController : ControllerBase
    {
        private readonly IDestinoService _destinoService;

        public DestinoController(IDestinoService destinoService)
        {
            _destinoService = destinoService;
        }

        [HttpPost]
        public async Task<ActionResult<DtoDestino>> CreateDestino(DTOCriaDestino dto)
        {
            var resultado = await _destinoService.CriarDestino(dto);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoDestino>>> GetDestinos()
        {
            var destinos = await _destinoService.ListaDestinos();
            return Ok(destinos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoDestinoResumo>> ObterResumoId(int id)
        {
            var destino = await _destinoService.ObterResumoId(id);

            if (destino == null)
                return NotFound();

            return Ok(destino);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDestino(int id, DtoAtualizaDestino dto)
        {
            var sucesso = await _destinoService.AtualizarDestino(id, dto);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestino(int id)
        {
            var sucesso = await _destinoService.DeletarDestino(id);

            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}