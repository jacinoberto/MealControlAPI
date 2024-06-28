using AutoMapper;
using noberto.mealControl.Application.DTOs.AddressDTO;
using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Mappings;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<Address, CreateAddressDTO>()
            .ReverseMap();

        CreateMap<Address, ReturnAddressDTO>()
            .ReverseMap();

        CreateMap<Administrator, CreateAdministratorDTO>()
            .ForMember(administratorDto => administratorDto.Address,
            option => option.MapFrom(administrator => administrator.Address))
            .ReverseMap();
    }
}
