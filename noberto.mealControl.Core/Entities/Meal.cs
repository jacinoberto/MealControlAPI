using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Core.Entities;

public class Meal : Identifier
{
    public bool Coffe { get; private set; }
    public bool Lunch { get; private set; }
    public bool Dinner { get; private set; }

    public Guid TeamId { get; private set; }
    public Team Team { get; private set; }
    public Guid ShecheduleLocalEventId { get; set; }
    public ScheduleLocalEvent ScheduleLocalEvent { get; set; }

    public Meal(bool coffe, bool lunch, bool dinner)
    {
        ValidateMealData(coffe, lunch, dinner);
    }

    /// <summary>
    /// Validar dados informados para instanciar uma nova Refeição
    /// </summary>
    /// <param name="coffe"></param>
    /// <param name="lunch"></param>
    /// <param name="dinner"></param>
    private void ValidateMealData(bool coffe, bool lunch, bool dinner)
    {
        InvalidEntityDataException.When(coffe == null,
            BadInternalOrdersEnum.CoffeIsNull.ToString());

        InvalidEntityDataException.When(lunch == null,
            BadInternalOrdersEnum.LunchIsNull.ToString());

        InvalidEntityDataException.When(dinner == null,
            BadInternalOrdersEnum.DinnerIsNull.ToString());

        Coffe = coffe;
        Lunch = lunch;
        Dinner = dinner;
    }

    /// <summary>
    /// Atualizar Refeições
    /// </summary>
    /// <param name="coffe"></param>
    /// <param name="lunch"></param>
    /// <param name="dinner"></param>
    public void UpdateMeal(bool coffe, bool lunch, bool dinner)
    {
        Coffe = coffe;
        Lunch = lunch;
        Dinner = dinner;
    }
}
