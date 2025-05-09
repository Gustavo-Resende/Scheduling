namespace Scheduling.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // Ex.: "Corte", "Barba"
        public decimal Preco { get; set; }
    }
}
