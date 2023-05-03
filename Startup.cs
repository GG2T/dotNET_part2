using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _335ass2.Data;
using Microsoft.EntityFrameworkCore;
using _335ass2.Handler;
using Microsoft.AspNetCore.Authentication;


namespace _335ass2
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
            services.AddAuthentication().
            AddScheme<AuthenticationSchemeOptions, MyAuthHandler>
            ("MyAuthentication", null);
            services.AddScoped<IWebAPIRepo, DBWebAPIRepo>();
            services.AddControllers();
            services.AddDbContext<WebAPIDBContext>(options => options.UseSqlite(Configuration.GetConnectionString("APIConnection")));
            services.AddAuthorization(options =>
            {
                
                options.AddPolicy("UserOnly", policy => policy.RequireClaim("userName"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();


            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
