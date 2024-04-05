using AutoMapper;
using SistemaVendas.Api.Dto;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Profiles;

public class ProdutoDto: Profile
{
    public ProdutoDto()
    {
        CreateMap<EditorProdutoDto, Produto>().ReverseMap();
    }
    
}