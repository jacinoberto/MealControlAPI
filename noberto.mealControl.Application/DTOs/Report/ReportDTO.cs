namespace noberto.mealControl.Application.DTOs.Report;

public record ReportDTO(
    string Manager,
    string Sector,
    int Coffee,
    decimal CostOfCoffee,
    int Lunch,
    decimal CostOfLunch,
    int Dinner,
    decimal CostOfDinner,
    int TotalTeam,
    int TotalMeals,
    decimal TotalValue
    );
