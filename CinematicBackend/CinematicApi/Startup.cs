using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinematic.Business.Managers;
using Cinematic.Business.Mapping;
using Cinematic.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CinematicBackend
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
            services.Configure<MongoDbSettings.MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<MongoDbSettings.MongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings.MongoDbSettings>>().Value);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CinematicApi", Version = "v1"});
            });
            services.AddAutoMapper(c => c.AddProfile<MappingProfile>(),typeof(Startup));
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<ITheaterManager, TheaterManager>();
            services.AddTransient<IPlayManager, PlayManager>();
            services.AddTransient<ISeatManager, SeatManager>();
            
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            services.AddTransient<IPlayRepository, PlayRepository>();
            services.AddTransient<ISeatRepository, SeatRepository>();

        }

        // Install MongoDB driver as NuGetPackage => in this package there is Client use this client as instance =>getDatabase=>getCollection
        // how to use mongodb driver in .net core
        //research mongodb and the repository pattern 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CinematicApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}