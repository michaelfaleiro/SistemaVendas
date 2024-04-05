namespace SistemaVendas.Api.Models;

public class Orcamento : Entity
{

    public Orcamento()
    {
        Itens = new List<ItemOrcamento>();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public Cliente Cliente { get; private set; }
    public string Carro { get; private set; }
    public string Placa { get; private set; }
    public string Chassi { get; private set; }
    public IList<ItemOrcamento> Itens { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public void AdicionarCliente(Cliente cliente)
    {
        Cliente = cliente;
    }

    public void AdicionarCarro(string carro, string placa, string chassi)
    {
        Carro = carro;
        Placa = placa;
        Chassi = chassi;
    }
    
}