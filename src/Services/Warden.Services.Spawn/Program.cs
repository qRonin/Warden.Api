﻿using Warden.Common.Commands;
using Warden.Services.Host;
using Warden.Services.Spawn.Framework;

namespace Warden.Services.Spawn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebServiceHost
                .Create<Startup>(port: 10006)
                .UseAutofac(Bootstrapper.LifetimeScope)
                .UseRabbitMq()
                .SubscribeToCommand<SpawnWarden>()
                .Build()
                .Run();
        }
    }
}
