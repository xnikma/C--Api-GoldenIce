using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GoldenIce.Models;

namespace GoldenIce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IceCreamContext>(opt =>
                opt.UseInMemoryDatabase("IceCreams"));

            services.AddDbContext<WeatherContext>(opt =>
                opt.UseInMemoryDatabase("Weathers"));

            services.AddDbContext<IceCreamOrderContext>(opt =>
                opt.UseInMemoryDatabase("IceCreamOrders"));

            services.AddDbContext<RatingContext>(opt =>
                opt.UseInMemoryDatabase("Ratings"));

            services.AddDbContext<TableReservationContext>(opt =>
               opt.UseInMemoryDatabase("TableReservation"));

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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
