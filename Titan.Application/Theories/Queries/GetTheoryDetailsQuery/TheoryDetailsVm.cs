using AutoMapper;
using Titan.Application.Common.Mapping;
using Titan.Domain;

namespace Titan.Application.Theories.Queries.GetTheoryDetailsQuery
{
	public class TheoryDetailsVm : IMapWith<Theory>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Title { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Theory, TheoryDetailsVm>()
				.ForMember(testVm => testVm.Id,
				opt => opt.MapFrom(test => test.Id))
				.ForMember(testVm => testVm.Name,
				opt => opt.MapFrom(test => test.Name))
				.ForMember(testVm => testVm.Title,
				opt => opt.MapFrom(test => test.Title));
		}
	}
}
