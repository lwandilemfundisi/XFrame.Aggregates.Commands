using XFrame.VersionTypes;

namespace XFrame.Aggregates.Commands
{
    public class CommandDefinition : VersionedTypeDefinition
    {
        public CommandDefinition(
            int version,
            Type type,
            string name)
            : base(version, type, name)
        {
        }
    }
}
