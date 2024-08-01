using MediatR;
using noberto.mealControl.Application.CQRS.WorkCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Handles;

public class GetAllWorksQueryHandle
    : IRequestHandler<GetAllWorksQuery, IEnumerable<Work>>
{
    private readonly IWorkRepository _repository;

    public GetAllWorksQueryHandle(IWorkRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Work>> Handle(GetAllWorksQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetAllWorksAsync();
    }
}
