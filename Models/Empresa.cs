namespace Scheduling.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string endereco { get; set; }

        // Relacionamentos
        public List<Barbeiro> Barbeiros { get; set; } = new();
        public List<ClienteModel> Clientes { get; set; } = new();
        public List<Servico> Servicos { get; set; } = new();
        public List<Agendamento> Agendamentos { get; set; } = new();
    }
}
