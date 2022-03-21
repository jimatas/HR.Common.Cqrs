using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Events
{
    /// <summary>
    /// Defines the interface for a class that dispatches events.
    /// </summary>
    public interface IEventDispatcher
    {
        Task DispatchAsync<TEvent>(TEvent e, CancellationToken cancellationToken = default)
            where TEvent : IEvent;
    }
}
