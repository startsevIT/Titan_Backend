using MediatR;

namespace Titan.Application.Theories.Commands.CreateTheory
{
	public class CreateTheoryCommand : IRequest<Guid>
	{
		public string Name { get; set; }
		public string Title { get; set; }
		public string Picture { get; set; }
	}
}
