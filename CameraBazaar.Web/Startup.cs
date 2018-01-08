namespace CameraBazaar.Web
{
    using AutoMapper;
    using CameraBazaar.Infrastructure.Automapper;
    using Common;
    using Data;
    using Data.Models;
    using Infrastructure.Extensions;
    using Infrastructure.Filters;
    using Microsoft.AspNetCore.Authentication.Facebook;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Contracts;
    using Services.Implementations.Camera;
    using Services.Implementations.User;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CameraBazaarDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(CameraBazaarConstants.DefaultConnection)));

			services.AddScoped<CameraBazaarDbContext>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<CameraBazaarDbContext>()
                .AddDefaultTokenProviders();

			//services.AddAuthentication().AddFacebook(facebookOptions =>
			//{
			//	facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
			//	facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
			//});

			services.Configure<IdentityOptions>(opt =>
			{
				opt.Password.RequireUppercase = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequireLowercase = false;
				opt.Password.RequiredLength = CameraBazaarConstants.User.PasswordMinLength;

				opt.User.RequireUniqueEmail = true;
			});

			services.AddTransient<ICameraService, CameraService>();

			services.AddTransient<IUserService, UserService>();

			services.AddAutoMapper(cfg=> AutomapperConfig.Init(cfg));

			services.AddMvc(opt => 
			{
				opt.Filters.Add(new LogFilterAttribute());
				opt.Filters.Add(new TimerFilterAttribute());
			});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			app.UseDatabaseMigration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

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
