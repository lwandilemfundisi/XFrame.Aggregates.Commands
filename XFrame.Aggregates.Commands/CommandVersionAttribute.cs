using XFrame.VersionTypes;

namespace XFrame.Aggregates.Commands
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandVersionAttribute : VersionedTypeAttribute
    {
        public CommandVersionAttribute(
            string name,
            int version)
            : base(name, version)
        {
        }
    }
}
