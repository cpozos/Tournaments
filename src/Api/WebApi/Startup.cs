using MediatR;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using AppLayer = Application.NetStandard;
using InfLayer = Infraestructure.NetStandard;

namespace WebApi
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
         // Users
         services.AddScoped<AppLayer.Repositories.IPersonRepository, InfLayer.PersonRepository>();
         services.AddScoped<AppLayer.Repositories.IOrganizersRepository, InfLayer.OrganizerRepository>();

         // Players
         services.AddScoped<AppLayer.Repositories.IPlayerRepository, InfLayer.PlayerRepository>();

         // Tournament
         services.AddScoped<AppLayer.Repositories.ITournamentRepository, InfLayer.FIFA.TournamentRepository>();

         // FIFA
         services.AddScoped<AppLayer.Repositories.ITeamRepository, InfLayer.FIFA.FIFATeamRepository>();

         services.AddMediatR(typeof(AppLayer.Person.Queries.GetPersonQueryHandler));

         services.AddSwaggerGen(doc =>
         {
            doc.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
               Title = "Tournaments API",
               Version = "v1.0.0"
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            doc.IncludeXmlComments(xmlPath, true);
         });

         services.AddControllers();
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
         app.UseSwaggerUI(options =>
         {
            options.SwaggerEndpoint("/swagger/v1/swagger.json","Tournaments API");
            options.RoutePrefix = string.Empty; // Root of the API
         });

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
