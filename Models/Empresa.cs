using System.ComponentModel.DataAnnotations;

namespace Scheduling.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
            
        // Relacionamentos
        public List<Barbeiro> Barbeiros { get; set; } = new();
        public List<ClienteModel> Clientes { get; set; } = new();
        public List<Servico> Servicos { get; set; } = new();
        public List<Agendamento> Agendamentos { get; set; } = new();
    }
}
