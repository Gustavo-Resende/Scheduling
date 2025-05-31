namespace Scheduling.DTOs.Agendamento
{
    public class AgendamentoCreateDto
    {
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public int ClienteId { get; set; }
        public int BarbeiroId { get; set; }
        public int ServicoId { get; set; }
        public int EmpresaId { get; set; }
        public string? Observacao { get; set; }
    }
}
