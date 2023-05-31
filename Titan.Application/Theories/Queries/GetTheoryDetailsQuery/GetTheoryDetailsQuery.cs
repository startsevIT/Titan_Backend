using MediatR;

namespace Titan.Application.Theories.Queries.GetTheoryDetailsQuery
{
	public class GetTheoryDetailsQuery : IRequest<TheoryDetailsVm>
	{
		public Guid Id { get; set; }
	}
}
