using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // Ex.: "Corte", "Barba"

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        // Relacionamento com Empresa
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
