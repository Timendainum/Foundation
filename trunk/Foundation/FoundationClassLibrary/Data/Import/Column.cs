
namespace FoundationClassLibrary.Data.Import
{
	public class Column : Base
	{
		public Column()
		{
			// nothing
		}
		
		public Column(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
