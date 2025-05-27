using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // Ex.: "Corte", "Barba"

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
    }
}
