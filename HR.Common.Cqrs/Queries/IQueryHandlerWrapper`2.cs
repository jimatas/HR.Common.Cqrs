using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Queries
{
    /// <summary>
    /// Allows an implementor to wrap a query handler to dynamically add behavior. 
    /// The call to the query handler, or a successive wrapper, is abstracted into a function delegate, which is passed in to the <see cref="HandleAsync"/> method. 
    /// The back-to-back chaining of multiple wrappers effectively creates a processing pipeline.
    /// </summary>
    /// <typeparam name="TQuery">The type of the query.</typeparam>
    /// <typeparam name="TResult">The result type of the query.</typeparam>
    public interface IQueryHandlerWrapper<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, HandlerDelegate<TResult> next, CancellationToken cancellationToken);
    }
}
