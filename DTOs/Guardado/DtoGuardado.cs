using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.DTOs.Guardado
{
    public class DtoGuardado
    {
        public int Id { get; set; }

        public decimal Guardou { get; set; }
        public int Destino { get; set; }

        public DateTime? Date { get; set; }
    }
}
