using Scheduling.Service.BarbeiroService;
using System.ComponentModel.DataAnnotations;

namespace Scheduling.Models
{
    public class Barbeiro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; } // Ex.: "Corte", "Barba", etc.
        public bool Status { get; set; } = true;
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string cpf { get; set; }

        // Relacionamento com Empresa

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        // Relacionamento muitos-para-muitos
        public List<BarbeiroServico> BarbeiroServicos { get; set; } = new();
    }
}
