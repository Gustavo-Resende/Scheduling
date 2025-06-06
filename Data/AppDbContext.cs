﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<BarbeiroServico> BarbeiroServicos { get; set; }

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

            modelBuilder.Entity<BarbeiroServico>()
                .HasKey(bs => new { bs.BarbeiroId, bs.ServicoId });

            modelBuilder.Entity<BarbeiroServico>()
                .HasOne(bs => bs.Barbeiro)
                .WithMany(b => b.BarbeiroServicos)
                .HasForeignKey(bs => bs.BarbeiroId);

            modelBuilder.Entity<BarbeiroServico>()
                .HasOne(bs => bs.Servico)
                .WithMany(s => s.BarbeiroServicos)
                .HasForeignKey(bs => bs.ServicoId);

            // Índice único para CNPJ em Empresa
            modelBuilder.Entity<Empresa>()
                .HasIndex(e => e.Cnpj)
                .IsUnique();

            // Índice único para Email em Empresa
            modelBuilder.Entity<Empresa>()
                .HasIndex(e => e.Email)
                .IsUnique();

            // Índice único para CPF e Email em Cliente
            modelBuilder.Entity<ClienteModel>()
                .HasIndex(c => c.Cpf)
                .IsUnique();
            modelBuilder.Entity<ClienteModel>()
                .HasIndex(c => c.Email)
                .IsUnique();

            // Índice único para CPF e Email em Barbeiro
            modelBuilder.Entity<Barbeiro>()
                .HasIndex(b => b.Cpf)
                .IsUnique();
            modelBuilder.Entity<Barbeiro>()
                .HasIndex(b => b.Email)
                .IsUnique();
        }

    }

}
