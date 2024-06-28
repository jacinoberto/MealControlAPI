using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;

public class GetManagerByStateQuery : IRequest<IEnumerable<Manager>>
{
    public string State { get; set; }

    public GetManagerByStateQuery(string state)
    {
        State = state;
    }
}
