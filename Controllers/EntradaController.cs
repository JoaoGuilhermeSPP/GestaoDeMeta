using GestaoFinanceiro.Data;
using GestaoFinanceiro.DTOs.Entradas;
using GestaoFinanceiro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace GestaoFinanceiro.Controllers
{

     [ApiController]
    [Route(template: "v1/[Controller]")]
    public class EntradaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EntradaController(AppDbContext context)
        {
            _context = context;
        }


        private IQueryable<DtoEntrada> EntradaBase()
        {
            return _context.Entradas.Select(e => new DtoEntrada
            {
                    Id = e.Id,
                    Valor = e.Valor,
                    Descricao = e.Descricao,
                    Entr_Data = e.EntreData,
            });
        }
        [HttpPost]
        public async Task<ActionResult<DtoEntrada>> CreateEntrada(DtoCriaEntrada dto)
        {
            var entrada = new Entradas
            {
                Valor = dto.Valor,
                Descricao = dto.Descricao,
                EntreData = dto.Entr_Data
            };
            _context.Entradas.Add(entrada);
            await _context.SaveChangesAsync();
            var retorno = new DtoEntrada
            {
                Id = entrada.Id,
                Valor = entrada.Valor,
                Descricao = entrada.Descricao,
                Entr_Data = entrada.EntreData
            };
            return CreatedAtAction(nameof(GetEntradas), new{ id = entrada.Id }, entrada);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtoEntrada>>> GetEntradas()
        {
            var entrada = await EntradaBase().ToListAsync();

            if (entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpGet("buscaPorId")]
        public async Task<ActionResult<DtoEntrada>> GetEntradaPorId(int id)
        {
         var entrada = await EntradaBase().FirstOrDefaultAsync(e =>  e.Id == id);
            if (entrada == null)
            {
                return NotFound();
            }
            return Ok(entrada);
        }

        [HttpGet("data")]
        public async Task<ActionResult<Entradas>> GetDataEntrada([FromQuery] DateTime dataEntrada)
        {
            var entrada = await EntradaBase().Where(e => e.Entr_Data >= dataEntrada.Date &&
            e.Entr_Data < dataEntrada.Date.AddDays(1)).ToListAsync();

            if (entrada == null)
            {
                return NotFound();

            }
            return Ok(entrada);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntrada(int id, DtoAtualizaEntrada dto)
        {
            var entrada = await _context.Entradas.FindAsync(id);

            if(entrada == null)
            {
                return NotFound();
            }
            entrada.Valor = dto.Valor;
            entrada.Descricao = dto.Descricao;
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult<DtoEntrada>> DeleteEntrada(int id)
        {
            var entrada = await _context.Entradas.FindAsync(id);
            if(entrada == null)
            {
                return NotFound();
            }
            var retorno = new DtoEntrada
            {
                Id = entrada.Id,
                Valor = entrada.Id,
                Descricao = entrada.Descricao,
                Entr_Data = entrada.EntreData
            };
            _context.Entradas.Remove(entrada);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        
    }
}
