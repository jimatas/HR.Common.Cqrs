using HR.Common.Cqrs.Commands;
using HR.Common.Cqrs.Events;
using HR.Common.Cqrs.Queries;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HR.Common.Cqrs.Infrastructure
{
    /// <summary>
    /// Default implementation of the <see cref="IHandlerRegistry"/> interface that uses dependency injection to resolve the handlers.
    /// </summary>
    public class HandlerRegistry : IHandlerRegistry
    {
        private readonly IServiceProvider serviceProvider;

        public HandlerRegistry(IServiceProvider serviceProvider)
            => this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        public object GetCommandHandler(Type commandType)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            var handlers = serviceProvider.GetServices(handlerType);
            if (handlers.Count() == 1)
            {
                return handlers.Single();
            }
            throw new InvalidOperationException($"{(handlers.Any() ? "More than one" : "No")} handler found for command with type {commandType}.");
        }

        public IEnumerable<object> GetCommandHandlerWrappers(Type commandType)
        {
            var wrapperType = typeof(ICommandHandlerWrapper<>).MakeGenericType(commandType);
            return serviceProvider.GetServices(wrapperType);
        }

        public object GetQueryHandler(Type queryType, Type resultType)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, resultType);
            var handlers = serviceProvider.GetServices(handlerType);
            if (handlers.Count() == 1)
            {
                return handlers.Single();
            }
            throw new InvalidOperationException($"{(handlers.Any() ? "More than one" : "No")} handler found for query with type {queryType}.");
        }

        public IEnumerable<object> GetQueryHandlerWrappers(Type queryType, Type resultType)
        {
            var wrapperType = typeof(IQueryHandlerWrapper<,>).MakeGenericType(queryType, resultType);
            return serviceProvider.GetServices(wrapperType);
        }

        public IEnumerable<object> GetEventHandlers(Type eventType)
        {
            var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
            return serviceProvider.GetServices(handlerType);
        }
    }
}
