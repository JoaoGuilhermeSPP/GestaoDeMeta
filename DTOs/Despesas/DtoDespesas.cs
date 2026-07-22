namespace GestaoFinanceiro.DTOs.Despesas
{
    public class DtoDespesas
    {
        public int id { get; set; }
        public decimal Valor { get; set; }
        public string Nome { get; set; }
        public DateTime? NomeDate { get; set; } = default(DateTime?);
    }
}
