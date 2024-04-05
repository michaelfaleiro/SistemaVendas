namespace SistemaVendas.Api.Models;

public class ItemOrcamento : Entity
{
    
    public ItemOrcamento()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void AdicionarOrcamento(Orcamento orcamento)
    {
        Orcamento = orcamento;
    }
    
    public void AdicionarProduto( Produto produto, int quantidade, double precoVenda)
    {
        Produto = produto;
        Quantidade = quantidade;
        PrecoVenda = precoVenda;
    }
    
    
    public int OrcamentoId { get; private set; }
    public Orcamento Orcamento { get; private set; }
    public int ProdutoId { get; private set; }
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }
    public double PrecoVenda { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
}