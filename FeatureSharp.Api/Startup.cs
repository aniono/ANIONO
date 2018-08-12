using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FeatureSharp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using FeatureSharp.Services;

namespace FeatureSharp.Api
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
            string connectionString = @"Server=(localdb)\mssqllocaldb;Database=FeatureSharpDb;Trusted_Connection=True;";
            services.AddDbContext<FeatureSharpDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddTransient<FeatureDataService>();
            services.AddTransient<FeaturePersistence>();
            services.AddTransient<FeatureRepository>();
            services.AddTransient<IFeatureService, FeatureService>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseMvc();
        }
    }
}
