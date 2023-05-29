using MediatR;
using Microsoft.AspNetCore.Mvc;
using Titan.Application.Tests.Queries.GetTestDetailsQuery;
using Titan.Application.Tests.Queries.GetTestList;

namespace Titan.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class TestController : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<TestListVm>> GetAll()
		{
			var query = new GetTestListQuery
			{

			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TestDetailsVm>> Get(Guid id)
		{
			var query = new GetTestDetailsQuery
			{
				Id = id
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}
	}
}
