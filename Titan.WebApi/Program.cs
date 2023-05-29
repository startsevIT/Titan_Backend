using System.Reflection;
using Titan.Application;
using Titan.Application.Common.Mapping;
using Titan.Application.Interfaces;
using Titan.Persistance;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddAutoMapper(config =>
{
	config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
	config.AddProfile(new AssemblyMappingProfile(typeof(ITestsDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistance(configuration);
builder.Services.AddControllers();
builder.Services.AddCors(option =>
{
	option.AddPolicy("AllowAll", policy =>
	{
		policy.AllowAnyHeader();
		policy.AllowAnyMethod();
		policy.AllowAnyOrigin();
	});
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	try
	{
		var context = serviceProvider.GetRequiredService<TestsDbContext>();
		DbInitializer.Initialize(context);
	}
	catch (Exception exception)
	{

	}
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.Run();
