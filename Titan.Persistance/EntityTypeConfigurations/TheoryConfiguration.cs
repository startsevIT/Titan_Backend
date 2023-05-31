using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Domain;

namespace Titan.Persistance.EntityTypeConfigurations
{
	public class TheoryConfiguration : IEntityTypeConfiguration<Theory>
	{
		public void Configure(EntityTypeBuilder<Theory> builder)
		{
			builder.HasKey(t => t.Id);
			builder.HasIndex(t => t.Id).IsUnique();
			//Почитать про правила в документации EntityFramework
		}
	}
}
