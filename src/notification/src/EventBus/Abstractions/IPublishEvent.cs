using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Abstractions
{
    public interface IPublishEvent
    {
        Task Publish(IntegrationEvent @event);
    }

}
