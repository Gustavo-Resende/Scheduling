namespace Scheduling.DTOs.Cliente
{
    public class ClienteCreateDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EmpresaId { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
