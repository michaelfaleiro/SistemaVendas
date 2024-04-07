namespace SistemaVendas.Api.Models;

public class ItemCotacao:Entity
{
   
    public ItemCotacao(string sku, string nome, int quantidade)
    {
        Sku = sku;
        Nome = nome;
        Quantidade = quantidade;
        Precos = new List<CotacaoProdutoPreco>();
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }
    
    public void AdicionarPreco(CotacaoProdutoPreco preco)
    {
        Precos.Add(preco);
        UpdateAt = DateTime.UtcNow;
    }
    
    public void AdicionarCotacao(Cotacao cotacao)
    {
        Cotacao = cotacao;
    }

    public Cotacao Cotacao { get; private set; }
    public string Sku { get; private set; }
    public string Nome { get; private set; }
    public int Quantidade { get; private set; }
    public List<CotacaoProdutoPreco> Precos { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
    
}