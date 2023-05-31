using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Titan.Application.Tests.Commands.DeleteTest;
using Titan.Application.Tests.Commands.UpdateTest;
using Titan.Application.Theories.Commands.CreateTheory;
using Titan.Application.Theories.Commands.DeleteTheory;
using Titan.Application.Theories.Commands.UpdateTheory;
using Titan.Application.Theories.Queries.GetTheoryDetailsQuery;
using Titan.Application.Theories.Queries.GetTheoryList;
using Titan.WebApi.Models;

namespace Titan.WebApi.Controllers
{
	[Route("api/[controller]")]
	public class TheoryController : BaseController
	{
		private readonly IMapper _mapper;
		public TheoryController(IMapper mapper) => _mapper = mapper;

		[HttpGet]
		public async Task<ActionResult<TheoryListVm>> GetAll()
		{
			var query = new GetTheoryListQuery
			{
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TheoryDetailsVm>> Get(Guid id)
		{
			var query = new GetTheoryDetailsQuery
			{
				Id = id
			};
			var vm = await Mediator.Send(query);
			return Ok(vm);
		}
		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateTheoryDto createTheoryDto)
		{
			var command = _mapper.Map<CreateTheoryCommand>(createTheoryDto);
			var testId = await Mediator.Send(command);
			return Ok(testId);
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateTheoryDto updateTheoryDto)
		{
			var command = _mapper.Map<UpdateTheoryCommand>(updateTheoryDto);
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteTheoryCommand
			{
				Id = id
			};
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
