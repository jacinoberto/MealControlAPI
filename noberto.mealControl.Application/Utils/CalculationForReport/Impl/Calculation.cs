using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.Report;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Utils.CalculationForReport.Impl;

public class Calculation : ICalculation
{
    private readonly ITeamService _teamService;
    private readonly ITeamManagementService _teamManagementService;
    private readonly IMediator _mediator;

    public Calculation(IMediator mediator, ITeamService teamService, ITeamManagementService teamManagementService)
    {
        _mediator = mediator;
        _teamService = teamService;
        _teamManagementService = teamManagementService;
    }

    public async Task<IEnumerable<ReportDTO>> Execute(DateOnly startDate, DateOnly closingDate, Guid managerId)
    {
        ICollection<ReportDTO> reports = [];
        var teamManagements = await _teamManagementService.GetTeamManagementByManagerIdAsync(managerId);

        foreach (var teamManagement in teamManagements)
        {
            var managers = await _teamManagementService.GetTeamManagementByManagerId(managerId);

            var meals = await _mediator.Send(new GetMealByStartDateAndClosingDateAndManagerIdQuery(
                startDate, closingDate, managerId));

            var totalTeam = await _teamService.GetTeamByManagerIdAsync(managerId);

            var totalCoffees = meals.Where(meal => meal.Coffee == true).Count();
            var totalLunches = meals.Where(meal => meal.Lunch == true).Count();
            var totalDinners = meals.Where(meal => meal.Dinner == true).Count();

            var mealPrices = CalculateTotals(totalCoffees, totalLunches, totalDinners);

            int totalMeals = totalCoffees + totalLunches + totalDinners;

            foreach (var manager in managers)
            {
                reports.Add(new ReportDTO(
                    manager.Manager.User.Name,
                    manager.Sector,
                    totalCoffees,
                    mealPrices.Coffee,
                    totalLunches,
                    mealPrices.Lunch,
                    totalDinners,
                    mealPrices.Dinner,
                    totalTeam.Count(),
                    totalMeals,
                    mealPrices.totalValue
                    ));
            }
        }

        return reports;
    }

    private MealPricesDTO CalculateTotals(int totalCoffees, int totalLunches, int totalDinners)
    {
        double coffee = totalCoffees * 11.00;
        double lunch = totalLunches * 23.00;
        double dinner = totalDinners * 21.00;
        double totalValue = coffee + lunch + dinner;

        return new MealPricesDTO(coffee, lunch, dinner, totalValue);
    }
}
