using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Queries;

public class GetWorkByIdQuery : IRequest<Work>
{
    public Guid Id { get; set; }

    public GetWorkByIdQuery(Guid id)
    {
        Id = id;
    }
}
