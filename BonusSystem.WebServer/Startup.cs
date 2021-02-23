using BonusSystem.WebServer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BonusSystem.WebServer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            string con = "Server=.;Database=BonusSystemDB;Trusted_Connection=True;ApplicationIntent=ReadWrite;MultipleActiveResultSets=true";
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(con));

            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.IgnoreNullValues = true;
                        options.JsonSerializerOptions.WriteIndented = true;
                    });
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();
            // Redirect all calls from HTTP to HTTPS
            app.UseHttpsRedirection();
            // Serve static files
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
          //  TestingData.Initialize(app);
        }
    }
}
