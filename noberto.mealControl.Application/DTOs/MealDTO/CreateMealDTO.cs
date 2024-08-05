namespace noberto.mealControl.Application.DTOs.MealDTO;

public record struct CreateMealDTO(
    bool Coffe,
    bool Launch,
    bool Dinner,
    Guid? AdministratorId,
    Guid TeamId,
    Guid ScheduleLocalEventId
    );
