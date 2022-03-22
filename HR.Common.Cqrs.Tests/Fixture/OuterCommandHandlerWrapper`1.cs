﻿using HR.Common.Cqrs.Commands;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class OuterCommandHandlerWrapper<TCommand> : ICommandHandlerWrapper<TCommand>, IPrioritizable
        where TCommand : ICommand
    {
        private readonly IList<string> output;

        public OuterCommandHandlerWrapper(IList<string> output)
        {
            this.output = output;
        }

        public Task HandleAsync(TCommand command, HandlerDelegate next, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(OuterCommandHandlerWrapper<TCommand>)}.{nameof(HandleAsync)}_Before");

            var taskResult = next();

            output.Add($"{nameof(OuterCommandHandlerWrapper<TCommand>)}.{nameof(HandleAsync)}_After");

            return taskResult;
        }

        // Highest explicitly set priority in the pipeline, should be first to run.
        public sbyte Priority => Priorities.High;
    }
}
