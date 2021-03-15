using System;
using System.IO;
using System.Windows.Forms;
using ByteDev.Subtitles.SubRip;
using FileDialog = WindowsFormsCommon.App.Dialogs.FileDialog;

namespace ByteDev.Subtitles.SubtitlesManipulator
{
	public partial class MainForm : Form
	{
		private const string DefaultTitle = "Subtitles Manipulator";

		private string openFileLocation;
		private GridWrapper gridWrapper;

		private GridWrapper GridWrapper => gridWrapper ?? (gridWrapper = new GridWrapper(videoDataGrid));

        private bool IsFileOpen => (!string.IsNullOrEmpty(openFileLocation));

        public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SetTitle();
		}
		
		private void SetStatus(string message)
		{
			statusStrip.Text = message;
		}

		private void SetTitle()
		{
			SetTitle(string.Empty);
		}

		private void SetTitle(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				this.Text = DefaultTitle;
			}
			else
			{
				this.Text = DefaultTitle + @" - " + message;
			}
		}

		private void FileOpen()
		{
			const string SRT_FILE_SUFFIX = "srt";
			string file = FileDialog.SelectFile(openFileLocation, SRT_FILE_SUFFIX);

			if (string.IsNullOrEmpty(file))
			{
				return;
			}

			openFileLocation = file;
			GridWrapper.LoadSrtFile(openFileLocation);

			SetTitle(Path.GetFileName(openFileLocation));
			SetStatus(@"File opened: " + openFileLocation);
		}

		private void FileSave()
		{
			if (IsFileOpen)
			{
				GridWrapper.SaveSrtFile(openFileLocation);
				SetStatus(@"File saved");
			}
		}

		private void FileSaveAs()
		{
			var saveFileDialog = new SaveFileDialog();
			DialogResult dialogResult = saveFileDialog.ShowDialog();

			if (DialogResult.OK == dialogResult)
			{
				GridWrapper.SaveSrtFile(saveFileDialog.FileName);
				SetStatus(@"File saved as: " + saveFileDialog.FileName);
			}
		}
		
		private void FileClose()
		{
			GridWrapper.ClearGrid();
            GridWrapper.OpenSubRipFile = null;
			openFileLocation = string.Empty;

			SetTitle();
			SetStatus(@"File closed");
		}

		private static void DisplayAbout()
		{
			string text = DefaultTitle + "\n" +
				"Version: " + Application.ProductVersion;

			MessageBox.Show(text, @"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private static void Quit()
		{
			Application.Exit();
		}

		#region Menu Event Handlers

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileOpen();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileClose();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileSaveAs();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FileSave();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Quit();
		}

		private void setAbsoluteMaxDurationToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!IsFileOpen)
			{
				return;
			}

			SetStatus(string.Empty);
			ShowMaxDurationForm();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DisplayAbout();
		}

		#endregion

		#region Max Duration

		private void maxDurationForm_MaxDurationSet(int maxDuration)
		{
			SetMaxDuration(maxDuration);
			SetStatus($"Max duration of {maxDuration} set");
		}

		private void SetMaxDuration(int seconds)
		{
            GridWrapper.OpenSubRipFile.SetMaxDuration(new SubRipTimeSpan(0, 0, seconds, 0));

			GridWrapper.RefreshGrid();
		}

		private void ShowMaxDurationForm()
		{
			var maxDurationForm = new MaxDurationForm();
			maxDurationForm.MaxDurationSet += maxDurationForm_MaxDurationSet;
			maxDurationForm.Show();
		}

		#endregion

		private void videoDataGrid_CurrentCellChanged(object sender, EventArgs e)
		{
			if (IsFileOpen)
			{
				GridWrapper.UpdateSrtVideoWithPrevCell();
				GridWrapper.SaveCurrentCell();
			}
		}
	}
}
