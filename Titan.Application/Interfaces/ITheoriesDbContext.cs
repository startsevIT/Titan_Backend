using Microsoft.EntityFrameworkCore;
using Titan.Domain;

namespace Titan.Application.Interfaces
{
	public interface ITheoriesDbContext
	{
		DbSet<Theory> Theories { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
