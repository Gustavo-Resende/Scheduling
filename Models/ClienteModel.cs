using System.ComponentModel.DataAnnotations;

namespace Scheduling.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; } = DateTime.Now;
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Relacionamento com Empresa
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}