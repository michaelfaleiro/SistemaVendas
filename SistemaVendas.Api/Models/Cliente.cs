namespace SistemaVendas.Api.Models;

public class Cliente : Entity
{
    public Cliente(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
        Orcamentos = new List<Orcamento>();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    
    
    public string Nome { get;private set; }
    public string Telefone { get;private set; }
    public IReadOnlyCollection<Orcamento> Orcamentos  { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    
}