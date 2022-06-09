using HR.Common.Cqrs.Events;

using System;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class MessageCreated : IEvent
    {
        public Guid Id { get; set; }
    }
}
