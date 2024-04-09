namespace SistemaVendas.Api.ViewsModels.CotacaoViewsModels;

public class ListarItemComPrecosViewModel
{
    public int Id { get; set; }
    public string Sku { get; set; }
    public string Nome { get; set; }
    public List<Preco> Precos { get; set; } = [];
}

public class Preco
{
    public int Id { get; set; }
    public string Marca { get; set; }
    public double PrecoCusto { get; set; }
    public double PrecoVenda { get; set; }
    public int Quantidade { get; set; }
    public string Fornecedor { get; set; }
}