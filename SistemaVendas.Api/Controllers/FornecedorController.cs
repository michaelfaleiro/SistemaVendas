using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Dto;
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
    private readonly IMapper _mapper;
    public FornecedorController(FornecedorService fornecedorService, IMapper mapper)
    {
        _fornecedorService = fornecedorService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EditorFornecedorDto model)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Fornecedor>(ModelState.GetErrors()));
        
        try
        {
            var fornecedor = _mapper.Map<Fornecedor>(model);
            
            await _fornecedorService.Create(fornecedor);
            return CreatedAtAction(nameof(Create), new { id = fornecedor.Id },
                new ResultViewModel<Fornecedor>(fornecedor));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Erro ao salvar dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Fornecedor>("Falha Interna no Servidor"));
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var fornecedores = await _fornecedorService.GetAll();
            return Ok(new ResultViewModel<IEnumerable<Fornecedor>>(fornecedores));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Erro ao buscar dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Fornecedor>("Falha Interna no Servidor"));
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {   
            var fornecedor = await _fornecedorService.GetById(id);
            
            return Ok(new ResultViewModel<Fornecedor>(fornecedor));
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(new ResultViewModel<Fornecedor>(e.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Erro ao buscar dados"));
        }
        catch (Exception)
        {
            return StatusCode(500,new ResultViewModel<Fornecedor>("Falha Interna no Servidor"));
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] EditorFornecedorDto model)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Fornecedor>(ModelState.GetErrors()));
        
        try
        {
            var fornecedor = _mapper.Map<Fornecedor>(model);
            
            var updatedFornecedor = await _fornecedorService.Update(id, fornecedor);
            return Ok(new ResultViewModel<Fornecedor>(updatedFornecedor));
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(new ResultViewModel<Fornecedor>(e.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Erro ao salvar dados"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Falha Interna no Servidor"));
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _fornecedorService.Delete(id);
            return NoContent();
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(new ResultViewModel<Fornecedor>(e.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Erro ao salvar dados"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Fornecedor>("Falha Interna no Servidor"));
        }
    }
}