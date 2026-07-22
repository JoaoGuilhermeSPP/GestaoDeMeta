namespace GestaoFinanceiro.DTOs.Destino
{
    public class DtoDestinoResumo
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public decimal ValorMeta { get; set; }

        public decimal ValorGuardado { get; set; }

        public decimal ValorRestante { get; set; }

        public decimal PercentualConcluido { get; set; }
    }
}
