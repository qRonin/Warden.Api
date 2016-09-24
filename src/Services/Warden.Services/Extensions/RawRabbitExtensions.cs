﻿using RawRabbit;
using RawRabbit.Common;
using Warden.Services.Commands;
using Warden.Services.Events;

namespace Warden.Services.Extensions
{
    public static class RawRabbitExtensions
    {
        public static ISubscription WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(async (msg, context) => await handler.HandleAsync(msg));

        public static ISubscription WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(async (msg, context) => await handler.HandleAsync(msg));
    }
}