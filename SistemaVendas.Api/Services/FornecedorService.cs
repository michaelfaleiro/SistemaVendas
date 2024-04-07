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
    
}