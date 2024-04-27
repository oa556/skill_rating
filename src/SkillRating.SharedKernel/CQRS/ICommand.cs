using MediatR;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.SharedKernel.CQRS;

public interface ICommand : IRequest<Result>;

