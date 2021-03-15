using System.Windows.Forms;

namespace ByteDev.Subtitles.SubtitlesManipulator.Factories
{
	public class DataGridTableStyleFactory
	{
		public DataGridTableStyle Create()
		{
			var col1 = new DataGridTextBoxColumn { MappingName = @"OrderID", HeaderText = @"OrderID", Width = 50 };
			col1.TextBox.Enabled = false;

			var col2 = new DataGridTextBoxColumn { MappingName = @"TimeStart", HeaderText = @"TimeStart", Width = 80 };
			col2.TextBox.Enabled = true;

			var col3 = new DataGridTextBoxColumn { MappingName = @"TimeEnd", HeaderText = @"TimeEnd", Width = 80 };
			col3.TextBox.Enabled = true;

			var col4 = new DataGridTextBoxColumn { MappingName = @"Text", HeaderText = @"Text", Width = 350 };
			col4.TextBox.Enabled = true;

			// Add the GridColumnStyles to the DataGrid's Column Styles collection.
			// Place the "ID" column (column 1) last since it is not visible.

			var dataGridTableStyle = new DataGridTableStyle { MappingName = "Subtitles" };

			dataGridTableStyle.GridColumnStyles.Add(col1);
			dataGridTableStyle.GridColumnStyles.Add(col2);
			dataGridTableStyle.GridColumnStyles.Add(col3);
			dataGridTableStyle.GridColumnStyles.Add(col4);
			return dataGridTableStyle;
		}
	}
}
