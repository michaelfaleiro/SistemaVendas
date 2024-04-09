namespace SistemaVendas.Api.ViewsModels.CotacaoViewsModels;

public class AdicionarPrecoCotacaoViewModel
{
    public int IdCotacao { get; set; }
    public int IdFornecedor { get; set; }
    public string Sku { get;  set; }
    public string Nome { get;  set; }
    public string Marca { get;  set; }
    public double PrecoCusto { get;  set; }
    public double PrecoVenda { get;  set; }
    public int Quantidade { get;  set; }
}