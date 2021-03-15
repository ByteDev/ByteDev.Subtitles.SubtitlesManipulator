using System.Data;

namespace ByteDev.Subtitles.SubtitlesManipulator.Factories
{
	public class DataTableFactory
	{
		public DataTable Create()
		{
			var dataTable = new DataTable("Subtitles");

			dataTable.Columns.Add("OrderID");
			dataTable.Columns.Add("TimeStart");
			dataTable.Columns.Add("TimeEnd");
			dataTable.Columns.Add("Text");
			return dataTable;
		}
	}
}
