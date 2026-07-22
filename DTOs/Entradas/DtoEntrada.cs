using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.DTOs.Entradas
{
    public class DtoEntrada
    {
        public int Id { get; set; }
       
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Entr_Data { get; set; } = DateTime.Now;
    }
}
