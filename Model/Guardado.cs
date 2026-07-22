using GestaoFinanceiro.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.Model
{
    public class Guardado
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Guardou {  get; set; }
        public int IdDestino {  get; set; }

        public Destinos Destino { get; set; } = null!;

        public DateTime? Date { get; set; }
      
    }
}
