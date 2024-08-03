namespace noberto.mealControl.Application.DTOs.MealDTO;

public record UpdateMealCoffeeDTO(
    IEnumerable<CoffeeDTO> Coffees,
    DateOnly MealDate
    );
