using Microsoft.Extensions.Logging;
using System.Reflection;
using XFrame.Ioc.Configuration;
using XFrame.VersionTypes;

namespace XFrame.Aggregates.Commands
{
    public class CommandDefinitionService 
        : VersionedTypeDefinitionService<ICommand, CommandVersionAttribute, CommandDefinition>, ICommandDefinitionService
    {
        public CommandDefinitionService(
            ILogger<CommandDefinitionService> logger,
            ILoadedTypes loadedTypes)
            : base(logger)
        {
            var commandTypes = loadedTypes
                .TypesLoaded
                .Where(t => typeof(ICommand).GetTypeInfo().IsAssignableFrom(t));
            Load(commandTypes.ToArray());
        }

        protected override CommandDefinition CreateDefinition(int version, Type type, string name)
        {
            return new CommandDefinition(version, type, name);
        }
    }
}
