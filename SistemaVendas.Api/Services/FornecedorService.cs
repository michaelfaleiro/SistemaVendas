using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Data;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Services;

public class FornecedorService(ApiDbContext context)
{
    public async Task<Fornecedor> Create(Fornecedor fornecedor)
    {
        await context.Fornecedores.AddAsync(fornecedor);
        await context.SaveChangesAsync();
        return fornecedor;
    }
    
    public async Task<IEnumerable<Fornecedor>> GetAll()
    {
        return await context.Fornecedores
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<Fornecedor> GetById(int id)
    {
        var fornecedor = await context.Fornecedores.FirstOrDefaultAsync(x=>x.Id == id);
        if(fornecedor == null)
            throw new InvalidOperationException("Fornecedor não encontrado");

        return fornecedor;
    }
    
    public async Task<Fornecedor> Update(int id, Fornecedor model)
    {
        var fornecedor = await context.Fornecedores.FirstOrDefaultAsync(x=>x.Id == id);
        if(fornecedor == null)
            throw new InvalidOperationException("Fornecedor não encontrado");
        fornecedor.AtualizarFornecedor(model.Nome, model.Telefone, model.Vendedor);
        
        context.Fornecedores.Update(fornecedor);
        await context.SaveChangesAsync();

        return fornecedor;
    }
    
    public async Task Delete(int id)
    {
        var fornecedor = await context.Fornecedores.FirstOrDefaultAsync(x=>x.Id == id);
        if(fornecedor == null)
            throw new InvalidOperationException("Fornecedor não encontrado");
        
        context.Fornecedores.Remove(fornecedor);
        await context.SaveChangesAsync();
    }
}