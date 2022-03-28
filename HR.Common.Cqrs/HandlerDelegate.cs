using System.Threading.Tasks;

namespace HR.Common.Cqrs
{
    /// <summary>
    /// A function delegate that represents the call to the next command handler wrapper in a processing pipeline, or eventually the command handler itself.
    /// </summary>
    /// <returns>An awaitable task.</returns>
    public delegate Task HandlerDelegate();
}
