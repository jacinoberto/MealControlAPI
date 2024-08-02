using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;

namespace noberto.mealControl.Application.DTOs.MealDTO;

public record MealReturnForUpdate(
    Guid Id,
    bool Coffe,
    bool Lunch,
    bool Dinner,
    ReturnScheduleLocalEventDTO ScheduleLocalEvent
    );
