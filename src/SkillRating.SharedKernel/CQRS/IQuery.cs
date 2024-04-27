using MediatR;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.SharedKernel.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
