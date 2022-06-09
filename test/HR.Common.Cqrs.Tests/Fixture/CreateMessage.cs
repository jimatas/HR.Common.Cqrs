using HR.Common.Cqrs.Commands;

using System;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class CreateMessage : ICommand
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
