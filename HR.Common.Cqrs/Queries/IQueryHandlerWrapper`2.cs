using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Queries
{
    /// <summary>
    /// Defines the interface for a set of classes that wrap a query handler in order to create a processing pipeline.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The result type of the query.</typeparam>
    public interface IQueryHandlerWrapper<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, HandlerDelegate<TResult> next, CancellationToken cancellationToken);
    }
}
