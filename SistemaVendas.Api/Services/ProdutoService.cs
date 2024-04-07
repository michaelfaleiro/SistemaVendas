using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Data;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Services;

public class ProdutoService(ApiDbContext context)
{
    public async Task<Produto> Create(Produto produto)
    {
        await context.Produtos.AddAsync(produto);
        await context.SaveChangesAsync();

        return produto;
    }
    
    public async Task<Produto> Update(int id,Produto produto)
    {
        var produtoExistente = await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        if (produtoExistente == null)
            throw new InvalidOperationException("Produto não encontrado");
        
        context.Produtos.Update(produto);
        await context.SaveChangesAsync();

        return produto;
    }
    
    public async Task Delete(Produto produto)
    {
        context.Produtos.Remove(produto);
        await context.SaveChangesAsync();
    }
    
    public async Task<Produto?> GetById(int id)
    {
        return await context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<IEnumerable<Produto>> GetAll()
    {
        return await context.Produtos.AsNoTracking().ToListAsync();
    }
    
}