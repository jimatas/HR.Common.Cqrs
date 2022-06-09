using HR.Common.Cqrs.Commands;
using HR.Common.Cqrs.Events;
using HR.Common.Cqrs.Queries;

namespace HR.Common.Cqrs
{
    /// <summary>
    /// Base interface for a class that dispatches all three of the message types: commands, queries, and events.
    /// </summary>
    public interface IDispatcher : ICommandDispatcher, IQueryDispatcher, IEventDispatcher
    {
    }
}
