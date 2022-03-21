namespace HR.Common.Cqrs
{
    /// <summary>
    /// Intended to be implemented by command and query handler wrappers that need to have a relative ordering imposed on them by the dispatcher.
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
