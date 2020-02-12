﻿using LarsWM.Domain.Common.Models;
using LarsWM.Domain.Common.Services;
using LarsWM.Domain.Monitors.Commands;
using LarsWM.Domain.Monitors.Events;

namespace LarsWM.Domain.Monitors.CommandHandlers
{
    class AddMonitorHandler : ICommandHandler<AddMonitorCommand>
    {
        private IBus _bus;
        private MonitorService _monitorService;

        public AddMonitorHandler(IBus bus, MonitorService monitorService)
        {
            _bus = bus;
            _monitorService = monitorService;
        }

        public void Handle(AddMonitorCommand command)
        {
            _monitorService.Monitors.Add(new Monitor(command.Screen));

            _bus.RaiseEvent(new MonitorAddedEvent());
        }
    }
}
