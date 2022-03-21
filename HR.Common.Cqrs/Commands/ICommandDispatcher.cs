using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Commands
{
    /// <summary>
    /// Defines the interface for a class that dispatches commands.
    /// </summary>
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand;
    }
}
