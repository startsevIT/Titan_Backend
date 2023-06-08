using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Titan.Application.Tests.Commands.CreateTest;
using Titan.Application.Tests.Commands.DeleteTest;
using Titan.Application.Tests.Commands.UpdateTest;
using Titan.Application.Tests.Queries.GetTestDetailsQuery;
using Titan.Application.Tests.Queries.GetTestList;
using Titan.WebApi.Models;

namespace Titan.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class TestController : BaseController
	{
		private readonly IMapper _mapper;
		public TestController(IMapper mapper) => _mapper = mapper;

		[HttpGet]
		[Authorize]
		public async Task<ActionResult<TestListVm>> GetAll()
		{
			var query = new GetTestListQuery
			{

			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<TestDetailsVm>> Get(Guid id)
		{
			var query = new GetTestDetailsQuery
			{
				Id = id
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpPost]
		[Authorize]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateTestDto createTestDto)
		{
			var command = _mapper.Map<CreateTestCommand>(createTestDto);
			var testId = await Mediator.Send(command);
			return Ok(testId);
		}

		[HttpPut]
		[Authorize]
		public async Task<IActionResult> Update([FromBody] UpdateTestDto updateTestDto)
		{
			var command = _mapper.Map<UpdateTestCommand>(updateTestDto);
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> Delete(Guid id)
		{ 
			var command = new DeleteTestCommand
			{
				Id = id
			};
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
