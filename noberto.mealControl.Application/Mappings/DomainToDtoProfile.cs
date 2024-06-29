using AutoMapper;
using noberto.mealControl.Application.DTOs.AddressDTO;
using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.TeamManagement;
using noberto.mealControl.Application.DTOs.UserDTO;
using noberto.mealControl.Application.DTOs.WorkDTO;
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

        CreateMap<Address, ReturnCityDTO>()
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

        CreateMap<Worker, ReturnWorkerNameDTO>()
            .ReverseMap();

        CreateMap<Work, CreateWorkDTO>()
            .ForMember(workDto => workDto.Address,
            option => option.MapFrom(work => work.Address))
            .ReverseMap();

        CreateMap<Work, WorkSelectDTO>()
            .ForMember(workDto => workDto.Address,
            option => option.MapFrom(work => work.Address))
            .ReverseMap();

        CreateMap<TeamManagement, CreateTeamManagementDTO>()
            .ReverseMap();

        CreateMap<TeamManagement, TeamManagementSelectDTO>()
            .ForMember(teamManagementDto => teamManagementDto.Manager,
            option => option.MapFrom(teamManagement => teamManagement.Manager))
            .ReverseMap();

        CreateMap<Team, CreateTeamDTO>()
            .ReverseMap();

        CreateMap<Team, ReturnTeamWorkerDTO>()
            .ForMember(teamDto => teamDto.Worker,
            option => option.MapFrom(team => team.Worker))
            .ReverseMap();

        CreateMap<ScheduleEvent, CreateScheduleEventDTO>()
            .ReverseMap();

        CreateMap<ScheduleLocalEvent, CreateScheduleLocalEventDTO>()
            .ReverseMap();

        CreateMap<Meal, CreateMealDTO>()
            .ReverseMap();

        CreateMap<Meal, ReturnMealDTO>()
            .ForMember(mealDto => mealDto.Worker,
            option => option.MapFrom(meal => meal.Team))
            .ReverseMap();
    }
}
