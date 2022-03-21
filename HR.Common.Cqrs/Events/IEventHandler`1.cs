using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Events
{
    /// <summary>
    /// Defines the interface for an event handler.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event.</typeparam>
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        Task HandleAsync(TEvent e, CancellationToken cancellationToken);
    }
}
