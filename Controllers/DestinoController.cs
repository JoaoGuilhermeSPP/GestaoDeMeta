using GestaoFinanceiro.Data;
using GestaoFinanceiro.DTOs.Destino;
using GestaoFinanceiro.DTOs.Entradas;
using GestaoFinanceiro.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace GestaoFinanceiro.Controllers
{
    [ApiController]
    [Route(template: "v1/[Controller]")]
    public class DestinoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DestinoController(AppDbContext context) { _context = context; }


        private IQueryable<DtoDestino> DestinoBase()
        {
            return _context.Destinos.Select(d => new DtoDestino
            {
                Id = d.Id,
                Nome = d.NomeDest,
                MetaTotal = d.MetaTotal,
            });
        }

        [HttpPost]
        public async Task<ActionResult<DTOCriaDestino>> CreateEntrada(DTOCriaDestino dto)
        {
            var destino = new Destinos
            {

                NomeDest = dto.NomeDest,
                MetaTotal = dto.MetaTotal
            };
            _context.Destinos.Add(destino);
            await _context.SaveChangesAsync();
            var retorno = new DtoDestino
            {
                Nome = destino.NomeDest,
                MetaTotal = destino.MetaTotal
            };
            return CreatedAtAction(nameof(GetDestinoPorId), new { id = destino.Id }, destino);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoDestino>>> GetDestinos()
        {
            var destino = await DestinoBase().ToListAsync();

            if (destino == null)
            {
                return NotFound();
            }
            return Ok(destino);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DtoDestinoResumo>> GetDestinoPorId(int id)
        {
            var destino = await _context.Destinos
                .Where(e => e.Id == id)
                .Select(e => new DtoDestinoResumo
                {
                    Id = e.Id,
                    Nome = e.NomeDest,
                    ValorMeta = e.MetaTotal,

                    ValorGuardado =
                        e.Guardados.Sum(g => (decimal?)g.Guardou) ?? 0,

                    ValorRestante =
                        e.MetaTotal -
                        (e.Guardados.Sum(g => (decimal?)g.Guardou) ?? 0),

                    PercentualConcluido =
                        e.MetaTotal > 0 ? ((e.Guardados.Sum(g => (decimal?)g.Guardou) ?? 0) / e.MetaTotal) * 100 : 0
                })
                .FirstOrDefaultAsync();

            if (destino == null)
                return NotFound();

            return Ok(destino);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEntrada(int id, DtoAtualizaDestino dto)
        {
            var destino = await _context.Destinos.FindAsync(id);

            if (destino == null)
            {
                return NotFound();
            }
            destino.MetaTotal = dto.MetaTotal;
            destino.NomeDest = dto.NomeDest;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<DtoDestino>> DeleteEntrada(int id)
        {
            var destinos = await _context.Destinos.FindAsync(id);
            if (destinos == null)
            {
                return NotFound();
            }
            var retorno = new DtoEntrada
            {
               
            };
            _context.Destinos.Remove(destinos);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}

