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
[Route("api/clientes")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;
    private readonly IMapper _mapper;
    
    public ClienteController(ClienteService clienteService, IMapper mapper)
    {
        _clienteService = clienteService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(EditorClienteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cliente>(ModelState.GetErrors()));

        var cliente = _mapper.Map<Cliente>(dto);
        try
        {
            var createdCliente = await _clienteService.Create(cliente);
            return CreatedAtAction(nameof(Create), new { id = createdCliente.Id }, createdCliente);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("Erro ao inserir dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Cliente>("Falha Interna no Servidor"));
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var clientes = await _clienteService.GetAll();
            return Ok(new ResultViewModel<IEnumerable<Cliente>>(clientes));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("Erro ao buscar dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Cliente>("Falha Interna no Servidor"));
        }
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var cliente = await _clienteService.GetById(id);
            return Ok(new ResultViewModel<Cliente>(cliente));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("Erro ao buscar dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Cliente>("Falha Interna no Servidor"));
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, EditorClienteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cliente>(ModelState.GetErrors()));
        try
        {
            var cliente = await _clienteService.GetById(id);
            if (cliente == null)
                return NotFound(new ResultViewModel<Cliente>("Cliente não encontrado"));
            
            cliente = _mapper.Map(dto, cliente);
            
            var updatedCliente = await _clienteService.Update(cliente);
            return Ok(new ResultViewModel<Cliente>(updatedCliente));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("Erro ao alterar dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Cliente>("Falha Interna no Servidor"));
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var cliente = await _clienteService.GetById(id);
        
            if (cliente == null)
            {
                return NotFound(new ResultViewModel<Cliente>("Cliente não encontrado"));
            }
        
            await _clienteService.Delete(cliente);
            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("Erro ao deletar dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Cliente>("Falha Interna no Servidor"));
        }
    }
}
