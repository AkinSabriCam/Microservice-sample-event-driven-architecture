using System.Reflection;
using Common.Event;
using Customer.Application.Commands;
using Customer.Domain;
using Customer.Domain.EventListeners;
using Customer.EntityFramework;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customer
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
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Default")));
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
            services.AddScoped<IMassTransitEventProducer, MassTransitEventProducer>();
            services.AddScoped<IEventHandler<UserCreatedEvent>, UserCreatedEventListener>();
            
            services.AddMediatR(typeof(UpdateCustomerCommand).GetTypeInfo().Assembly);
            services.AddCustomMassTransit(Configuration);
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
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer API V1"); });
            
            app.UseRouting();
            app.ApplicationServices.MigrateAll().Wait();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}