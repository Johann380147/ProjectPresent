using SQLite;
using System.Collections.Generic;

namespace ProjectPresent
{
	[Table("Students")]
	public class Students
	{
		[AutoIncrement, PrimaryKey, Column("_id")]
		public int ID { get; set; }

		public string AdminNo { get; set; }
		public string Name { get; set; }
		public string TimeClocked { get; set; }
		public string Date { get; set; }
	}

	public class SearchHistory
	{
		public List<string> textHistoryList { get; set; }
		public List<List<Students>> studentDataList { get; set; }
		public List<int> numberOfResults { get; set; }
        public SearchHistory()
        {
            textHistoryList = new List<string>();
            studentDataList = new List<List<Students>>();
            numberOfResults = new List<int>();
        }
	}
}

