namespace noberto.mealControl.Application.DTOs.MealDTO;

public record UpdateMealDinnerDTO(
    IEnumerable<DinnerDTO> Dinners,
    DateOnly MealDate
    );
