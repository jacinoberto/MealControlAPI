using AutoMapper;
using noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Commands;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Commands;
using noberto.mealControl.Application.CQRS.TeamCQRS.Commands;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;
using noberto.mealControl.Application.CQRS.WorkCQRS.Commands;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.TeamManagement;
using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Application.DTOs.WorkerDTO;

namespace noberto.mealControl.Application.Mappings;

public class DtoToCommandsProfile : Profile
{
    public DtoToCommandsProfile()
    {
        CreateMap<CreateAdministratorDTO, CreateManagerCommand>()
            .ForMember(administratorCommand => administratorCommand.Address,
            option => option.MapFrom(administratorDto => administratorDto.Address))
            .ReverseMap();

        CreateMap<CreateManagerDTO, CreateManagerCommand>()
            .ForMember(managerCommand => managerCommand.Address,
            option => option.MapFrom(managerDto => managerDto.Address))
            .ReverseMap();

        CreateMap<CreateWorkerDTO, CreateWorkerCommand>()
            .ReverseMap();

        CreateMap<CreateWorkDTO, CreateWorkCommand>()
            .ForMember(workCommand => workCommand.Address,
            option => option.MapFrom(workDto => workDto.Address))
            .ReverseMap();

        CreateMap<CreateTeamDTO, CreateTeamCommand>()
            .ReverseMap();

        CreateMap<CreateTeamManagementDTO, CreateTeamManagementCommand>()
            .ReverseMap();

        CreateMap<CreateScheduleEventDTO, CreateScheduleEventCommand>()
            .ReverseMap();

        CreateMap<CreateScheduleLocalEventDTO, CreateScheduleLocalEventCommand>()
            .ReverseMap();

        CreateMap<CreateMealDTO, CreateMealCommand>()
            .ReverseMap();
    }
}
