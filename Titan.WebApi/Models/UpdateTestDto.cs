using AutoMapper;
using Titan.Application.Common.Mapping;
using Titan.Application.Tests.Commands.UpdateTest;
using Titan.Domain;

namespace Titan.WebApi.Models
{
	public class UpdateTestDto : IMapWith<UpdateTestCommand>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<Question> Questions { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateTestDto, UpdateTestCommand>()
				.ForMember(testCommand => testCommand.Id,
				opt => opt.MapFrom(testDto => testDto.Id))
				.ForMember(testCommand => testCommand.Name,
				opt => opt.MapFrom(testDto => testDto.Name))
				.ForMember(testCommand => testCommand.Questions,
				opt => opt.MapFrom(testDto => testDto.Questions));
		}
	}
}
