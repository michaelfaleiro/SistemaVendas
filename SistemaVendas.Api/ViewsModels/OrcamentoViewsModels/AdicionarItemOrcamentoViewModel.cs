namespace SistemaVendas.Api.ViewsModels.OrcamentoViewsModels;

public class AdicionarItemOrcamentoViewModel
{
    public int OrcamentoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public double PrecoVenda { get; set; }
    
}