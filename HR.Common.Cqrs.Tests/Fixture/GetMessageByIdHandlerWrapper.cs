using HR.Common.Cqrs.Queries;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Common.Cqrs.Tests.Fixture
{
    public class GetMessageByIdHandlerWrapper : IQueryHandlerWrapper<GetMessageById, Message>
    {
        private readonly IList<string> output;

        public GetMessageByIdHandlerWrapper(IList<string> output = null)
        {
            this.output = output ?? new List<string>();
        }

        public Task<Message> HandleAsync(GetMessageById query, HandlerDelegate<Message> next, CancellationToken cancellationToken)
        {
            output.Add($"{nameof(GetMessageByIdHandlerWrapper)}.{nameof(HandleAsync)}_Before");

            var taskResult = next();

            output.Add($"{nameof(GetMessageByIdHandlerWrapper)}.{nameof(HandleAsync)}_After");

            return taskResult;
        }
    }
}
