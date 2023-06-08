using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Titan.Application.Interfaces;

namespace Titan.Application.Tests.Queries.GetTestList
{
	public class GetTestListQueryHandler : IRequestHandler<GetTestListQuery, TestListVm>
	{
		private readonly ITestsDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetTestListQueryHandler(ITestsDbContext dbContext, IMapper mapper) 
			=> (_dbContext, _mapper) = (dbContext, mapper);

		public async Task<TestListVm> Handle(GetTestListQuery request,
			CancellationToken cancellationToken)
		{
			var testsQuery = await _dbContext.Tests
				.ProjectTo<TestLookupDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new TestListVm { Tests = testsQuery };
		}
	}
}