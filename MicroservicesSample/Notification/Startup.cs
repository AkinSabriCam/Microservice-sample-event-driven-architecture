using System;
using System.Reflection;
using Common.Event;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Notification.Application.Customer;
using Notification.Domain;
using Notification.Domain.EventListeners;
using Notification.EntityFramework;
using Notification.Mapping;
using Notification.MassTransit;

namespace Notification
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<NotificationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Default")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
            services.AddScoped<IEventHandler<UserCreatedEvent>, UserCreatedEventListener>();
            services.AddScoped<IEventHandler<UserUpdatedEvent>, UserUpdatedEventListener>();
            services.AddScoped<IMapper, Mapping.MapsterMapper>();

            services.AddMediatR(typeof(GetAllCustomersQuery).GetTypeInfo().Assembly);
            services.AddCustomMassTransit(Configuration);
            services.AddRedisCache(Configuration);
            services.AddSwagger();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification API V1"); });

            app.ApplicationServices.MigrateAll().Wait();
            app.UseRouting();
            new MapsterProfile().Configure();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}