namespace Scheduling.DTOs.Barbeiro
{
    public class BarbeiroReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public int EmpresaId { get; set; }
        public List<int> ServicoIds { get; set; }
    }
}
