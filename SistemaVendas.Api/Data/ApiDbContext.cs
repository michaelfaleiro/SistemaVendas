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
    public DbSet<Cotacao> Cotacoes { get; set; }
    public DbSet<ItemCotacao> ItemCotacoes { get; set; }
    public DbSet<CotacaoProdutoPreco> CotacaoProdutoPrecos { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cotacao>().OwnsOne(c => c.Veiculo);
        base.OnModelCreating(modelBuilder);
    }
}