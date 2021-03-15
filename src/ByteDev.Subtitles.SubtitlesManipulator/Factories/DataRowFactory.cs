using System.Data;
using ByteDev.Subtitles.SubRip;

namespace ByteDev.Subtitles.SubtitlesManipulator.Factories
{
	public class DataRowFactory
	{
		private readonly DataTable dataTable;

		public DataRowFactory(DataTable dataTable)
		{
			this.dataTable = dataTable;
		}

		public DataRow Create(SubRipEntry entry)
		{
			DataRow dr = dataTable.NewRow();

			dr["OrderID"] = entry.OrderId.ToString();
			dr["TimeStart"] = entry.Duration.Start.ToString();
			dr["TimeEnd"] = entry.Duration.End.ToString();
			dr["Text"] = entry.Text;

			return dr;
		}
	}
}
