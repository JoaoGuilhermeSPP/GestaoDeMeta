using GestaoFinanceiro.Data;
using GestaoFinanceiro.DTOs.Destino;
using GestaoFinanceiro.Migrations;
using GestaoFinanceiro.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoFinanceiro.Services
{
    public class DestinoService : IDestinoService
    {
        private readonly AppDbContext _context;

        public DestinoService (AppDbContext context)
        {
            _context = context;
        }

        private IQueryable<DtoDestino> DestinoBase()
        {
            return _context.Destinos.Select(d => new DtoDestino
            {
                Id = d.Id,
                Nome = d.NomeDest,
                MetaTotal = d.MetaTotal
            });
        }
        public async Task<IEnumerable<DtoDestino>> ListaDestinos()
        {
            return await DestinoBase().ToListAsync();
        }
        public async Task<DtoDestinoResumo> ObterResumoId(int id)
        {
            var destino = await _context.Destinos.Where(e => e.Id == id).Select(e => new DtoDestinoResumo
            {
                Id = e.Id,
                Nome = e.NomeDest,
                ValorMeta = e.MetaTotal,
                ValorGuardado = e.Guardados.Sum(g => (decimal?)g.Guardou) ?? 0,
                ValorRestante = e.MetaTotal - (e.Guardados.Sum(g => (decimal?)g.Guardou) ?? 0),
                PercentualConcluido = e.MetaTotal > 0 ? ((e.Guardados.Sum(g => (decimal?)g.Guardou) ?? 0) / e.MetaTotal) * 100 : 0

            }).FirstOrDefaultAsync();


            return destino;
        }
      

        public async Task<DtoDestino> CriarDestino(DTOCriaDestino dto)
        {
            var destino = new Model.Destinos
            {
                NomeDest = dto.NomeDest,
                MetaTotal = dto.MetaTotal
            };

            _context.Destinos.Add(destino);
            await _context.SaveChangesAsync();

            return new DtoDestino
            {
                Nome = destino.NomeDest,
                MetaTotal = destino.MetaTotal
            };
        }

        public async Task<bool> AtualizarDestino(int id, DtoAtualizaDestino dto)
        {
            var destino = await _context.Destinos.FindAsync(id);

            if (destino == null)
            {
                return false;
            }

            destino.MetaTotal = dto.MetaTotal;
            destino.NomeDest = dto.NomeDest;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletarDestino(int id)
        {
            var destino = await _context.Destinos.FindAsync(id);
            if (destino == null)
            {
                return false;
            }

            _context.Destinos.Remove(destino);
            await _context.SaveChangesAsync();

            return true;
        }

      
    }
}
    

