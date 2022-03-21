using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Commands
{
    /// <summary>
    /// Defines the interface for a set of classes that wrap a command handler in order to create a processing pipeline.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface ICommandHandlerWrapper<in TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, HandlerDelegate next, CancellationToken cancellationToken);
    }
}
