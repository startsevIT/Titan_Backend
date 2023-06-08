using MediatR;
using Microsoft.EntityFrameworkCore;
using Titan.Application.Common.Exeptions;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Tests.Commands.UpdateTest
{
	public class UpdateTestCommandHandler 
		: IRequestHandler<UpdateTestCommand>
	{
		private readonly ITestsDbContext _dbContext;
		public UpdateTestCommandHandler(ITestsDbContext dbContext) =>
			_dbContext = dbContext;

		public async Task Handle(UpdateTestCommand request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Tests.FirstOrDefaultAsync(test => test.Id == request.Id, cancellationToken);
			if (entity == null)
			{
				throw new NotFoundException(nameof(Test),request.Id);
			}

			entity.Name = request.Name;
			entity.Questions = request.Questions;
			entity.Picture = request.Picture;

			await _dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
