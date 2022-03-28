using System.Threading.Tasks;

namespace HR.Common.Cqrs
{
    /// <summary>
    /// A function delegate that represents the call to the next query handler wrapper in a processing pipeline, or eventually the query handler itself.
    /// </summary>
    /// <typeparam name="TResult">The result type of the query.</typeparam>
    /// <returns>An awaitable task with the result of the query.</returns>
    public delegate Task<TResult> HandlerDelegate<TResult>();
}
