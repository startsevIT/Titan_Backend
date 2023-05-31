using AutoMapper;
using Titan.Application.Common.Mapping;
using Titan.Application.Tests.Queries.GetTestList;
using Titan.Domain;

namespace Titan.Application.Theories.Queries.GetTheoryList
{
	public class TheoryLookupDto : IMapWith<Theory>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Theory, TheoryLookupDto>()
				.ForMember(testDto => testDto.Id,
				opt => opt.MapFrom(test => test.Id))
				.ForMember(testDto => testDto.Name,
				opt => opt.MapFrom(test => test.Name));
		}
	}
}
