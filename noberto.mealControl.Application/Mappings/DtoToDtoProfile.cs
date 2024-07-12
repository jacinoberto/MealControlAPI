using AutoMapper;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;

namespace noberto.mealControl.Application.Mappings;

public class DtoToDtoProfile : Profile
{
    public DtoToDtoProfile()
    {
        CreateMap<CreateScheduleEventDTO, SchedulePendingEventDTO>()
            .ReverseMap();
    }
}
