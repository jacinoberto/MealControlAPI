using MediatR;
using noberto.mealControl.Application.CQRS.WorkCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Handles;

public class GetWorksByStateQueryHandle
    : IRequestHandler<GetWorkByStateQuery, IEnumerable<Work>>
{
    private readonly IWorkRepository _repository;

    public GetWorksByStateQueryHandle(IWorkRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Work>> Handle(GetWorkByStateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetWorksByStateAsync(request.State);
    }
}
