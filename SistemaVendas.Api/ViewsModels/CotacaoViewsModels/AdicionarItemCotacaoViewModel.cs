namespace SistemaVendas.Api.ViewsModels.CotacaoViewsModels;

public class AdicionarItemCotacaoViewModel
{
    public int IdCotacao { get; set; }
    public string Sku { get;  set; }
    public string Nome { get;  set; }
    public int Quantidade { get;  set; }       
}