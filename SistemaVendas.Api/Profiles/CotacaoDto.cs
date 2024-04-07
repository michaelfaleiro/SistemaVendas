using AutoMapper;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Profiles;

public class CotacaoDto:Profile
{
    public CotacaoDto()
    {
        CreateMap<CotacaoDto, Cotacao>().ReverseMap();
    }
}