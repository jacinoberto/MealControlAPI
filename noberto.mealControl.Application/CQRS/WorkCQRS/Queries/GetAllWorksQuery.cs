using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Queries;

public class GetAllWorksQuery : IRequest<IEnumerable<Work>>
{
}
