using AutoMapper;
using Titan.Application.Common.Mapping;
using Titan.Application.Tests.Commands.UpdateTest;
using Titan.Application.Theories.Commands.UpdateTheory;
using Titan.Domain;

namespace Titan.WebApi.Models
{
	public class UpdateTheoryDto : IMapWith<UpdateTheoryCommand>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }
		public string Title { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateTheoryDto, UpdateTheoryCommand>()
				.ForMember(testCommand => testCommand.Id,
				opt => opt.MapFrom(testDto => testDto.Id))
				.ForMember(testCommand => testCommand.Name,
				opt => opt.MapFrom(testDto => testDto.Name))
				.ForMember(testCommand => testCommand.Picture,
				opt => opt.MapFrom(testDto => testDto.Picture))
				.ForMember(testCommand => testCommand.Title,
				opt => opt.MapFrom(testDto => testDto.Title));
		}
	}
}
