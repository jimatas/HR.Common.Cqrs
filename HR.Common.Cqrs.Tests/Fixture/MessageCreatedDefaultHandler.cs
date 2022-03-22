using HR.Common.Cqrs.Events;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class MessageCreatedDefaultHandler : IEventHandler<MessageCreated>
    {
        private readonly IList<string> output;

        public MessageCreatedDefaultHandler(IList<string> output = null)
        {
            this.output = output ?? new List<string>();
        }

        public Task HandleAsync(MessageCreated e, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(MessageCreatedDefaultHandler)}.{nameof(HandleAsync)}");

            return Task.CompletedTask;
        }
    }
}
