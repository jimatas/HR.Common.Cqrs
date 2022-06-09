using HR.Common.Cqrs.Events;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class MessageCreatedSecondaryHandler : IEventHandler<MessageCreated>
    {
        private readonly IList<string> output;

        public MessageCreatedSecondaryHandler(IList<string> output = null)
        {
            this.output = output ?? new List<string>();
        }

        public Task HandleAsync(MessageCreated e, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(MessageCreatedSecondaryHandler)}.{nameof(HandleAsync)}");

            return Task.CompletedTask;
        }
    }
}
