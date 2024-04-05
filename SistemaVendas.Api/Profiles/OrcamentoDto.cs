using AutoMapper;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Profiles;

public class OrcamentoDto: Profile
{
    public OrcamentoDto()
    {
        CreateMap<OrcamentoDto, Orcamento>().ReverseMap();
    }
    
}