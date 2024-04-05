using System.ComponentModel.DataAnnotations;

namespace SistemaVendas.Api.Dto;

public class CreateOrcamentoDto
{
    [Required(ErrorMessage = "O campo ClienteId é obrigatório.")]
    public int ClienteId { get; set; }
    [Required(ErrorMessage = "O campo Carro é obrigatório.")]
    public string Carro { get; set; }
    [MaxLength(7, ErrorMessage = "O campo Placa deve ter no máximo 7 caracteres.")]
    public string Placa { get; set; }
    [MaxLength(17, ErrorMessage = "O campo Chassi deve ter no máximo 17 caracteres.")]
    public string Chassi { get; set; }
}