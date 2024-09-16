using Atividade1309.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividade1309.Data;

public class AtvDbContext : DbContext
{
    public AtvDbContext(DbContextOptions<AtvDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>().HasKey(C => new { C.Id });
        modelBuilder.Entity<Fornecedor>().HasKey(F => new { F.Id });
    }
}