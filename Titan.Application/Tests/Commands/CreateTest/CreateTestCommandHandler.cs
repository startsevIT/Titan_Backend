using MediatR;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Tests.Commands.CreateTest
{
	public class CreateTestCommandHandler : IRequestHandler<CreateTestCommand, Guid>
	{
		private readonly ITestsDbContext _dbContext;
		public CreateTestCommandHandler(ITestsDbContext dbContext) =>
			_dbContext = dbContext;
		public async Task<Guid> Handle(CreateTestCommand request, CancellationToken cancellationToken)
		{
			var test = new Test
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Questions= request.Questions,
			};

			await _dbContext.Tests.AddAsync(test, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return test.Id;
		}
	}
}
