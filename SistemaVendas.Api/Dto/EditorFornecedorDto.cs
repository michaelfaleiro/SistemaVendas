using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Api.Dto;

public class EditorFornecedorDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    public string Nome { get;  set; }
    [Required(ErrorMessage = "O campo Telefone é obrigatório")]
    public string Telefone { get;  set; }
    public string Vendedor { get;  set; }
}