using HR.Common.Cqrs.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class InnerCommandHandlerWrapper<TCommand> : ICommandHandlerWrapper<TCommand>, IPrioritizable
        where TCommand : ICommand
    {
        private readonly IList<string> output;

        public InnerCommandHandlerWrapper(IList<string> output)
        {
            this.output = output;
        }

        public Task HandleAsync(TCommand command, HandlerDelegate next, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(InnerCommandHandlerWrapper<TCommand>)}.{nameof(HandleAsync)}_Before");

            var taskResult = next();

            output.Add($"{nameof(InnerCommandHandlerWrapper<TCommand>)}.{nameof(HandleAsync)}_After");

            return taskResult;
        }

        public sbyte Priority => Priorities.Low;
    }
}
