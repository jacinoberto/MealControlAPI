namespace noberto.mealControl.Application.DTOs.Report;

public record ReportDTO(
    string Manager,
    string Sector,
    int Coffee,
    double CostOfCoffee,
    int Lunch,
    double CostOfLunch,
    int Dinner,
    double CostOfDinner,
    int TotalTeam,
    int TotalMeals,
    double TotalValue
    );
