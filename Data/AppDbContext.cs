using Microsoft.EntityFrameworkCore;
using Scheduling.Models;

namespace Scheduling.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Barbeiro> Barbeiros { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }

    }
}
