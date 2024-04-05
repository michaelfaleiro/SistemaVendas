using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Data;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Services;

public class ClienteService(ApiDbContext context)
{
    public async Task<Cliente> Create(Cliente cliente)
    {
        await context.Clientes.AddAsync(cliente);
        await context.SaveChangesAsync();

        return cliente;
    }
    
    public async Task<Cliente> Update(Cliente cliente)
    {
        context.Clientes.Update(cliente);
        await context.SaveChangesAsync();

        return cliente;
    }
    
    public async Task Delete(Cliente cliente)
    {
        context.Clientes.Remove(cliente);
        await context.SaveChangesAsync();
    }
    
    public async Task<Cliente?> GetById(int id)
    {
        return await context.Clientes.FirstOrDefaultAsync(x=>x.Id == id);
    }
    
    public async Task<IEnumerable<Cliente>> GetAll()
    {
        return await context.Clientes
            .AsNoTracking()
            .ToListAsync();
    }
}