using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Titan.Application.Common.Exeptions;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Theories.Queries.GetTheoryDetailsQuery
{
	public class GetTheoryDetailsQueryHandler : IRequestHandler<GetTheoryDetailsQuery, TheoryDetailsVm>
	{
		private readonly ITheoriesDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetTheoryDetailsQueryHandler(ITheoriesDbContext dbContext,
			IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

		public async Task<TheoryDetailsVm> Handle(GetTheoryDetailsQuery request,
			CancellationToken cancellationToken)
		{
			var entity = await _dbContext.Theories
				.FirstOrDefaultAsync(theory =>
				theory.Id == request.Id, cancellationToken);
			if (entity == null)
				throw new NotFoundException(nameof(Theory), request.Id);
			return _mapper.Map<TheoryDetailsVm>(entity);
		}
	}
}
