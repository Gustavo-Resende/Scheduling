namespace Scheduling.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Relacionamentos
        public List<Barbeiro> Barbeiros { get; set; } = new();
        public List<ClienteModel> Clientes { get; set; } = new();
        public List<Servico> Servicos { get; set; } = new();
        public List<Agendamento> Agendamentos { get; set; } = new();
    }
}
