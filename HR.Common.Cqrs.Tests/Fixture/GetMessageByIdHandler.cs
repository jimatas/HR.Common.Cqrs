using HR.Common.Cqrs.Queries;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class GetMessageByIdHandler : IQueryHandler<GetMessageById, Message>
    {
        private readonly IDictionary<Guid, Message> database;
        private readonly IList<string> output;

        public GetMessageByIdHandler(IDictionary<Guid, Message> database, IList<string> output = null)
        {
            this.database = database;
            this.output = output ?? new List<string>();
        }

        public Task<Message> HandleAsync(GetMessageById query, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(GetMessageByIdHandler)}.{nameof(HandleAsync)}");

            database.TryGetValue(query.Id, out Message message);
            return Task.FromResult(message);
        }
    }
}
