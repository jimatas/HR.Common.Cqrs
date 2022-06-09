using System;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class Message
    {
        public Message() { }
        public Message(Guid id) => Id = id;

        public Guid Id { get; }
        public string Text { get; set; }

        public override string ToString() => Text;
    }
}
