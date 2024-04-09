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
    
    public async Task<Cliente> Update(int id, Cliente model)
    {
        var cliente = await context.Clientes.FirstOrDefaultAsync(x=>x.Id == id);
        if(cliente == null)
            throw new InvalidOperationException("Cliente não encontrado");
        cliente.AtualizarCliente(model.Nome, model.Telefone);
        context.Clientes.Update(cliente);
        await context.SaveChangesAsync();

        return cliente;
    }
    
    public async Task Delete(int id)
    {
        var cliente = await context.Clientes.FirstOrDefaultAsync(x=>x.Id == id);
        if(cliente == null)
            throw new InvalidOperationException("Cliente não encontrado");
        
        context.Clientes.Remove(cliente);
        await context.SaveChangesAsync();
    }
    
    public async Task<Cliente> GetById(int id)
    {
        var cliente = await context.Clientes.FirstOrDefaultAsync(x=>x.Id == id);
        if(cliente == null)
            throw new InvalidOperationException("Cliente não encontrado");
        
        return cliente;
    }
    
    public async Task<IEnumerable<Cliente>> GetAll()
    {
        return await context.Clientes
            .AsNoTracking()
            .ToListAsync();
    }
}