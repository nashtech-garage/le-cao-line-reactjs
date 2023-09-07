using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventBus.InMemoryEventBusSubscriptionsManager;

namespace EventBus.Abstractions
{
    public interface IEventBusSubscriptionsManager
    {
        void AddSubscription<T, TH>()where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
        string GetEventKey<T>();
        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;
        bool HasSubscriptionsForEvent(string eventName);

        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
    }
}
