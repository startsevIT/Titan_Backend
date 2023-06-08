using AutoMapper;
using Titan.Application.Common.Mapping;
using Titan.Domain;

namespace Titan.Application.Tests.Queries.GetTestList
{
	public class TestLookupDto : IMapWith<Test>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Test, TestLookupDto>()
				.ForMember(testDto => testDto.Id,
				opt => opt.MapFrom(test => test.Id))
				.ForMember(testDto => testDto.Picture,
				opt => opt.MapFrom(test => test.Picture))
				.ForMember(testDto => testDto.Name,
				opt => opt.MapFrom(test => test.Name));
		}
	}
}
