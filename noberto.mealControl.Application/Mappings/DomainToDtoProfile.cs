using AutoMapper;
using noberto.mealControl.Application.DTOs.AddressDTO;
using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.TeamManagement;
using noberto.mealControl.Application.DTOs.TeamManagementDTO;
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

        CreateMap<Manager, ReturnManagerLoginDTO>()
            .ForMember(managerDto => managerDto.User,
            option => option.MapFrom(manager => manager.User))
            .ReverseMap();

        CreateMap<Manager, ReturnManagerUsernameDTO>()
            .ForMember(managerDto => managerDto.User,
            option => option.MapFrom(manager => manager.User))
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

        CreateMap<Work, ReturnWorkDTO>()
            .ReverseMap();

        CreateMap<Work, WorkSelectDTO>()
            .ForMember(workDto => workDto.Address,
            option => option.MapFrom(work => work.Address))
            .ReverseMap();

        CreateMap<TeamManagement, CreateTeamManagementDTO>()
            .ReverseMap();

        CreateMap<TeamManagement, ReturnTeamManagementDTO>()
            .ReverseMap();

        CreateMap<TeamManagement, ReturnTeamManagementSectorDTO>()
            .ReverseMap();

        CreateMap<TeamManagement, TeamManagementSelectDTO>()
            .ForMember(teamManagementDto => teamManagementDto.Manager,
            option => option.MapFrom(teamManagement => teamManagement.Manager))
            .ReverseMap();

        CreateMap<TeamManagement, ReturnTeamManagementByManagerIdDTO>()
            .ForMember(teamDto => teamDto.Manager,
            option => option.MapFrom(team => team.Manager))
            .ReverseMap();

        CreateMap<Team, CreateTeamDTO>()
            .ReverseMap();

        CreateMap<Team, ReturnTeamDTO>()
            .ForMember(teamDto => teamDto.TeamManagement,
            option => option.MapFrom(team => team.TeamManagement))
            .ReverseMap();

        CreateMap<Team, ReturnTeamWorkerDTO>()
            .ForMember(teamDto => teamDto.Worker,
            option => option.MapFrom(team => team.Worker))
            .ReverseMap();

        CreateMap<Team, ReturnTeamWorkDTO>()
            .ForMember(teamDto => teamDto.Work,
            option => option.MapFrom(team => team.TeamManagement.Work))
            .ReverseMap();        

        CreateMap<ScheduleEvent, CreateScheduleEventDTO>()
            .ReverseMap();

        CreateMap<ScheduleEvent, ReturnScheduleEventDTO>()
            .ReverseMap();

        CreateMap<ScheduleLocalEvent, CreateScheduleLocalEventDTO>()
            .ReverseMap();

        CreateMap<ScheduleLocalEvent, ReturnScheduleLocalEventDTO>()
            .ForMember(scheduleDto => scheduleDto.Work,
            option => option.MapFrom(schedule => schedule.Work))
            .ReverseMap()
            .ForMember(schedule => schedule.ScheduleEvent,
            option => option.MapFrom(scheduleDto => scheduleDto.ScheduleEvent))
            .ReverseMap();

        CreateMap<Meal, CreateMealDTO>()
            .ReverseMap();

        CreateMap<Meal, ReturnMealDTO>()
            .ForMember(mealDto => mealDto.Worker,
            option => option.MapFrom(meal => meal.Team))
            .ReverseMap();

        CreateMap<Meal, ReturnCoffesDTO>()
            .ForMember(mealDto => mealDto.Team,
            option => option.MapFrom(meal => meal.Team))
            .ReverseMap();

        CreateMap<Meal, ReturnDinnersDTO>()
            .ForMember(mealDto => mealDto.Team,
            option => option.MapFrom(meal => meal.Team))
            .ReverseMap();

        CreateMap<Meal, ReturnLunchesDTO>()
            .ForMember(mealDto => mealDto.Team,
            option => option.MapFrom(meal => meal.Team))
            .ReverseMap();

        CreateMap<Meal, MealReturnForUpdate>()
            .ForMember(mealDto => mealDto.ScheduleLocalEvent,
            option => option.MapFrom(meal => meal.ScheduleLocalEvent))
            .ReverseMap();
    }
}
