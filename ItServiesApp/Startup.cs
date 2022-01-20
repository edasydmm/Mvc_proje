using ItServiceApp.Services;
using ItServiesApp.Data;
using ItServiesApp.MapperProfiles;
using ItServiesApp.Models.Identity;
using ItServiesApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
            });

            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {


                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 5;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                  "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;


            }).AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();




            services.ConfigureApplicationCookie(options =>
            {

                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;



            });

            services.AddTransient<IEmailSender, EmailSender>(); //louse coupling
            services.AddScoped<IPaymentService, IyzicoPaymentService>(); //louse coupling
            services.AddAutoMapper(options =>
            {
                //options.AddProfile<PaymentProfile>();
                options.AddProfile(typeof(PaymentProfile));

            });
            services.AddControllersWithViews();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         if (env.IsDevelopment())
            {
                
         
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection(); 
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();//login logout kullanabilmek için
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Manage}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "admin",
                    pattern: "admin/{controller=Manage}/{action=Index}/{id}"
                    );
            }); 
        }

       
    }
}
