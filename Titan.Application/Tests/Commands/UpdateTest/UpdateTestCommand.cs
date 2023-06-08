using System;
using MediatR;
using Titan.Domain;

namespace Titan.Application.Tests.Commands.UpdateTest
{
	public class UpdateTestCommand :IRequest
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
		public List<Question> Questions { get; set; }

	}
}
