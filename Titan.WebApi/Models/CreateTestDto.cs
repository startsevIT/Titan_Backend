using AutoMapper;
using Titan.Application.Common.Mapping;
using Titan.Application.Tests.Commands.CreateTest;
using Titan.Domain;

namespace Titan.WebApi.Models
{
	public class CreateTestDto : IMapWith<CreateTestCommand>
	{
		public string Name { get; set; }
		public string Picture { get; set; }
		public List<Question> Questions { get; set; }

		public void Mapping(Profile profile) 
		{
			profile.CreateMap<CreateTestDto, CreateTestCommand>()
				.ForMember(testCommand => testCommand.Name,
				opt => opt.MapFrom(testDto => testDto.Name))
				.ForMember(testCommand => testCommand.Picture,
				opt => opt.MapFrom(testDto => testDto.Picture))
				.ForMember(testCommand => testCommand.Questions,
				opt => opt.MapFrom(testDto => testDto.Questions));
		}

	}
}
