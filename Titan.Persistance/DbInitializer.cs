namespace Titan.Persistance
{
	public class DbInitializer
	{
		public static void Initialize(TestsDbContext context) 
		{
			context.Database.EnsureCreated();
		}
		public static void Initialize(TheoriesDbContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
