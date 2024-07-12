using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.ScheduleEventDTO;

public record SchedulePendingEventDTO(
    DateOnly MealDate,
    bool Atypical
    );
