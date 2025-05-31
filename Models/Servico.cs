using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduling.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; } // Ex.: "Corte", "Barba"
        public string? Duracao { get; set; } // Ex.: "30 minutos", "1 hora"

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        // Relacionamento com Empresa
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        // Relacionamento muitos-para-muitos
        public List<BarbeiroServico> BarbeiroServicos { get; set; } = new();

    }
}
