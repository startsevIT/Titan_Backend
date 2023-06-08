using MediatR;
using Titan.Application.Common.Exeptions;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Theories.Commands.DeleteTheory
{
	public class DeleteTheoryCommandHandler : IRequestHandler<DeleteTheoryCommand>
	{
		private readonly ITheoriesDbContext _dbContext;
		public DeleteTheoryCommandHandler(ITheoriesDbContext dbContext) =>
			_dbContext = dbContext;
		public async Task Handle(DeleteTheoryCommand request, CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Theories.FindAsync(new object[] { request.Id }, cancellationToken);

			if (entity == null)
				throw new NotFoundException(nameof(Theory), request.Id);

			_dbContext.Theories.Remove(entity);
			_dbContext.SaveChangesAsync(cancellationToken);
		}
	}
}