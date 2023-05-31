using MediatR;

namespace Titan.Application.Tests.Commands.DeleteTest
{
	public class DeleteTestCommand :IRequest
	{
		public Guid Id { get; set; }
	}
}
