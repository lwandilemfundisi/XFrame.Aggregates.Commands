using XFrame.Ids;

namespace XFrame.Aggregates.Commands
{
    public class CommandId : Identity<CommandId>, ICommandId
    {
        public CommandId(string value) : base(value)
        {
        }
    }
}
