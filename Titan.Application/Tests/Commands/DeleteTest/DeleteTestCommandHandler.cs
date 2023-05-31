using MediatR;
using Titan.Application.Common.Exeptions;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Tests.Commands.DeleteTest
{
	public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand>
	{
		private readonly ITestsDbContext _dbContext;
		public DeleteTestCommandHandler(ITestsDbContext dbContext) =>
			_dbContext = dbContext;
		public async Task Handle(DeleteTestCommand request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Tests.FindAsync(new object[] { request.Id },cancellationToken);

			if (entity == null)
			{
				throw new NotFoundException(nameof(Test), request.Id);
			}
			
			_dbContext.Tests.Remove(entity);
			_dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
