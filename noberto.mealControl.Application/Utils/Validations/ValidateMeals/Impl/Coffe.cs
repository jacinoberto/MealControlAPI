using noberto.mealControl.Application.DTOs.MealDTO;

namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;

public class Coffe
{
    public void Validate(ReturnMealDTO returnMealDto, UpdateMealDTO updateMealDto)
    {
        if (returnMealDto.Coffe != updateMealDto.Coffe)
        {

        }
    }
}
