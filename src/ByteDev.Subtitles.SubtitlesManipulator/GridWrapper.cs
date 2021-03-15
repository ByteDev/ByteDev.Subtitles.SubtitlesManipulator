using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ByteDev.Subtitles.SubRip;
using ByteDev.Subtitles.SubtitlesManipulator.Factories;

namespace ByteDev.Subtitles.SubtitlesManipulator
{
	public class GridWrapper
	{
		private readonly DataGrid dataGrid;
		private DataGridCell previousCell;

        private enum GridColumn
		{
			OrderId = 0,
			TimeStart = 1,
			TimeEnd = 2,
			Text = 3
		}

		public SubRipFile OpenSubRipFile { get; set; }

		private DataTable GridTable => (DataTable)dataGrid.DataSource;

        public GridWrapper(DataGrid dataGrid)
		{
			this.dataGrid = dataGrid;
			InitGrid();
		}

		public void SaveCurrentCell()
		{
			previousCell.RowNumber = dataGrid.CurrentCell.RowNumber;
			previousCell.ColumnNumber = dataGrid.CurrentCell.ColumnNumber;
		}

		public void ClearGrid()
		{
			GridTable.Rows.Clear();
		}

		public void RefreshGrid()
		{
			ClearGrid();
			LoadSrtVideoIntoGrid();
		}

		public void LoadSrtFile(string fileLocation)
		{
			ClearGrid();
			OpenSubRipFile = SubRipFile.Load(fileLocation);

			LoadSrtVideoIntoGrid();
		}

		public void SaveSrtFile(string fileLocation)
		{
			File.WriteAllText(fileLocation, OpenSubRipFile.ToString());
		}

		public void UpdateSrtVideoWithPrevCell()
		{
			if (GridTable.Rows.Count < 1)
			{
				return;
			}

			string value = GridTable.Rows[previousCell.RowNumber].ItemArray[previousCell.ColumnNumber].ToString();

			var entry = OpenSubRipFile.Entries[previousCell.RowNumber];

			switch (previousCell.ColumnNumber)
			{
				case (int)GridColumn.OrderId:
					break;

				case (int)GridColumn.TimeStart:
					entry.Duration.Start = new SubRipTimeSpan(value);
					break;

				case (int)GridColumn.TimeEnd:
					entry.Duration.End = new SubRipTimeSpan(value);
					break;

				case (int)GridColumn.Text:
					entry.Text = value;
					break;

				default:
					throw new ApplicationException("Unknown column");
			}
		}

		private void InitGrid()
		{
			dataGrid.DataSource = new DataTableFactory().Create();

			DataGridTableStyle dataGridTableStyle = new DataGridTableStyleFactory().Create();
			dataGrid.TableStyles.Add(dataGridTableStyle);

			previousCell = new DataGridCell(0, 0);
		}

		private void LoadSrtVideoIntoGrid()
		{
			var factory = new DataRowFactory(GridTable);

			foreach (var entry in OpenSubRipFile.Entries)
			{
				DataRow dataRow = factory.Create(entry);

				GridTable.Rows.Add(dataRow);
			}
		}
	}
}
