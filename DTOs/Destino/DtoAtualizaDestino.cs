using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.DTOs.Destino
{
    public class DtoAtualizaDestino
    {
       public int MetaTotal { get; set; }
        public string NomeDest { get; set; } = string.Empty;
    }
}
