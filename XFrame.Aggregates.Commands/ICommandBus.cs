using XFrame.Aggregates.ExecutionResults;
using XFrame.Ids;

namespace XFrame.Aggregates.Commands
{
    public interface ICommandBus
    {
        Task<TExecutionResult> PublishAsync<TAggregate, TIdentity, TExecutionResult>(
            ICommand<TAggregate, TIdentity, TExecutionResult> command,
            CancellationToken cancellationToken)
            where TAggregate : class, IAggregateRoot<TIdentity>
            where TIdentity : IIdentity
            where TExecutionResult : IExecutionResult;
    }
}
