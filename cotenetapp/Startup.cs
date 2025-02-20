﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cotenetapp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using cotenetapp.Models;
using cotenetapp.Services;
using cotenetapp.CustomFilters;
using Newtonsoft.Json.Serialization;
using cotenetapp.CustomMiddlewares;

namespace cotenetapp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //initialize DB Connection
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            // register the VaneeraAppDb Database Connection
            // using DI
            services.AddDbContext<MyAppDbContext>(options => 
            {
                options.UseSqlServer
               (Configuration.GetConnectionString("MyAppDbConnection"));
            });
            // ends here

            // register all Business Repositories aka services
            services.AddTransient<IServiceRepository<Category, int>, CategoryServiceRepository>();
            services.AddTransient<IServiceRepository<Product, int>, ProductServiceRepository>();

            // ends here

            // initialize default  security
            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddDefaultUI(UIFramework.Bootstrap4)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            // initialize the application Identity for Users and Roles
            // provides an Ijections for UserManager and RoleManager 
            // and SignInManager
            services.AddIdentity<IdentityUser,IdentityRole>()
               .AddDefaultUI(UIFramework.Bootstrap4)
               .AddEntityFrameworkStores<ApplicationDbContext>();
            // ends Here

            // add authorization for Policies
            services.AddAuthorization(options => 
            {
                options.AddPolicy("readpolicy", builder =>
                 {
                     builder.RequireRole("Manager", "Clerk", "Admin");
                 });

                options.AddPolicy("writepolicy", builder =>
                {
                    builder.RequireRole("Manager", "Admin");
                });
            });
            // ends here

            // define CORS Policies for REST API
            services.AddCors(options => 
            {
                options.AddPolicy("corspolicy", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            // Ends here


            // configure MVC
            services.AddMvc(options => 
            {
                // registering Action Filter in GLobal Scope
                options.Filters.Add(typeof(LogActionFilterAttribute));
               // options.Filters.Add(typeof(CustomException));
            }).AddJsonOptions(options =>
                    options.SerializerSettings.ContractResolver
             = new DefaultContractResolver()
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            // configure the CORS Policy Middleware

            app.UseCors("corspolicy");
            app.UseExceptionHandlerMiddleware();
            // security middleware
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
