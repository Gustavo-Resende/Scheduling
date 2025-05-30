namespace Scheduling.Models
{
    public class BarbeiroServico
    {
        public int BarbeiroId { get; set; }
        public Barbeiro Barbeiro { get; set; }

        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
