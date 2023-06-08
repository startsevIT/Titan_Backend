using MediatR;
using Microsoft.EntityFrameworkCore;
using Titan.Application.Common.Exeptions;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Theories.Commands.UpdateTheory
{
	public class UpdateTheoryCommandHandler : IRequestHandler<UpdateTheoryCommand>
	{
		private readonly ITheoriesDbContext _dbContext;
		public UpdateTheoryCommandHandler(ITheoriesDbContext dbContext) =>
			_dbContext = dbContext;
		public async Task Handle(UpdateTheoryCommand request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Theories.FirstOrDefaultAsync(test => test.Id == request.Id, cancellationToken);

			if (entity == null)
				throw new NotFoundException(nameof(Test), request.Id);

			entity.Name = request.Name;
			entity.Title = request.Title;
			entity.Picture = request.Picture;

			await _dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}
