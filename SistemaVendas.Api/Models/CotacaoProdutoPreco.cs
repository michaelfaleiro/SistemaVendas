namespace SistemaVendas.Api.Models;

public class CotacaoProdutoPreco: Entity
{
    public CotacaoProdutoPreco(string sku, string nome, string marca, double precoCusto, double precoVenda, int quantidade)
    {
        Sku = sku;
        Nome = nome;
        Marca = marca;
        PrecoCusto = precoCusto;
        PrecoVenda = precoVenda;
        Quantidade = quantidade;
        CreatedAt = DateTime.UtcNow;
    }
    
    public void AdicionarFornecedor(Fornecedor fornecedor)
    {
        Fornecedor = fornecedor;
        UpdateAt = DateTime.UtcNow;
    }
    
    public void AdicionarItemCotacao(ItemCotacao itemCotacao)
    {
        ItemCotacao = itemCotacao;
        UpdateAt = DateTime.UtcNow;
    }
    
    public void AtualizarPreco(
        string sku, string nome, string marca,double precoCusto, double precoVenda, int quantidade)
    {
        Sku = sku;
        Nome = nome;
        Marca = marca;
        PrecoCusto = precoCusto;
        PrecoVenda = precoVenda;
        Quantidade = quantidade;
        UpdateAt = DateTime.UtcNow;
    }
    public ItemCotacao ItemCotacao { get; private set; } 
    public string Sku { get; private set; }
    public string Nome { get; private set; }
    public string Marca { get; private set; }
    public double PrecoCusto { get; private set; }
    public double PrecoVenda { get; private set; }
    public int Quantidade { get; private set; }
    public Fornecedor Fornecedor { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
}