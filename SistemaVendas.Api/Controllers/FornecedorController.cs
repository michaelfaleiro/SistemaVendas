using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Extensions;
using SistemaVendas.Api.Models;
using SistemaVendas.Api.Services;
using SistemaVendas.Api.ViewsModels;

namespace SistemaVendas.Api.Controllers;

[ApiController]
[Route("api/fornecedores")]
public class FornecedorController:ControllerBase
{
    private readonly FornecedorService _fornecedorService;
    
    public FornecedorController(FornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Fornecedor fornecedor)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Fornecedor>(ModelState.GetErrors()));
        
        try
        {
            await _fornecedorService.Create(fornecedor);
            return CreatedAtAction(nameof(Create), new { id = fornecedor.Id },
                new ResultViewModel<Fornecedor>(fornecedor));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Erro ao salvar dados"));
        }
        catch (Exception e)
        {
            return BadRequest(new ResultViewModel<Fornecedor>("Falha Interna no Servidor" + e.Message));
        }
    }
}