using Microsoft.Extensions.DependencyInjection;
using XFrame.Common.JsonSerializer;
using XFrame.Jobs;

namespace XFrame.Aggregates.Commands
{
    [JobVersion("PublishCommand", 1)]
    public class PublishCommandJob : IJob
    {
        public PublishCommandJob(
            string data,
            string name,
            int version)
        {
            Data = data;
            Name = name;
            Version = version;
        }

        public string Data { get; }
        public string Name { get; }
        public int Version { get; }

        public Task ExecuteAsync(IServiceProvider serviceProvider, CancellationToken cancellationToken)
        {
            var commandDefinitionService = serviceProvider.GetRequiredService<ICommandDefinitionService>();
            var jsonSerializer = serviceProvider.GetRequiredService<IJsonSerializer>();
            var commandBus = serviceProvider.GetRequiredService<ICommandBus>();

            var commandDefinition = commandDefinitionService.GetDefinition(Name, Version);
            var command = (ICommand)jsonSerializer.Deserialize(Data, commandDefinition.Type);

            return command.PublishAsync(commandBus, cancellationToken);
        }

        public static PublishCommandJob Create(
            ICommand command,
            IServiceProvider serviceProvider)
        {
            var commandDefinitionService = serviceProvider.GetRequiredService<ICommandDefinitionService>();
            var jsonSerializer = serviceProvider.GetRequiredService<IJsonSerializer>();

            return Create(command, commandDefinitionService, jsonSerializer);
        }

        public static PublishCommandJob Create(
            ICommand command,
            ICommandDefinitionService commandDefinitionService,
            IJsonSerializer jsonSerializer)
        {
            var data = jsonSerializer.Serialize(command);
            var commandDefinition = commandDefinitionService.GetDefinition(command.GetType());

            return new PublishCommandJob(
                data,
                commandDefinition.Name,
                commandDefinition.Version);
        }
    }
}
