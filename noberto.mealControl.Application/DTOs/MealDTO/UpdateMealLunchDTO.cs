namespace noberto.mealControl.Application.DTOs.MealDTO;

public record UpdateMealLunchDTO(
    IEnumerable<LunchDTO> Lunches,
    DateOnly MealDate
    );
