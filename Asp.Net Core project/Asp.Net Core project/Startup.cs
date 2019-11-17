using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection; 

namespace Asp.Net_Core_project
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            { 
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase());
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
             
            services.AddScoped<Repository>();
            services.Configure<RepositoryOptions>(Configuration);

            services.AddDbContext<UniversityContext> (x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.ConfigureApplicationCookie(p =>
            {
                p.LoginPath = "/Home/Login";
                p.Cookie.Name = "ASP.NET.Demo.App";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            this.CreateAdminUser(userManager, roleManager, context);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private void CreateAdminUser(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                IdentityUser AdminDefault = new IdentityUser("Admin@test.com") { Email = "Admin@test.com" };
                var AdminPassword = userManager.CreateAsync(AdminDefault, "SuperAdmin#1234").Result;
                var AdminRole = roleManager.CreateAsync(new IdentityRole("Admin")).Result;
                var CreateAdmin = userManager.AddToRoleAsync(AdminDefault, "Admin").Result;

                IdentityUser UserDefault = new IdentityUser("User@test.com") { Email = "User@test.com" };
                var UserPassword = userManager.CreateAsync(UserDefault, "SuperUser#1234").Result;
                var UserRole = roleManager.CreateAsync(new IdentityRole("Student")).Result;
                var CreateUser = userManager.AddToRoleAsync(UserDefault, "Student").Result;
            }
        }
    }
}


/*
 * Admin@test.com
 * SuperAdmin#1234
 * User@test.com
 *SuperUser#1234
*/
