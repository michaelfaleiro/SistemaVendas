using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.Api.Dto;
using SistemaVendas.Api.Models;
using SistemaVendas.Api.Services;

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
        var produto = _mapper.Map<Produto>(model); 
        
        var createdProduto = await _produtoService.Create(produto);
        return CreatedAtAction(nameof(Create), new { id = createdProduto.Id }, createdProduto);
    }
    
}