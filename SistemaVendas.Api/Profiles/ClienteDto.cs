using AutoMapper;
using SistemaVendas.Api.Dto;
using SistemaVendas.Api.Models;

namespace SistemaVendas.Api.Profiles;

public class ClienteDto:Profile
{
    public ClienteDto()
    {
        CreateMap<EditorClienteDto, Cliente>().ReverseMap();
    }
}