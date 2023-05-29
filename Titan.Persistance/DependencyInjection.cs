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
			var connectionString = configuration["DbConnection"];
			services.AddDbContext<TestsDbContext>(options =>
			{
				options.UseSqlite(connectionString);
			});
			services.AddScoped<ITestsDbContext>(provider => 
				provider.GetService<TestsDbContext>());
			return services;
		}
	}
}
