namespace Scheduling.DTOs.Barbeiro
{
    public class BarbeiroCreateDto
    {
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public bool Status { get; set; } = true;
        public int EmpresaId { get; set; }
    }
}
