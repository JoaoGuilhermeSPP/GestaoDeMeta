namespace GestaoFinanceiro.DTOs.Despesas
{
    public class DtoAtualizaDespesas
    {
        public int id { get; set; }
        public decimal Valor { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}
