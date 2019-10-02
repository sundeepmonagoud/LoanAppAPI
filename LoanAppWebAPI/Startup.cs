using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElmahCore;
using ElmahCore.Mvc;
using LoanApp.BAL;
using LoanApp.DAL;
using LoanApp.DAL.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace LoanAppWebAPI
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
           
            string dbConnString = Configuration.GetConnectionString("LoanDBConn");

            services.AddDbContext<LoanDbContext>(options =>
                     options.UseSqlServer(dbConnString, builder => builder.MigrationsAssembly(typeof(Startup).Assembly.FullName)
                         ));
            services.AddScoped<ICustomerLoanServiceDAL, CustomerLoanServiceDAL>();
            services.AddScoped<ILoanServiceDAL, LoanServiceDAL>();
            services.AddScoped<ICustomerLoanServiceBAL, CustomerLoanServiceBAL>();

            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.LogPath = "~/log"; // OR options.LogPath = "с:\errors";
            });

            services.AddAutoMapper(typeof(Startup));
            // Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

          
            services.AddMvc().AddJsonOptions(options =>
            {
                if (options.SerializerSettings.ContractResolver != null)
                {
                    var resolver = options.SerializerSettings.ContractResolver as DefaultContractResolver;
                    resolver.NamingStrategy = null;
                }
            });


            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAnyOrigin"));
            });

            services.AddMvc().AddControllersAsServices();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("AllowAnyOrigin");
            app.UseElmah();
        }
    }
}
