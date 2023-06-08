using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titan.Application.Common.Mapping;
using Titan.Domain;

namespace Titan.Application.Tests.Queries.GetTestDetailsQuery
{
	public class TestDetailsVm : IMapWith<Test>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Picture { get; set; }	
		public List<Question> Questions { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Test, TestDetailsVm>()
				.ForMember(testVm => testVm.Id,
				opt => opt.MapFrom(test => test.Id))
				.ForMember(testVm => testVm.Picture,
				opt => opt.MapFrom(test => test.Picture))
				.ForMember(testVm => testVm.Name,
				opt => opt.MapFrom(test => test.Name))
				.ForMember(testVm => testVm.Questions,
				opt => opt.MapFrom(test => test.Questions));
		}
	}
}
