using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Titan.Application.Common.Exeptions;
using Titan.Application.Interfaces;
using Titan.Domain;

namespace Titan.Application.Tests.Queries.GetTestDetailsQuery
{
	public class GetTestDetailsQueryHandler 
		: IRequestHandler<GetTestDetailsQuery, TestDetailsVm>
	{
		private readonly ITestsDbContext _dbContext;
		private readonly IMapper _mapper;

		public GetTestDetailsQueryHandler(ITestsDbContext dbContext, 
			IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

		public async Task<TestDetailsVm> Handle(GetTestDetailsQuery request,
			CancellationToken cancellationToken)
		{ 
			var entity = await _dbContext.Tests
				.FirstOrDefaultAsync(test =>
				test.Id == request.Id,cancellationToken);
			if (entity == null)
				throw new NotFoundException(nameof(Test),request.Id); 
			return _mapper.Map<TestDetailsVm>(entity);
		}
	}
}
