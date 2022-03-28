using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Commands
{
    /// <summary>
    /// Allows an implementor to wrap a command handler to dynamically add behavior. 
    /// The call to the command handler, or a successive wrapper, is abstracted into a function delegate, which is passed in to the <see cref="HandleAsync"/> method. 
    /// The back-to-back chaining of multiple wrappers effectively creates a processing pipeline.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public interface ICommandHandlerWrapper<in TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, HandlerDelegate next, CancellationToken cancellationToken);
    }
}
