namespace HR.Common.Cqrs
{
    /// <summary>
    /// Intended to be implemented by command and query handler wrappers that need to be executed in a predetermined relative order.
    /// </summary>
    public interface IPrioritizable
    {
        /// <summary>
        /// Higher priority means earlier execution.
        /// Default priority is zero.
        /// </summary>
        sbyte Priority { get; }
    }
}
