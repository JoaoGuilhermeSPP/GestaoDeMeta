using GestaoFinanceiro.Data;
using GestaoFinanceiro.DTOs.Despesas;
using GestaoFinanceiro.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Threading.Tasks;

namespace GestaoFinanceiro.Controllers
{
    [ApiController]
    [Route(template: "v1/[Controller]")]
    public class DespesaController : ControllerBase
    {
        private readonly AppDbContext _context;


        public DespesaController(AppDbContext context)
        {
            _context = context;
        }

        //Metodo para evitar repetição
        private IQueryable<DtoDespesas> DespesasBase()
        {
            return  _context.Despesas.Select(d =>  new DtoDespesas
            {
                id = d.Id,
                Nome = d.Name,
                Valor = d.Valor,
                NomeDate = d.Date
            });
        }

        //Cria a depesa
        [HttpPost]
        public async Task<ActionResult<DtoDespesas>> CreateDespesas(DtoCriaDespesa dto)
        {
            var despesa = new Despesas
            {
                Valor = dto.Valor,
                Name = dto.Nome,
                Date = dto.NomeDate
            };
            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync();

            var retorno = new DtoDespesas
            {
                id = despesa.Id,
                Valor = despesa.Valor,
                Nome = despesa.Name,
                NomeDate = despesa.Date
            };
            return CreatedAtAction(nameof(GetDespesas), new { id = despesa.Id}, retorno);
        }
        [HttpGet]
        public async Task<ActionResult<DtoDespesas>> GetDespesas()
        {
            var despesas = await DespesasBase().ToListAsync();
            if(despesas == null)
            {
                return NotFound();
            }
            return Ok(despesas);
        }

        [HttpGet("PorId")]
        public async Task<ActionResult<IEnumerable<Despesas>>> GetDespesaPorId(int id)
        {
            var despesas = await DespesasBase().FirstOrDefaultAsync(d => d.id == id);

            if (despesas == null)
            {
                return NotFound();
            }
            return Ok(despesas);
        }
        [HttpGet("PorData")]
        public async Task<ActionResult<IEnumerable<DtoDespesas>>> GetDespesaData([FromQuery] DateTime data)
        {
            var despesa = await DespesasBase().Where(d => d.NomeDate >= data.Date &&
            d.NomeDate < data.Date.AddDays(1)).ToListAsync();
            
            return Ok(despesa);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizaDespesa(int id, DtoAtualizaDespesas dto)
        {
            var despesa = await _context.Despesas.FindAsync(id);

            if (despesa == null) 
            {
                return NotFound();
            }
            despesa.Name = dto.Nome;
            despesa.Valor = dto.Valor;
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<DtoDespesas>>DeleteDespesa(int id)
        {
           var despesas = await _context.Despesas.FindAsync(id);
            if(despesas == null)
            {
                return NotFound();
            }
            var retorno = new DtoDespesas
            {
                id = despesas.Id,
                Nome = despesas.Name,
                Valor = despesas.Valor,
                NomeDate = despesas.Date
            };
            _context.Despesas.Remove(despesas);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
