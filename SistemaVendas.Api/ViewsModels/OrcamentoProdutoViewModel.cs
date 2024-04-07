using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.ViewsObjects;

public class ClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
}

public class OrcamentoProdutoViewModel
{
    public int Id { get; set; }
    public ClienteViewModel Cliente { get; set; }
    public string Carro { get; set; }
    public string Placa { get; set; }
    public string Chassi { get; set; }
    public List<ItensOrcamentoViewModel> Itens { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class ItensOrcamentoViewModel
{
    public int Id { get; set; }
    public int IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public string Sku { get; set; }
    public string Marca { get; set; }
    public double PrecoVenda { get; set; }
    public int Quantidade { get; set; }
}