using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Queries
{
    /// <summary>
    /// Defines the interface for a query handler.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The result type of the query.</typeparam>
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}
