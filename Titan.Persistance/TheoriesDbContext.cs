using Microsoft.EntityFrameworkCore;
using Titan.Application.Interfaces;
using Titan.Domain;
using Titan.Persistance.EntityTypeConfigurations;

namespace Titan.Persistance
{
	public class TheoriesDbContext : DbContext, ITheoriesDbContext
	{
		public DbSet<Theory> Theories { get; set; }
		public TheoriesDbContext(DbContextOptions<TheoriesDbContext> options)
			: base(options) { }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new TheoryConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
