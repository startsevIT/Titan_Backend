namespace Titan.Domain
{
	public class Question
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<Option> options { get; set; }
	}
}
