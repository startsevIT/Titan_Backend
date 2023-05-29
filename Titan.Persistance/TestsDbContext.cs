using Microsoft.EntityFrameworkCore;
using Titan.Application.Interfaces;
using Titan.Domain;
using Titan.Persistance.EntityTypeConfigurations;

namespace Titan.Persistance
{
	public class TestsDbContext : DbContext, ITestsDbContext
	{
		public DbSet<Test> Tests { get; set; }
		public TestsDbContext(DbContextOptions<TestsDbContext> options)
			: base(options) { }
		protected override void OnModelCreating (ModelBuilder builder) 
		{
			builder.ApplyConfiguration(new TestConfiguration());
			base.OnModelCreating(builder);
		}

	}
}
