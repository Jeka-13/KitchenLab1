﻿using System;
using Kitchen.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<KitchenServer, KitchenServer>();
                    services.AddHostedService<Kitchen>();
                }).Build().Run();
        }
    }
}