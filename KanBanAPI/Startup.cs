using Autofac;
using Domain.DataModels;
using KanBan.API;
using KanBanAPI.Application.Infrastructure.AutofacModules;
using KanBanAPI.Application.Infrastructure.Filters;
using KanBanAPI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MiddleMan.IntegrationEventLogEF;
using System;
using System.Reflection;

namespace KanBanAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KanBanAPI", Version = "v1" });
            });
            services.AddCustomDbContext(Configuration);
            services.AddCustomMvc();
            //services.AddMediatR(typeof(Startup).Assembly);

            //configure autofac

            //services.AddDbContext(Configuration).AddEventBus(Configuration);
            //var container = new ContainerBuilder();
            //container.Populate(services);

            //container.RegisterModule(new MediatorModule());
            //container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));
            //return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                //loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
                app.UsePathBase(pathBase);
            }

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Ordering.API V1");
                   c.OAuthClientId("orderingswaggerui");
                   c.OAuthAppName("Ordering Swagger UI");
               });

            app.UseRouting();
            //app.UseCors("CorsPolicy");
            //ConfigureAuth(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KanBanAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.WithOrigins("https://localhost:5001")
                       .AllowCredentials()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<MiddleMan.EventBus.Abstractions.IEventBus>();

            //eventBus.Subscribe<UserCheckoutAcceptedIntegrationEvent, IIntegrationEventHandler<UserCheckoutAcceptedIntegrationEvent>>();
            //eventBus.Subscribe<GracePeriodConfirmedIntegrationEvent, IIntegrationEventHandler<GracePeriodConfirmedIntegrationEvent>>();
            //eventBus.Subscribe<OrderStockConfirmedIntegrationEvent, IIntegrationEventHandler<OrderStockConfirmedIntegrationEvent>>();
            //eventBus.Subscribe<OrderStockRejectedIntegrationEvent, IIntegrationEventHandler<OrderStockRejectedIntegrationEvent>>();
            //eventBus.Subscribe<OrderPaymentFailedIntegrationEvent, IIntegrationEventHandler<OrderPaymentFailedIntegrationEvent>>();
            //eventBus.Subscribe<OrderPaymentSucceededIntegrationEvent, IIntegrationEventHandler<OrderPaymentSucceededIntegrationEvent>>();
        }

        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));
        }
    }

    internal static class CustomExtensionsMethods
    {
        //public static IServiceCollection AddApplicationInsights(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddApplicationInsightsTelemetry(configuration);
        //    services.AddApplicationInsightsKubernetesEnricher();

        //    return services;
        //}
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KanbanContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            },
                       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                   );

            services.AddDbContext<IntegrationEventLogContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"],
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
            });

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
                // Added for functional tests
                .AddApplicationPart(typeof(CardListController).Assembly)
                .AddApplicationPart(typeof(TaskCardController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            //
            services.AddMvc().AddNewtonsoftJson();

            return services;
        }

        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.Configure<KanbanSettings>(configuration);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Please refer to the errors property for additional details."
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });

            return services;
        }
    }
}