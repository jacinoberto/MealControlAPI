using AutoMapper;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Mappings;

public class DomainToHandlesProfile : Profile
{
    public DomainToHandlesProfile()
    {
        CreateMap<Meal, CreateMealCommand>()
           .ReverseMap();

        CreateMap<Meal, UpdateMealsCommand>()
            .ReverseMap();

        CreateMap<Worker, CreateWorkerCommand>()
            .ReverseMap();
    }
}
