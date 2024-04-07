using SistemaVendas.Api.ValueObjetcs;

namespace SistemaVendas.Api.ViewsModels;

public class CotacaoComItensEPrecosViewModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public Veiculo Veiculo { get; set; }
    public List<ItemCotacaoViewModel> Itens { get; set; }
}

public class ItemCotacaoViewModel
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public List<PrecoProduto> Precos { get; set; }
}

public class PrecoProduto
{
    public int Id { get; set; }
    public string Marca { get; set; }
    public decimal PrecoCusto { get; set; }
    public decimal PrecoVenda { get; set; }
    public int Quantidade { get; set; }
    public string Fornecedor { get; set; }
}