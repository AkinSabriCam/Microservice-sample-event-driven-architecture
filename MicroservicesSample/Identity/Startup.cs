using System.Reflection;
using Common.Event;
using Identity.Application.Commands;
using Identity.Domain;
using Identity.Domain.EventListeners;
using Identity.EntityFramework;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(Configuration.GetConnectionString("Default")));
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IApplicationDbInitalizer, ApplicationDbInitalizer>();
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IEventHandler<UserUpdatedEvent>, UserUpdatedEventListener>();
            services.AddScoped<IMassTransitEventProducer, MassTransitEventProducer>();
            
            services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);
            services.AddCustomMassTransit(Configuration);
            services.AddSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API V1"); });
            
            //migrated all migrations 
            app.ApplicationServices.MigrateAll().Wait();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}