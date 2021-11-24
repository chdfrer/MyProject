using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Database;
using MyBlog.Models.UserModels;
using MyBlog.Services.levelListServices;
using System;

namespace MyBlog
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
            services.AddControllersWithViews();

            // <---- Custums Services ---->
            
            services.AddSendMailService(Configuration);     //Register SendMailService to DI throw extension
            services.AddSingleton<CreateLevelList>();

            //Configure Route
            services.Configure<RouteOptions>(option =>
            {
                option.AppendTrailingSlash = false;
                option.LowercaseUrls = true;
                option.LowercaseQueryStrings = false;
            });

            //Register MyBlogDbContext to DI
            services.AddDbContext<MyBlogDbContext>(option =>
            {
                string connectionString = Configuration.GetConnectionString("MyBlogDbContext");
                option.UseSqlServer(connectionString);
            });

            //Register Identity service
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MyBlogDbContext>()
                .AddDefaultTokenProviders();

            //Configure IdentityOptions
            services.Configure<IdentityOptions>(option =>
            {
                //Setting password
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 3;

                //Setting lockout
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                option.Lockout.MaxFailedAccessAttempts = 3;

                //Setting user
                option.User.RequireUniqueEmail = true;
            });

            //Setting cookies
            services.ConfigureApplicationCookie(option =>
            {
                option.Cookie.Name = "MyBlog";
                option.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                option.LoginPath = $"/Account/login/";
                option.LogoutPath = $"/Account/logout/";
                option.AccessDeniedPath = $"/Account/AccessDenied";
            });

            //Setting SecurityStampValidator
            services.Configure<SecurityStampValidatorOptions>(option =>
            {
                //Change securityStamp every 5 second
                option.ValidationInterval = TimeSpan.FromSeconds(5);
            });

            //Create policy
            services.AddAuthorization(option =>
            {
                //Create "Admin" policy
                option.AddPolicy("Admin", policy =>
                {
                    policy.RequireUserName("admin");
                });
            });

            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    // Đọc thông tin Authentication:Google từ appsettings.json
                    IConfigurationSection googleAuthSection = Configuration.GetSection("Authentication:Google");

                    // Thiết lập ClientID và ClientSecret để truy cập API google
                    googleOptions.ClientId = googleAuthSection["ClientId"];
                    googleOptions.ClientSecret = googleAuthSection["ClientSecret"];
                    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                    googleOptions.CallbackPath = "/dang-nhap-tu-google";
                })
                .AddFacebook(facebookOptions=>
                {
                    IConfigurationSection facebookAuthSection = Configuration.GetSection("Authentication:Facebook");

                    facebookOptions.ClientId = facebookAuthSection["ClientId"];
                    facebookOptions.ClientSecret = facebookAuthSection["ClientSecret"];

                    facebookOptions.CallbackPath = "/dang-nhap-tu-facebook";
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();    // Restore login information (authentication)
            app.UseAuthorization();     // Recover user's permission information

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            
            app.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync("Page not found!");
            });
        }
    }
}
