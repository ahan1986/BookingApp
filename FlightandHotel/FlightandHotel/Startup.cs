using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using FlightandHotel.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.IO;

namespace FlightandHotel
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddCors();
            services.AddMvc();
            // add dbcontext service first. We will call out dbcontext 'fightandhotel' and pass in options we want with this. Add our data source and we will call out db flighthotel. We have to use EF to fix the errors.  There was an error under UseSqlite, seems like the problem was fixed when we changed the FlightAndHotel and added Context and already had that file made with DbSet and everything.
            services.AddDbContext<FlightAndHotelContext>((options) =>
                    options.UseSqlite("Data Source=FlightHotel.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            app.Use(async ( context, next ) =>
            {
                await next();
                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }

            });

            app.UseMvcWithDefaultRoute();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                 builder.WithOrigins("http://localhost:3000/"));

            app.UseMvc();
        }
    }
}
// we are going to scaffold. go into the folder in terminal and run 'dotnet restore'