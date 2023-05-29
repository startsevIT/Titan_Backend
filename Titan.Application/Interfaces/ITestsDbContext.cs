using Microsoft.EntityFrameworkCore;
using Titan.Domain;

namespace Titan.Application.Interfaces
{
	public interface ITestsDbContext
	{
		DbSet<Test> Tests { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);

	}
}
