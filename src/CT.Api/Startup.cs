using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CT.Common;
using CT.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CT.Api
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
            //config 
            var config = new AppConfig();
            Configuration.GetSection(nameof(AppConfig)).Bind(config);
            services.AddSingleton(config);

            //services
            services.AddHttpClient<RestService>(a=>
            {
                a.BaseAddress = new Uri(config.SourceUrl);
            });

            services.AddCors(a => a.AddPolicy("All", b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials()));
            services.AddMvc();

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CT API",
                    Version = "v1"
                });
            });
         
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("All");

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CT API V1");
                c.RoutePrefix = "";
            });

            app.UseMvc();

        }
    }
}
