using XFrame.Aggregates.ExecutionResults;
using XFrame.Ids;

namespace XFrame.Aggregates.Commands
{
    public abstract class CommandHandler<TAggregate, TIdentity, TResult, TCommand> :
        ICommandHandler<TAggregate, TIdentity, TResult, TCommand>
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
        where TResult : IExecutionResult
        where TCommand : ICommand<TAggregate, TIdentity, TResult>
    {
        public abstract Task<TResult> ExecuteCommandAsync(
            TAggregate aggregate,
            TCommand command,
            CancellationToken cancellationToken);
    }

    public abstract class CommandHandler<TAggregate, TIdentity, TCommand> :
        CommandHandler<TAggregate, TIdentity, IExecutionResult, TCommand>
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
        where TCommand : ICommand<TAggregate, TIdentity, IExecutionResult>
    {
        public override async Task<IExecutionResult> ExecuteCommandAsync(
            TAggregate aggregate,
            TCommand command,
            CancellationToken cancellationToken)
        {
            return await ExecuteAsync(aggregate, command, cancellationToken).ConfigureAwait(false);
        }

        public abstract Task<IExecutionResult> ExecuteAsync(
            TAggregate aggregate,
            TCommand command,
            CancellationToken cancellationToken);
    }
}
