using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.Model
{
    public class Destinos
    {
        public int Id { get; set; }
        public string NomeDest {  get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal valor {  get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MetaTotal {  get; set; }

        public ICollection<Guardado> Guardados { get; set; } = new List<Guardado>();

    }
}
