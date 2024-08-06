using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;

public class GetAllManagersQuery : IRequest<IEnumerable<Manager>>
{
}
