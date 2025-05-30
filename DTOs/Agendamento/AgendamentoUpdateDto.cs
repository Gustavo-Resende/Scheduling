namespace Scheduling.DTOs.Agendamento
{
    public class AgendamentoUpdateDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public int ClienteId { get; set; }
        public int BarbeiroId { get; set; }
        public int ServicoId { get; set; }
        public int EmpresaId { get; set; }
    }
}
