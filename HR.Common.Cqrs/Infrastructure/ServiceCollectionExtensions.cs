using HR.Common.Cqrs.Commands;
using HR.Common.Cqrs.Events;
using HR.Common.Cqrs.Queries;
using HR.Common.Utilities;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;
using System.Reflection;

namespace HR.Common.Cqrs.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the default command, query, and event dispatcher with the dependency injection framework.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="serviceLifetime">The service lifetime to register the dispatcher with.</param>
        /// <returns></returns>
        public static IServiceCollection AddDispatcher(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.Add(new ServiceDescriptor(typeof(IDispatcher), typeof(Dispatcher), serviceLifetime));
            services.Add(new ServiceDescriptor(typeof(ICommandDispatcher), provider => provider.GetService<IDispatcher>(), serviceLifetime));
            services.Add(new ServiceDescriptor(typeof(IQueryDispatcher), provider => provider.GetService<IDispatcher>(), serviceLifetime));
            services.Add(new ServiceDescriptor(typeof(IEventDispatcher), provider => provider.GetService<IDispatcher>(), serviceLifetime));
            services.Add(new ServiceDescriptor(typeof(IHandlerRegistry), typeof(HandlerRegistry), serviceLifetime));

            return services;
        }

        /// <summary>
        /// Scans the assembly for types that implement any of the handler or handler wrapper interfaces and registers them with the dependency injection framework.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly">The assembly to scan.</param>
        /// <param name="serviceLifetime">The service lifetime to register the handlers with.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static IServiceCollection AddHandlersFromAssembly(this IServiceCollection services, Assembly assembly, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            Ensure.Argument.NotNull(() => assembly);

            foreach (var openGenericInterface in new[] {
                typeof(ICommandHandler<>),
                typeof(ICommandHandlerWrapper<>),
                typeof(IQueryHandler<,>),
                typeof(IQueryHandlerWrapper<,>),
                typeof(IEventHandler<>) })
            {
                foreach (var type in assembly.ExportedTypes.Where(type => type.IsConcrete()))
                {
                    foreach (var implementedInterface in type.GetImplementedGenericInterfaces(openGenericInterface))
                    {
                        if (!type.IsGenericType)
                        {
                            services.Add(new ServiceDescriptor(implementedInterface, type, serviceLifetime));
                        }
                        else if (implementedInterface.GetGenericArguments().All(arg => arg.IsGenericParameter))
                        {
                            services.Add(new ServiceDescriptor(openGenericInterface, type, serviceLifetime));
                        }
                        else
                        {
                            throw new InvalidOperationException("Partially closed generic handlers are not supported.");
                        }
                    }
                }
            }

            return services;
        }
    }
}
