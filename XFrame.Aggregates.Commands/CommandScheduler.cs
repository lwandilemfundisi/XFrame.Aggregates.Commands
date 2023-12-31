﻿using XFrame.Common.JsonSerializer;
using XFrame.Jobs;

namespace XFrame.Aggregates.Commands
{
    public class CommandScheduler : ICommandScheduler
    {
        private readonly IJobScheduler _jobScheduler;
        private readonly ICommandDefinitionService _commandDefinitionService;
        private readonly IJsonSerializer _jsonSerializer;

        public CommandScheduler(
            IJobScheduler jobScheduler,
            ICommandDefinitionService commandDefinitionService,
            IJsonSerializer jsonSerializer)
        {
            _jobScheduler = jobScheduler;
            _commandDefinitionService = commandDefinitionService;
            _jsonSerializer = jsonSerializer;
        }

        public Task ScheduleAsync(ICommand command, DateTimeOffset runAt, CancellationToken cancellationToken)
        {
            var publishCommandJob = PublishCommandJob.Create(
                command,
                _commandDefinitionService,
                _jsonSerializer);
            return _jobScheduler.ScheduleAsync(publishCommandJob, runAt, cancellationToken);
        }

        public Task ScheduleAsync(ICommand command, TimeSpan delay, CancellationToken cancellationToken)
        {
            var publishCommandJob = PublishCommandJob.Create(
                command,
                _commandDefinitionService,
                _jsonSerializer);
            return _jobScheduler.ScheduleAsync(publishCommandJob, delay, cancellationToken);
        }
    }
}
