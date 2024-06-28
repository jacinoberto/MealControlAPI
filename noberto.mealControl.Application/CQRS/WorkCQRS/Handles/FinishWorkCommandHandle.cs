using MediatR;
using noberto.mealControl.Application.CQRS.WorkCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.WorkCQRS.Handles;

public class FinishWorkCommandHandle
    : IRequestHandler<FinishWorkCommand, Work>
{
    private readonly IWorkRepository _repository;

    public FinishWorkCommandHandle(IWorkRepository repository)
    {
        _repository = repository;
    }

    public async Task<Work> Handle(FinishWorkCommand request, CancellationToken cancellationToken)
    {
        return await _repository.FinishWorkAsync(request.Id);
    }
}
