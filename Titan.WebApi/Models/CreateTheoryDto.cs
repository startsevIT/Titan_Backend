using AutoMapper;
using Titan.Application.Common.Mapping;
using Titan.Application.Tests.Commands.CreateTest;
using Titan.Application.Theories.Commands.CreateTheory;
using Titan.Domain;

namespace Titan.WebApi.Models
{
	public class CreateTheoryDto :IMapWith<CreateTheoryCommand>
	{
		public string Name { get; set; }
		public string Picture { get; set; }
		public string Title { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateTheoryDto, CreateTheoryCommand>()
				.ForMember(theoryCommand => theoryCommand.Name,
				opt => opt.MapFrom(testDto => testDto.Name))
				.ForMember(testCommand => testCommand.Picture,
				opt => opt.MapFrom(testDto => testDto.Picture))
				.ForMember(testCommand => testCommand.Title,
				opt => opt.MapFrom(testDto => testDto.Title));
		}
	}
}
