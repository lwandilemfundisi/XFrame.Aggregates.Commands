using XFrame.VersionTypes;

namespace XFrame.Aggregates.Commands
{
    public interface ICommandDefinitionService 
        : IVersionedTypeDefinitionService<CommandVersionAttribute, CommandDefinition>
    {
    }
}
