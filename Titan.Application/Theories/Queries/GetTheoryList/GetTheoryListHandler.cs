using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Titan.Application.Interfaces;

namespace Titan.Application.Theories.Queries.GetTheoryList
{
	public class GetTheoryListHandler : IRequestHandler<GetTheoryListQuery, TheoryListVm>
	{
		private readonly ITheoriesDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetTheoryListHandler(ITheoriesDbContext dbContext, IMapper mapper)
			=> (_dbContext, _mapper) = (dbContext, mapper);

		public async Task<TheoryListVm> Handle(GetTheoryListQuery request, CancellationToken cancellationToken)
		{ 
			var theoriesQuery = await _dbContext.Theories
				.ProjectTo<TheoryLookupDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new TheoryListVm { Theories = theoriesQuery };
		}
	}
}