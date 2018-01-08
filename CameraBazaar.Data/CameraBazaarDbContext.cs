namespace CameraBazaar.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CameraBazaarDbContext : IdentityDbContext<User>
    {
		public DbSet<Camera> Cameras { get; set; }

        public CameraBazaarDbContext(DbContextOptions<CameraBazaarDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder
				.Entity<User>()
				.HasMany(u => u.Cameras)
				.WithOne(c => c.User)
				.HasForeignKey(c => c.UserId);

            base.OnModelCreating(builder);
        }
    }
}
