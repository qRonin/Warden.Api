﻿using System;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Logging;
using Rebus.Routing.TypeBased;
using Rebus.Transport.Msmq;
using Warden.Common.Commands;
using Warden.Services.Spawn.Handlers.Commands;

namespace Warden.Services.Spawn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var activator = new BuiltinHandlerActivator())
            {
                Console.Title = "Warden.Services.Spawn";
                activator.Register((bus, message) => new SpawnWardenHandler(bus));
                Configure.With(activator)
                    .Logging(l => l.ColoredConsole(minLevel: LogLevel.Debug))
                    .Transport(t => t.UseMsmq("Warden.Services.Spawn"))
                    .Routing(r => r.TypeBased().Map<SpawnWarden>("Warden.Api"))
                    .Start();

                activator.Bus.Subscribe<SpawnWarden>().Wait();
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
