using System;
using System.Windows.Forms;

namespace ByteDev.Subtitles.SubtitlesManipulator
{
	public partial class MaxDurationForm : Form
	{
		public delegate void MaxDuration(int iMaxDuration);

		public event MaxDuration MaxDurationSet;

		public void InvokeMaxDurationSet(int maxDuration)
		{
			MaxDuration handler = MaxDurationSet;
			if (handler != null)
			{
				handler(maxDuration);
			}
		}

		public MaxDurationForm()
		{
			InitializeComponent();
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.InvokeMaxDurationSet(Convert.ToInt32(secondsMaxDurTextBox.Text));
			this.Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}

}
