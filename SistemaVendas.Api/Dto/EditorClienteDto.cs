using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Api.Dto;

public class EditorClienteDto
{
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public string Telefone { get; set; }
}