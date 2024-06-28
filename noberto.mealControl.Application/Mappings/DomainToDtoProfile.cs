using AutoMapper;
using noberto.mealControl.Application.DTOs.AddressDTO;
using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.DTOs.UserDTO;
using noberto.mealControl.Application.DTOs.WorkerDTO;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Entity;

namespace noberto.mealControl.Application.Mappings;

public class DomainToDtoProfile : Profile
{
    public DomainToDtoProfile()
    {
        CreateMap<Address, CreateAddressDTO>()
            .ReverseMap();

        CreateMap<Address, ReturnAddressDTO>()
            .ReverseMap();

        CreateMap<User, ReturnUsernameDTO>()
            .ReverseMap();

        CreateMap<Administrator, CreateAdministratorDTO>()
            .ForMember(administratorDto => administratorDto.Address,
            option => option.MapFrom(administrator => administrator.Address))
            .ReverseMap();

        CreateMap<Administrator, RecoverAdministratorPasswordDTO>()
            .ForMember(administratorDto => administratorDto.User,
            option => option.MapFrom(administrator => administrator.User))
            .ReverseMap();

        CreateMap<Manager, CreateManagerDTO>()
            .ForMember(managerDto => managerDto.Address,
            option => option.MapFrom(manager => manager.Address))
            .ReverseMap();

        CreateMap<Manager, ManagerSelectDTO>()
            .ForMember(managerDto => managerDto.User,
            option => option.MapFrom(manager => manager.User))
            .ReverseMap();

        CreateMap<Manager, RecoverManagerPasswordDTO>()
            .ForMember(managerDto => managerDto.User,
            option => option.MapFrom(manager => manager.User))
            .ReverseMap();

        CreateMap<Worker, CreateWorkerDTO>()
            .ReverseMap();

        CreateMap<Worker, ReturnWorkerDTO>()
            .ReverseMap();
    }
}
