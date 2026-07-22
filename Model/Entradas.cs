using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.Model
{
    public class Entradas
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor {  get; set; }
        public string Descricao {  get; set; }
        public DateTime Entr_Data { get; set; } = DateTime.Now;
    }
}
