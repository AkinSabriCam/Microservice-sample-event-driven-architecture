﻿using System;
using System.Threading.Tasks;
using Common.Event;
using Customer.MassTransit;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Customer
{
    public static class ServiceExtension
    {
        public static void AddCustomMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            var options = new MassTransitOptions();
            configuration.GetSection("RabbitMq").Bind(options);

            services.AddMassTransit(appProvider =>
            {
                return Bus.Factory.CreateUsingRabbitMq(
                    configurator =>
                    {
                        var host = configurator.Host(new Uri($"{options.Host}:{options.Port}"), h =>
                        {
                            h.Username(options.Username);
                            h.Password(options.Password);
                        });
                
                        configurator.ReceiveEndpoint(host, "user_created_events", ep =>
                        {
                            ep.Handler<UserCreatedEvent>(async context =>
                            {  
                                await services.BuildServiceProvider()
                                    .GetRequiredService<IEventHandler<UserCreatedEvent>>().Handle(context.Message);
                            });
                        });
                    });
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Customer API",
                    Description = "A simple example ASP.NET Core Web API",
                });
            });
        }
    }
}