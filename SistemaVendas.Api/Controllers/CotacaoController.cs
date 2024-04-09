using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Api.Dto;
using SistemaVendas.Api.Extensions;
using SistemaVendas.Api.Models;
using SistemaVendas.Api.Services;
using SistemaVendas.Api.ViewsModels;
using SistemaVendas.Api.ViewsModels.CotacaoViewsModels;

namespace SistemaVendas.Api.Controllers;

[ApiController]
[Route("api/cotacoes")]
public class CotacaoController:ControllerBase
{
    private readonly CotacaoService _cotacaoService;
    private readonly IMapper _mapper;
    
    public CotacaoController(CotacaoService cotacaoService, IMapper mapper)
    {
        _cotacaoService = cotacaoService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EditorCotacaoDto cotacaoDto)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cotacao>(ModelState.GetErrors()));
        
        try
        {
            var cotacao = new Cotacao();
            
            cotacao.AdicionarVeiculo(
                cotacaoDto.Carro,
                cotacaoDto.Placa,
                cotacaoDto.Chassi,
                cotacaoDto.Motor,
                cotacaoDto.Ano,
                cotacaoDto.Combustivel);
            
            await _cotacaoService.Create(cotacao);
            return CreatedAtAction(nameof(Create), new { id = cotacao.Id }, new ResultViewModel<Cotacao>(cotacao));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cotacao>("Erro ao salvar dados"));
        }
        catch (Exception)
        {
            return StatusCode(500,new ResultViewModel<Cotacao>("Falha Interna no Servidor"));
        }
    }

    [HttpPost]
    [Route("adicionar-item")]
    public async Task<IActionResult> AdicionarItemNaCotacao([FromBody] AdicionarItemCotacaoViewModel model)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cotacao>(ModelState.GetErrors()));

        try
        {
            await _cotacaoService.AdicionarItemNaCotacao(model);
            return NoContent();
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(new ResultViewModel<Cotacao>(e.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cotacao>("Erro ao salvar dados"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Cotacao>("Falha Interna no Servidor"));
        }
    }
    
    [HttpPost("adicionar-preco")]
    public async Task<IActionResult> AdicionarPrecoNaCotacao([FromBody]AdicionarPrecoCotacaoViewModel  model)
    {
        if(!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Cotacao>(ModelState.GetErrors()));

        try
        {
            await _cotacaoService.AdicionarPrecoNoItemCotacao(model);
            return NoContent();
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(new ResultViewModel<Cotacao>(e.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cotacao>("Erro ao salvar dados"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Cotacao>("Falha Interna no Servidor"));
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCotacaoComPrecos(int id)
    {
        try
        {
            var cotacao = await _cotacaoService.GetCotacaoComItensEPrecosById(id);
            
            return Ok(new ResultViewModel<ListarCotacaoComItensEPrecosViewModel>(cotacao));
        }
        catch (InvalidOperationException e)
        {
            return NotFound(new ResultViewModel<Cotacao>(e.Message));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Cotacao>("Erro ao buscar dados"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResultViewModel<Cotacao>("Falha Interna no Servidor"));
        }
        
    }
    
}