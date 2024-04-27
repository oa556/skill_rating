using MediatR;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.SharedKernel.CQRS;

public interface IQueryHandler<in TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>;
