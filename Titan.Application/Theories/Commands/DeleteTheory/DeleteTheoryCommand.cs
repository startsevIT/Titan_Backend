using MediatR;

namespace Titan.Application.Theories.Commands.DeleteTheory
{
	public class DeleteTheoryCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
