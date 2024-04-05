using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Data;
using SistemaVendas.Api.Dto;
using SistemaVendas.Api.Models;
using SistemaVendas.Api.ViewsObjects;

namespace SistemaVendas.Api.Services;

public class OrcamentoService(ApiDbContext context)
{
    
    public async Task<Orcamento> Create( Orcamento orcamento)
    {
        await context.Orcamentos.AddAsync(orcamento);
        await context.SaveChangesAsync();

        return orcamento;
    }

    public async Task AdicionarItem(AdicionarItemOrcamentoViewModel itemOrcamento )
    {
        var orcamento = await context.Orcamentos.FirstOrDefaultAsync(x => x.Id == itemOrcamento.OrcamentoId);
        var produto = await context.Produtos.FirstOrDefaultAsync(x => x.Id == itemOrcamento.ProdutoId);
        
        if (orcamento == null || produto == null)
        {
            throw new Exception("Orcamento ou Produto não encontrado");
        }
        
        var item = new ItemOrcamento();
        item.AdicionarOrcamento(orcamento);
        item.AdicionarProduto(produto, itemOrcamento.Quantidade, itemOrcamento.PrecoVenda);
        
        await context.ItemOrcamentos.AddAsync(item);
        await context.SaveChangesAsync();
        
    }
    public async Task<Orcamento> Update(Orcamento orcamento)
    {
        context.Orcamentos.Update(orcamento);
        await context.SaveChangesAsync();

        return orcamento;
    }
    
    public async Task Delete(Orcamento orcamento)
    {
        context.Orcamentos.Remove(orcamento);
        await context.SaveChangesAsync();
    }
    
    public async Task<Orcamento> Get(int id)
    {
        return await context.Orcamentos
            .Include(x=>x.Cliente)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<OrcamentoProdutoViewModel> GetOrcamentoComProdutoById(int id)
{
    var orcamento = await context.Orcamentos
        .Include(o => o.Cliente)
        .Include(o => o.Itens)
        .ThenInclude(i => i.Produto)
        .Where(o => o.Id == id)
        .FirstOrDefaultAsync();

    if (orcamento == null)
    {
        return null;
    }

    var orcamentoViewObject = new OrcamentoProdutoViewModel
    {
        Id = orcamento.Id,
        Cliente = new ClienteViewModel
        {
            Id = orcamento.Cliente.Id,
            Nome = orcamento.Cliente.Nome,
            Telefone = orcamento.Cliente.Telefone
        },
        Carro = orcamento.Carro,
        Placa = orcamento.Placa,
        Chassi = orcamento.Chassi,
        CreatedAt = orcamento.CreatedAt,
        UpdatedAt = orcamento.UpdatedAt,
        Itens = orcamento.Itens.Select(i => new ItensOrcamentoViewModel
        {
            Id = i.Produto.Id,
            NomeProduto = i.Produto.Nome,
            Sku = i.Produto.Sku,
            Marca = i.Produto.Marca,
            PrecoVenda = i.PrecoVenda,
            Quantidade = i.Quantidade
        }).ToList()
    };

    return orcamentoViewObject;
}
   
    public async Task<IEnumerable<Orcamento>> GetAll()
    {
        return await context.Orcamentos
            .AsNoTracking()
            .Include(x=>x.Cliente)
            .ToListAsync();
    }
    
    
}