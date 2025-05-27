   namespace Scheduling.Models
   {
       public class Barbeiro
       {
           public int Id { get; set; }
           public string Nome { get; set; }
           public string Especialidade { get; set; } // Ex.: "Corte", "Barba", etc.
           public bool Status { get; set; } = true;
       }
   }
   