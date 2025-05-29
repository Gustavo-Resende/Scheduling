using System.ComponentModel.DataAnnotations;

namespace Scheduling.Models
{
    public class Barbeiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; } // Ex.: "Corte", "Barba", etc.
        public bool Status { get; set; } = true;

        // Relacionamento com Empresa

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
