using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoFinanceiro.DTOs.Destino
{
    public class DTOCriaDestino
    {
        public string NomeDest { get; set; } = string.Empty;   
        public decimal MetaTotal { get; set; }  
    }
}
