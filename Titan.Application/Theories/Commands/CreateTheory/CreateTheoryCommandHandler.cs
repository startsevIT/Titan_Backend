using MediatR;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Theories.Commands.CreateTheory
{
	public class CreateTheoryCommandHandler :IRequestHandler<CreateTheoryCommand, Guid>
	{
		private readonly ITheoriesDbContext _dbContext;
		public CreateTheoryCommandHandler(ITheoriesDbContext dbContext) =>
			_dbContext = dbContext;
		public async Task<Guid> Handle(CreateTheoryCommand request, CancellationToken cancellationToken)
		{
			var theory = new Theory
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				Title = request.Title,
			};

			await _dbContext.Theories.AddAsync(theory, cancellationToken);
			await _dbContext.SaveChangesAsync(cancellationToken);

			return theory.Id;
		}
	}
}
