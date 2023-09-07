﻿using EventBus.Abstractions;

namespace Account.API.Infrastructure.Services
{
    public class KafkaConsumerService : IHostedService, IDisposable
    {
        private readonly ISubscribeEvent _subscribeEvent;
        public KafkaConsumerService(ISubscribeEvent subscribeEvent)
        {
            _subscribeEvent = subscribeEvent;
        }

        public void Dispose()
        {
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => _subscribeEvent.StartBasicConsume());
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
