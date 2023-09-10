using XFrame.Aggregates.ExecutionResults;
using XFrame.Ids;
using XFrame.VersionTypes;

namespace XFrame.Aggregates.Commands
{
    public interface ICommand : IVersionedType
    {
        Task<IExecutionResult> PublishAsync(
            ICommandBus commandBus, 
            CancellationToken cancellationToken);
        ISourceId GetSourceId();
    }

    public interface ICommand<in TAggregate, out TIdentity, TResult> : ICommand
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity
        where TResult : IExecutionResult
    {
        TIdentity AggregateId { get; }
        ISourceId SourceId { get; }
    }
}
