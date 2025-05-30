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
        public DbSet<Empresa> Empresas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Barbeiro>()
                .HasOne(b => b.Empresa)
                .WithMany(e => e.Barbeiros)
                .HasForeignKey(b => b.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ClienteModel>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.Clientes)
                .HasForeignKey(c => c.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Servico>()
                .HasOne(s => s.Empresa)
                .WithMany(e => e.Servicos)
                .HasForeignKey(s => s.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Agendamento>()
                .HasOne(a => a.Empresa)
                .WithMany(e => e.Agendamentos)
                .HasForeignKey(a => a.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
