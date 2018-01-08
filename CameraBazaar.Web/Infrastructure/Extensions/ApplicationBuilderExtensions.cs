namespace CameraBazaar.Web.Infrastructure.Extensions
{
    using Common;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Threading.Tasks;

    public static class ApplicationBuilderExtensions
    {
		public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				serviceScope.ServiceProvider.GetRequiredService<CameraBazaarDbContext>().Database.Migrate();

				var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
				var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

				Task.Run(async () =>
				{
					var roleExists = await roleManager.RoleExistsAsync(CameraBazaarConstants.AdministratorRole);

					if (!roleExists)
					{
						await roleManager.CreateAsync(new IdentityRole()
						{
							Name = CameraBazaarConstants.AdministratorRole
						});
					}

					var adminUser = await userManager.FindByNameAsync(CameraBazaarConstants.AdminUserName);

					if(adminUser == null)
					{
						adminUser = new User()
						{
							UserName = CameraBazaarConstants.AdminUserName,
							Email = CameraBazaarConstants.AdminEmail
						};

						await userManager.CreateAsync(adminUser,CameraBazaarConstants.AdminPassword);

						await userManager.AddToRoleAsync(adminUser, CameraBazaarConstants.AdministratorRole);
					}
				})
				.GetAwaiter()
				.GetResult();
			}

			return app;
		}
    }
}
