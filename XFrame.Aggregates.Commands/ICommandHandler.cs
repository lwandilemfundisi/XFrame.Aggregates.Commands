using XFrame.Aggregates.ExecutionResults;
using XFrame.Ids;

namespace XFrame.Aggregates.Commands
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<in TAggregate, TIdentity, TResult, in TCommand> : ICommandHandler
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
        where TResult : IExecutionResult
        where TCommand : ICommand<TAggregate, TIdentity, TResult>
    {
        Task<TResult> ExecuteCommandAsync(
            TAggregate aggregate, 
            TCommand command, 
            CancellationToken cancellationToken);
    }
}
