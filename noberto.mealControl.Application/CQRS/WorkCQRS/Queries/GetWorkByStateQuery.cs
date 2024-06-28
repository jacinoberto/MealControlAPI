using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Queries;

public class GetWorkByStateQuery : IRequest<IEnumerable<Work>>
{
    public string State { get; set; }

    public GetWorkByStateQuery(string state)
    {
        State = state;
    }
}
