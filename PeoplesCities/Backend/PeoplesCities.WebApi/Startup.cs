﻿using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PeoplesCities.Application;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Application.Sevices;
using PeoplesCities.Persistence;
using PeoplesCities.WebApi.Middleware;
using PeoplesCities.WebApi.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PeoplesCities.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IPeoplesCitiesDbContext).Assembly));
            });

            services.AddDbContext<PeoplesCitiesDbContext>(options =>
            {
                options.UseSnakeCaseNamingConvention();

                var provider = Configuration.GetValue("provider", Provider.Sqlite.Name);
                if (provider == Provider.Sqlite.Name)
                {
                    options.UseSqlite(
                        Configuration.GetConnectionString(Provider.Sqlite.Name)!,
                        x => x.MigrationsAssembly(Provider.Sqlite.Assembly)
                    );
                }
                if (provider == Provider.PostgreSql.Name)
                {
                    options.UseNpgsql(
                        Configuration.GetConnectionString(Provider.PostgreSql.Name)!,
                        x => x.MigrationsAssembly(Provider.PostgreSql.Assembly)
                    );
                }
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            // Для теста предоставим доступ для всех
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("Bearer", options =>
               {
                   // При обычном запуске приложения:
                   options.Authority = "https://localhost:7088/";
                   // При исользовании контейнеров Docker:
                   options.Authority = "http://localhost:7088/";
                   options.Audience = "PeoplesCitiesWebAPI";
                   options.RequireHttpsMetadata = false;
               });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(config =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
            services.AddApiVersioning();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<IWireMockService>(provider => new WireMockService(Configuration.GetSection("WireMockSettings")["WireMockUrl"]));
            services.AddHttpContextAccessor();
        }   

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            // Задаем интерфейс сваггера по умолчанию.
            app.UseSwaggerUI(config =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
                    config.RoutePrefix = string.Empty;
                }
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioning();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}