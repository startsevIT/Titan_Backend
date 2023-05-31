using MediatR;
using Titan.Application.Tests.Queries.GetTestList;

namespace Titan.Application.Theories.Queries.GetTheoryList
{
	public class GetTheoryListQuery : IRequest<TheoryListVm>
	{
	}
}
