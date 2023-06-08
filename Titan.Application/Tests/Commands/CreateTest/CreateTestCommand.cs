using MediatR;
using Titan.Domain;

namespace Titan.Application.Tests.Commands.CreateTest
{
	public class CreateTestCommand : IRequest<Guid>
	{
		public string Name { get; set; }
		public string Picture { get; set; }
		public List<Question> Questions { get; set; }
	}
}
