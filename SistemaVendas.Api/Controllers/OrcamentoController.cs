using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Dto;
using SistemaVendas.Api.Extensions;
using SistemaVendas.Api.Models;
using SistemaVendas.Api.Services;
using SistemaVendas.Api.ViewsModels;
using SistemaVendas.Api.ViewsObjects;

namespace SistemaVendas.Api.Controllers;

[ApiController]
[Route("api/orcamentos")]
public class OrcamentoController : ControllerBase
{
    private readonly OrcamentoService _orcamentoService;
    private readonly ClienteService _clienteService;
    private readonly IMapper _mapper;
    
    public OrcamentoController(OrcamentoService orcamentoService, IMapper mapper, ClienteService clienteService)
    {
        _orcamentoService = orcamentoService;
        _mapper = mapper;
        _clienteService = clienteService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrcamentoDto model)
    {

        try
        {
            var cliente = await _clienteService.GetById(model.ClienteId);
            if (cliente == null)
            {
                return BadRequest(new ResultViewModel<Orcamento>("Cliente não encontrado"));
            }
        
            var orcamento = new Orcamento();
        
            orcamento.AdicionarCliente(cliente);
            orcamento.AdicionarCarro(model.Carro, model.Placa, model.Chassi);
        
        
            var createdOrcamento = await _orcamentoService.Create(orcamento);
            return CreatedAtAction(nameof(Create), new { id = createdOrcamento.Id }, createdOrcamento);
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Orcamento>("Erro ao inserir dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
        }
    }
    
    [HttpPost]
    [Route("adicionar-item")]
    public async Task<IActionResult> AdicionarItem([FromBody] AdicionarItemOrcamentoViewModel model)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<AdicionarItemOrcamentoViewModel>(ModelState.GetErrors()));
        
        try
        {
            await _orcamentoService.AdicionarItem(model);
            return NoContent();
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<AdicionarItemOrcamentoViewModel>("Erro ao inserir dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<AdicionarItemOrcamentoViewModel>("Falha Interna no Servidor"));
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var orcamentos = await _orcamentoService.GetAll();
            return Ok(new ResultViewModel<IEnumerable<Orcamento>>(orcamentos));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Orcamento>("Erro ao inserir dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrcamentoComProdutoById(int id)
    {

        try
        {
            var orcamento = await _orcamentoService.GetOrcamentoComProdutoById(id);
        
            if (orcamento == null)
                return NotFound(new ResultViewModel<OrcamentoProdutoViewModel>("Orçamento não encontrado"));
            
            return Ok(new ResultViewModel<OrcamentoProdutoViewModel>(orcamento));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
     
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Orcamento orcamento)
    {
        if (id != orcamento.Id)
        {
            return BadRequest();
        }
        
        var updatedOrcamento = await _orcamentoService.Update(orcamento);
        return Ok(updatedOrcamento);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var orcamento = await _orcamentoService.Get(id);
        
        if (orcamento == null)
        {
            return NotFound();
        }
        
        await _orcamentoService.Delete(orcamento);
        return NoContent();
    }
    
    
}