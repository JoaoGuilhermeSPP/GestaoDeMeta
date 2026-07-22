using GestaoFinanceiro.Data;
using GestaoFinanceiro.DTOs.Entradas;
using GestaoFinanceiro.DTOs.Guardado;
using GestaoFinanceiro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceiro.Controllers
{
    [ApiController]
    [Route(template: "v1/[Controller]")]
    public class GuardarController : ControllerBase
    {
        private readonly AppDbContext _context;
        public GuardarController(AppDbContext context) 
        {
            _context = context;
        }

        private IQueryable<DtoGuardado> GuardadoBase()
        {
            return _context.Guardadas.Select(e => new DtoGuardado
            {
               Id = e.Id,
               Guardou = e.Guardou,
               Destino = e.IdDestino
            });
        }
        [HttpPost("{id}/guardar")]

        public async Task<IActionResult> GuardarValor(DtoCriaGuardados dto)
        {
            var guardado = new Guardado
            {
                Guardou = dto.Guardou,
                IdDestino = dto.IdDestino,
                Date = DateTime.Now
            };
            var totalEntrada = await _context.Entradas.SumAsync(x => x.Valor);
            var totalDespesa = await _context.Despesas.SumAsync(x => x.Valor);
            var totalGuardado = await _context.Guardadas.SumAsync(x => x.Guardou);

            var Saldo = totalEntrada - totalDespesa - totalGuardado;
                  if(dto.Guardou > Saldo)
            {
                return BadRequest("Saldo indiponivel");
            }
            _context.Guardadas.Add(guardado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorGuardadoId), new { id = guardado.Id }, guardado);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<DtoGuardado>> ObterPorGuardadoId(int id)
        {

            var guardado = await GuardadoBase()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (guardado == null)
                return NotFound();

            return Ok(guardado);
        }

        [HttpDelete]
        public async Task<ActionResult<DtoGuardado>> DeleteEntrada(int id)
        {
            var guardado = await _context.Guardadas.FindAsync(id);
            if (guardado == null)
            {
                return NotFound();
            }
            var retorno = new DtoGuardado
            {
                Id = guardado.Id,
                Guardou = guardado.Guardou,
                Destino = guardado.IdDestino,
                
            };
            _context.Guardadas.Remove(guardado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
    }
}
