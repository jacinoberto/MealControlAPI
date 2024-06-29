using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;

namespace noberto.mealControl.Application.DTOs.MealDTO;

public record struct ReturnMealDTO(
    ReturnTeamWorkerDTO Worker,
    bool Coffe,
    bool Lunch,
    bool Dinner
    );
