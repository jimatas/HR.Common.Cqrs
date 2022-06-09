using HR.Common.Cqrs.Queries;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class InnerQueryHandlerWrapper<TQuery, TResult> : IQueryHandlerWrapper<TQuery, TResult>, IPrioritizable
        where TQuery : IQuery<TResult>
    {
        private readonly IList<string> output;

        public InnerQueryHandlerWrapper(IList<string> output)
        {
            this.output = output;
        }

        public Task<TResult> HandleAsync(TQuery query, HandlerDelegate<TResult> next, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(InnerQueryHandlerWrapper<TQuery, TResult>)}.{nameof(HandleAsync)}_Before");

            var taskResult = next();

            output.Add($"{nameof(InnerQueryHandlerWrapper<TQuery, TResult>)}.{nameof(HandleAsync)}_After");

            return taskResult;
        }

        // Should be the last to run, right before the query handler.
        public sbyte Priority => Priorities.Low;
    }
}
