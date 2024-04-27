using MediatR;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.SharedKernel.CQRS;

public interface ICommandHandler<in TCommand>
    : IRequestHandler<TCommand, Result> where TCommand : ICommand;
