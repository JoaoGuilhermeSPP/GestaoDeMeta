using GestaoFinanceiro.DTOs.Destino;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GestaoFinanceiro.Services.Interfaces
{
    public interface IDestinoService
    {
        Task<IEnumerable<DtoDestino>> ListaDestinos();
        Task<DtoDestinoResumo> ObterResumoId(int id);
        Task<DtoDestino> CriarDestino(DTOCriaDestino dto);
        Task<bool> AtualizarDestino(int id, DtoAtualizaDestino dto);
        Task<bool> DeletarDestino(int id);
    }
}
