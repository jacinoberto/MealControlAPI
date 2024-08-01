using MediatR;
using noberto.mealControl.Application.CQRS.WorkCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Handles;

public class GetQueryWorkByIdQueryHandle
    : IRequestHandler<GetWorkByIdQuery, Work>
{
    private readonly IWorkRepository _repository;

    public GetQueryWorkByIdQueryHandle(IWorkRepository repository)
    {
        _repository = repository;
    }

    public async Task<Work> Handle(GetWorkByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetWorkByIdAsync(request.Id);
    }
}
