using XFrame.Ids;

namespace XFrame.Aggregates.Commands
{
    public interface ISerializedCommandPublisher
    {
        Task<ISourceId> PublishSerilizedCommandAsync(
            string name,
            int version,
            string json,
            CancellationToken cancellationToken);
    }
}
