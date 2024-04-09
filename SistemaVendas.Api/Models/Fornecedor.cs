namespace SistemaVendas.Api.Models;

public class Fornecedor:Entity
{
    public Fornecedor(string nome, string telefone, string vendedor)
    {
        Nome = nome;
        Telefone = telefone;
        Vendedor = vendedor;
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }

    public void AtualizarFornecedor(string nome, string telefone, string vendedor)
    {
        Nome = nome;
        Telefone = telefone;
        Vendedor = vendedor;
        UpdateAt = DateTime.UtcNow;
    }
    public string Nome { get; private set; }
    public string Telefone { get; private set; }
    public string Vendedor { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
}