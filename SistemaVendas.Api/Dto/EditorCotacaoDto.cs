using System.ComponentModel.DataAnnotations;
using SistemaVendas.Api.ValueObjetcs;

namespace SistemaVendas.Api.Dto;

public class EditorCotacaoDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Carro { get; set; }
    public string Placa { get; set; } 
    public string Chassi { get; set; } 
    public string Motor { get; set; } 
    public int Ano { get; set; }
    public string Combustivel { get; set; }
}