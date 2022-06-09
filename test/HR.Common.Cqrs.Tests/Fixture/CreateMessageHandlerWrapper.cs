using HR.Common.Cqrs.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class CreateMessageHandlerWrapper : ICommandHandlerWrapper<CreateMessage>, IPrioritizable
    {
        private readonly IList<string> output;

        public CreateMessageHandlerWrapper(IList<string> output = null)
        {
            this.output = output ?? new List<string>();
        }

        public Task HandleAsync(CreateMessage command, HandlerDelegate next, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(CreateMessageHandlerWrapper)}.{nameof(HandleAsync)}_Before");

            var taskResult = next();

            output.Add($"{nameof(CreateMessageHandlerWrapper)}.{nameof(HandleAsync)}_After");

            return taskResult;
        }

        // Lowest priority in the processing pipeline, should run last.
        public sbyte Priority => Priorities.Lower;
    }
}
