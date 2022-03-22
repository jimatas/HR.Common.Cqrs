using HR.Common.Cqrs.Commands;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class CreateMessageHandler : ICommandHandler<CreateMessage>
    {
        private readonly IDictionary<Guid, Message> database;
        private readonly IList<string> output;

        public CreateMessageHandler(IDictionary<Guid, Message> database, IList<string> output = null)
        {
            this.database = database;
            this.output = output ?? new List<string>();
        }

        public Task HandleAsync(CreateMessage command, CancellationToken cancellationToken)
        {
            var newMessage = new Message(command.Id) { Text = command.Text };
            database.Add(newMessage.Id, newMessage);

            output.Add($"{nameof(CreateMessageHandler)}.{nameof(HandleAsync)}");

            return Task.CompletedTask;
        }
    }
}
