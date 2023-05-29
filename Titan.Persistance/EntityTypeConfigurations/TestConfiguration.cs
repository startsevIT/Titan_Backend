using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Titan.Domain;
namespace Titan.Persistance.EntityTypeConfigurations
{
	public class TestConfiguration : IEntityTypeConfiguration<Test>
	{
		public void Configure(EntityTypeBuilder<Test> builder) 
		{ 
			builder.HasKey(t => t.Id);
			builder.HasIndex(t => t.Id).IsUnique();
			//Почитать про правила в документации EntityFramework
		}
	}
}
