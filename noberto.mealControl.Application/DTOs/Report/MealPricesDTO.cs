namespace noberto.mealControl.Application.DTOs.Report;

public record MealPricesDTO(
    double Coffee,
    double Lunch,
    double Dinner,
    double totalValue
    );