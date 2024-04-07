using SistemaVendas.Api.ValueObjetcs;

namespace SistemaVendas.Api.Models;

public class Cotacao:Entity
{
    public Cotacao()
    {
        ItemCotacaos = new List<ItemCotacao>();
        CreatedAt = DateTime.UtcNow;
        UpdateAt = DateTime.UtcNow;
    }
    
    public void AdicionarVeiculo(string nome, string placa, string chassi, string motor, int ano, string combustivel)
    {
        Veiculo.Nome = nome;
        Veiculo.Placa = placa;
        Veiculo.Chassi = chassi;
        Veiculo.Motor = motor;
        Veiculo.Ano = ano;
        Veiculo.Combustivel = combustivel;
        UpdateAt = DateTime.UtcNow;
    }
    
    
    public void AdicionarItemCotacao(ItemCotacao itemCotacao)
    {
        ItemCotacaos.Add(itemCotacao);
        UpdateAt = DateTime.UtcNow;
    }
    
    
    public Veiculo Veiculo { get; private set; } = new();
    
    public IList<ItemCotacao> ItemCotacaos { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdateAt { get; private set; }
    
}
