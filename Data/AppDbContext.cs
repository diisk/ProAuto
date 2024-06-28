using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAuto.Models;

namespace ProAuto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }


        public DbSet<ProAuto.Models.Associado> Associados { get; set; } = default!;
        public DbSet<ProAuto.Models.Veiculo> Veiculos { get; set; } = default!;
        public DbSet<ProAuto.Models.Endereco> Enderecos { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associado>()
            .HasMany(a => a.Veiculos)
            .WithOne(v => v.Associado)
            .HasForeignKey(v => v.AssociadoId);

            modelBuilder.Entity<Associado>()
            .HasOne(a => a.Endereco)
            .WithOne(e => e.Associado)
            .HasForeignKey<Endereco>(e => e.AssociadoId);
        }
    }
}
