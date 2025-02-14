using AutoMapper;
using Desafio5.Api.Dto;
using Desafio5.Domain.Entity;

namespace Desafio5.Api.Configurations;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Address, AddressDto>().ReverseMap();
    }
}