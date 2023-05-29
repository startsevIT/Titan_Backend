using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Application.Tests.Queries.GetTestDetailsQuery
{
	public class GetTestDetailsQuery : IRequest<TestDetailsVm>
	{
		public Guid Id { get; set; }
	}
}
