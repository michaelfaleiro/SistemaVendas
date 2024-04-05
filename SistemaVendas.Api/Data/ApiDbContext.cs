using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }
    
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Orcamento> Orcamentos { get; set; }
    public DbSet<ItemOrcamento> ItemOrcamentos { get; set; }
}