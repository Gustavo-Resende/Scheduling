namespace Scheduling.DTOs.Barbeiro
{
    public class BarbeiroCreateDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Status { get; set; } = true;
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int EmpresaId { get; set; }
        public List<int> ServicoIds { get; set; }
    }
}
