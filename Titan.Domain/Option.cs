using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Domain
{
	public class Option
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public bool Correctness { get; set; }
	}
}
