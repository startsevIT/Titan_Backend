using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Titan.Application.Interfaces;

namespace Titan.Persistance
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistance( this IServiceCollection services, IConfiguration configuration)
		{
			var testConnectionString = configuration["TestDbConnection"];
			services.AddDbContext<TestsDbContext>(options =>
			{
				options.UseSqlite(testConnectionString);
			});
			services.AddScoped<ITestsDbContext>(provider => 
				provider.GetService<TestsDbContext>());

			var theoryConnectionString = configuration["TheoryDbConnection"];
			services.AddDbContext<TheoriesDbContext>(options =>
			{
				options.UseSqlite(theoryConnectionString);
			});
			services.AddScoped<ITheoriesDbContext>(provider =>
				provider.GetService<TheoriesDbContext>());

			return services;
		}
	}
}
