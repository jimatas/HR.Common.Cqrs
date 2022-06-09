using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Queries
{
    /// <summary>
    /// Defines the interface for a class that dispatches queries.
    /// </summary>
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}
