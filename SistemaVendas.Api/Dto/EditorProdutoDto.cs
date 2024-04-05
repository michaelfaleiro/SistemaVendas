using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Api.Dto;

public class EditorProdutoDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get;  set; }
    [Required(ErrorMessage = "O campo SKU é obrigatório.")]
    public string Sku { get;  set; }
    [Required(ErrorMessage = "O campo Marca é obrigatório.")]
    public string Marca { get;  set; }
    [Required(ErrorMessage = "O campo Preço de Venda é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O campo Preço de Venda deve ser maior que 0.")]
    public double PrecoVenda { get;  set; }
}