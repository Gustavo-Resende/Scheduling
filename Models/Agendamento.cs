using System.ComponentModel.DataAnnotations;

namespace Scheduling.Models
{
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }

        // Relacionamentos
        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }

        public int BarbeiroId { get; set; }
        public Barbeiro Barbeiro { get; set; }

        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        // Relacionamento com Empresa
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
