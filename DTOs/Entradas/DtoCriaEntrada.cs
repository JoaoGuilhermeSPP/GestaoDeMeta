namespace GestaoFinanceiro.DTOs.Entradas
{
    public class DtoCriaEntrada
    {
     
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime Entr_Data { get; set; } = DateTime.Now;
    }
}
