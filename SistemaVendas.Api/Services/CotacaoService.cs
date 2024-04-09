using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Data;
using SistemaVendas.Api.Models;
using SistemaVendas.Api.ViewsModels.CotacaoViewsModels;


namespace SistemaVendas.Api.Services;

public class CotacaoService(ApiDbContext context)
{
    public async Task<Cotacao> Create(Cotacao cotacao)
    {
        await context.Cotacoes.AddAsync(cotacao);
        await context.SaveChangesAsync();
        return cotacao;
    }
    
    public async Task AdicionarItemNaCotacao(AdicionarItemCotacaoViewModel itemCotacao)
    {
        var cotacao = context.Cotacoes.FirstOrDefault(x => x.Id == itemCotacao.IdCotacao);
        if(cotacao == null)
            throw new InvalidOperationException("Cotação não encontrada");

        var item = new ItemCotacao(
            itemCotacao.Sku,
            itemCotacao.Nome, 
            itemCotacao.Quantidade);
        
        item.AdicionarCotacao(cotacao);
        
        await context.ItemCotacoes.AddAsync(item);
        await context.SaveChangesAsync();
    }
    
    public async Task AdicionarPrecoNoItemCotacao(AdicionarPrecoCotacaoViewModel precoCotacaoViewModel)
    {
        var item = context.ItemCotacoes.FirstOrDefault(x => x.Id == precoCotacaoViewModel.IdCotacao);
        if(item == null)
            throw new InvalidOperationException("Item não encontrado");
        
        var fornecedor = context.Fornecedores.FirstOrDefault(x=> x.Id == precoCotacaoViewModel.IdFornecedor);
        if(fornecedor == null)
            throw new InvalidOperationException("Fornecedor não encontrado");
        
        var preco = new CotacaoProdutoPreco(
            precoCotacaoViewModel.Sku,
            precoCotacaoViewModel.Nome,
            precoCotacaoViewModel.Marca,
            precoCotacaoViewModel.PrecoCusto,
            precoCotacaoViewModel.PrecoVenda,
            precoCotacaoViewModel.Quantidade);
        
        preco.AdicionarFornecedor(fornecedor);
        preco.AdicionarItemCotacao(item);
        
        await context.CotacaoProdutoPrecos.AddAsync(preco);
        await context.SaveChangesAsync();
    }
        
    public async Task AtualizarPrecoNoItemCotacao(AdicionarPrecoCotacaoViewModel precoCotacaoViewModel)
    {
        var preco = context.CotacaoProdutoPrecos.FirstOrDefault(x => x.Id == precoCotacaoViewModel.IdCotacao);
        if(preco == null)
            throw new InvalidOperationException("Preço não encontrado");
        
        var fornecedor = context.Fornecedores.FirstOrDefault(x=> x.Id == precoCotacaoViewModel.IdFornecedor);
        if(fornecedor == null)
            throw new InvalidOperationException("Fornecedor não encontrado");
        
        preco.AtualizarPreco(
            precoCotacaoViewModel.Sku,
            precoCotacaoViewModel.Nome,
            precoCotacaoViewModel.Marca,
            precoCotacaoViewModel.PrecoCusto,
            precoCotacaoViewModel.PrecoVenda,
            precoCotacaoViewModel.Quantidade);
        
        preco.AdicionarFornecedor(fornecedor);
        
        await context.SaveChangesAsync();
    }

    public async Task<ListarItemComPrecosViewModel> GetItemComPrecosById(int idCotacao)
    {
        var cotacaoItens = await context.ItemCotacoes
            .Include(i => i.Precos)
            .Select(i => new ListarItemComPrecosViewModel
            {
                Id = i.Id,
                Sku = i.Sku,
                Nome = i.Nome,
                Precos = i.Precos.Select(p => new Preco
                {
                    Id = p.Id,
                    Marca = p.Marca,
                    PrecoCusto = p.PrecoCusto,
                    PrecoVenda = p.PrecoVenda,
                    Quantidade = p.Quantidade,
                    Fornecedor = p.Fornecedor.Nome
                }).ToList()
            })
            .FirstOrDefaultAsync(x=> x.Id == idCotacao);

        if (cotacaoItens == null)
            throw new InvalidOperationException("Cotaçao não encontrada");
        
        return cotacaoItens;
    }
    
    public async Task<ListarCotacaoComItensEPrecosViewModel> GetCotacaoComItensEPrecosById(int idCotacao)
    {
        var cotacao = await context.Cotacoes
            .AsNoTracking()
            .Include(c => c.ItemCotacaos)
                .ThenInclude(i => i.Precos)
            .Select(c => new ListarCotacaoComItensEPrecosViewModel
            {
                Id = c.Id,
                CreatedAt = c.CreatedAt,
                UpdateAt = c.UpdateAt,
                Veiculo = c.Veiculo, // Convert Veiculo to string
                Itens = c.ItemCotacaos.Select(i => new ItemCotacaoViewModel
                {
                    Id = i.Id,
                    Sku = i.Sku,
                    Nome = i.Nome,
                    Quantidade = i.Quantidade,
                    Precos = i.Precos.Select(p => new PrecoProduto()
                    {
                        Id = p.Id,
                        Marca = p.Marca,
                        PrecoCusto = (decimal)p.PrecoCusto, // Convert double to decimal
                        PrecoVenda = (decimal)p.PrecoVenda, // Convert double to decimal
                        Quantidade = p.Quantidade,
                        Fornecedor = p.Fornecedor.Nome
                    }).ToList()
                }).ToList()
            })
            .FirstOrDefaultAsync(c => c.Id == idCotacao);

        if (cotacao == null)
            throw new InvalidOperationException("Cotação não encontrada");    
        
        return cotacao;
    }
}