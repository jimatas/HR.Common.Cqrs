using System;
using System.Collections.Generic;

namespace HR.Common.Cqrs.Infrastructure
{
    public interface IHandlerRegistry
    {
        object GetCommandHandler(Type commandType);
        IEnumerable<object> GetCommandHandlerWrappers(Type commandType);
        object GetQueryHandler(Type queryType, Type resultType);
        IEnumerable<object> GetQueryHandlerWrappers(Type queryType, Type resultType);
        IEnumerable<object> GetEventHandlers(Type eventType);
    }
}
