using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Commands
{
    /// <summary>
    /// Defines the interface for a command handler.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
