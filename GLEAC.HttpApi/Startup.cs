using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using GLEAC.Application;
using GLEAC.Common.Configuration;
using GLEAC.HttpApi.MediatRBehaviors;
using GLEAC.HttpApi.Middleware;
using GLEAC.HttpApi.Swagger;
using GLEAC.Services.Authentication;
using GLEAC.Services.Contracts.Authentication;
using GLEAC.Services.Contracts.LevenshteinDistance;
using GLEAC.Services.LevenshteinDistance;
using MediatR;
using Microsoft.OpenApi.Models;

namespace GLEAC.HttpApi
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

            services.Configure<ApplicationConfiguration>(Configuration.GetSection("ApplicationConfiguration"));

            var applicationAssembly = Assembly.GetAssembly(typeof(ApplicationAssembly));

            services.AddValidatorsFromAssembly(applicationAssembly);

            services.AddMediatR(applicationAssembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorPipelineBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggerPipelineBehavior<,>));

            services.AddMemoryCache();

            services.AddSingleton<ILevenshteinDistanceService, LevenshteinDistanceService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<ITokenService, TokenService>();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Levenshtein Distance API V1",
                    Description = "Levenshtein Distance Calculator",
                });

                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                s.OperationFilter<AuthOperationsFilter>();
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // global cors policy
            app.UseCors(x => x
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Levenshtein Distance API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
