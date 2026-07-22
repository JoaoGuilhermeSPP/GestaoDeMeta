namespace GestaoFinanceiro.DTOs.Despesas
{
    public class DtoCriaDespesa
    {
        public decimal Valor {  get; set; }
        public string Nome {  get; set; }
        public  DateTime? NomeDate { get; set; } = default(DateTime?);
    }
}
