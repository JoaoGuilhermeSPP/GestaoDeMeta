using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.Model
{
    public class Despesas
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor {  get; set; }
        public DateTime? Date { get; set; } = DateTime.MinValue;
    }
}
