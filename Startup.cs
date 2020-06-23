using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetAssignment.CustomFormater.Yaml;
using DotNetAssignment.Data;
using DotNetAssignment.Data.Repository;
using DotNetAssignment.middleware;
using DotNetAssignment.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetAssignment
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
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();

            services.TryAddScoped<IBankAccountService, BankAccountService>();
            services.TryAddScoped<IDebitCardService, DebitCardService>();
            services.TryAddScoped<BankAccountRepository>();
            services.TryAddScoped<DebitCardRepository>();

            services.AddMvc(options =>
            {
                options.InputFormatters.Insert(0, new YamlInputFormatter());
                options.OutputFormatters.Insert(0, new YamlOutputFormatter());
            })
            .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            //app.UseHeaderMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
