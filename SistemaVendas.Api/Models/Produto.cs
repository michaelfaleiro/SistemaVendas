namespace SistemaVendas.Api.Models;

public class Produto : Entity
{
    public Produto()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public Produto(string nome, string sku, string marca, double precoVenda)
    {
        Nome = nome;
        Sku = sku;
        Marca = marca;
        PrecoVenda = precoVenda;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    
    public string Nome { get; private set; }
    public string Sku { get; private set; }
    public string Marca { get; private set; }
    public double PrecoVenda { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}