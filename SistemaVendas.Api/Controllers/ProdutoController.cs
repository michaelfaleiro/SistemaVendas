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
[Route("api/produtos")]
public class ProdutoController: ControllerBase
{
    private readonly ProdutoService _produtoService;
    private readonly IMapper _mapper;
    
    public ProdutoController(ProdutoService produtoService, IMapper mapper)
    {
        _produtoService = produtoService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(EditorProdutoDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(new ResultViewModel<Produto>(ModelState.GetErrors()));
        try
        {
            var produto = _mapper.Map<Produto>(model);

            var createdProduto = await _produtoService.Create(produto);
            return CreatedAtAction(nameof(Create),
                new { id = createdProduto.Id }, new ResultViewModel<Produto>(produto));
        }
        catch (DbUpdateException)
        {
            return StatusCode(500, new ResultViewModel<Produto>("Erro ao criar dados"));
        }
        catch (Exception)
        {
            return BadRequest(new ResultViewModel<Produto>("Falha Interna no Servidor"));
        }
    }

    [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var produtos = await _produtoService.GetAll();
                return Ok(new ResultViewModel<IEnumerable<Produto>>(produtos));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Produto>("Erro ao buscar dados"));
            }
            catch (Exception)
            {
                return BadRequest(new ResultViewModel<IEnumerable<Produto>>("Falha Interna no Servidor"));
            }
        }
    
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var produto = await _produtoService.GetById(id);
                if (produto == null)
                    return NotFound(new ResultViewModel<Produto>("Produto não encontrado"));
                return Ok(new ResultViewModel<Produto>(produto));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Produto>("Erro ao buscar dados"));
            }
            catch (Exception)
            {
                return BadRequest(new ResultViewModel<Produto>("Falha Interna no Servidor"));
            }
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, EditorProdutoDto model)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Produto>(ModelState.GetErrors()));
            try
            {
                var produto = _mapper.Map<Produto>(model);
                var updatedProduto = await _produtoService.Update(id, produto);
                return Ok(new ResultViewModel<Produto>(updatedProduto));
            }
            catch (InvalidOperationException e)
            {
                return NotFound(new ResultViewModel<Produto>(e.Message));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Produto>("Erro ao atualizar dados"));
            }
            catch (Exception)
            {
                return BadRequest(new ResultViewModel<Produto>("Falha Interna no Servidor"));
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = await _produtoService.GetById(id);
                if (produto == null)
                    return NotFound(new ResultViewModel<Produto>("Produto não encontrado"));
                await _produtoService.Delete(produto);
                return Ok(new ResultViewModel<Produto>(produto));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Produto>("Erro ao deletar dados"));
            }
            catch (Exception)
            {
                return BadRequest(new ResultViewModel<Produto>("Falha Interna no Servidor"));
            }
        }
    
    
}