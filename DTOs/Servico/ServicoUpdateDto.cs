namespace Scheduling.DTOs.Servico
{
    public class ServicoUpdateDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public decimal Preco { get; set; }
        public int EmpresaId { get; set; }
    }
}
