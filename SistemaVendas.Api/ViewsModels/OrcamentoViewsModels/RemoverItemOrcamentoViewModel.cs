using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Api.ViewsModels.OrcamentoViewsModels;

public class RemoverItemOrcamentoViewModel
{
    [Required(ErrorMessage = "O Id do orçamento é obrigatório")]
    public int OrcamentoId { get; set; }
    [Required(ErrorMessage = "O Id do item do orçamento é obrigatório")]
    public int ItemOrcamentoId { get; set; }
}