using MediatR;
using Titan.Domain;

namespace Titan.Application.Theories.Commands.UpdateTheory
{
	public class UpdateTheoryCommand :IRequest
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
		public string Title { get; set; }

	}
}
