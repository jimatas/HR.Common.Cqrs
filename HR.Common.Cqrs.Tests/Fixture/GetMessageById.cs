using HR.Common.Cqrs.Queries;

using System;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class GetMessageById : IQuery<Message>
    {
        public Guid Id { get; set; }
    }
}
