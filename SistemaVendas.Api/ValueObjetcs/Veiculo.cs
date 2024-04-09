namespace SistemaVendas.Api.ValueObjetcs;

public record Veiculo()
{
    public string Nome { get; set; }
    public string Placa { get; set; }
    public string Chassi { get; set; }
    public string Motor { get; set; }
    public int Ano { get; set; }
    public string Combustivel { get; set; }
}