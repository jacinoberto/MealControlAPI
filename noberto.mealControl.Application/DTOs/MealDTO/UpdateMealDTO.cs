namespace noberto.mealControl.Application.DTOs.MealDTO;

public record UpdateMealDTO(
    Guid Id,
    bool Coffe,
    bool Lunch,
    bool Dinner
    );
