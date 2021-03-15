namespace ByteDev.Subtitles.SubtitlesManipulator
{
	partial class MaxDurationForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.labSeconds = new System.Windows.Forms.Label();
			this.secondsMaxDurTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(131, 68);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 18;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(47, 68);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(75, 23);
			this.okButton.TabIndex = 17;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// labSeconds
			// 
			this.labSeconds.Location = new System.Drawing.Point(3, 16);
			this.labSeconds.Name = "labSeconds";
			this.labSeconds.Size = new System.Drawing.Size(56, 16);
			this.labSeconds.TabIndex = 16;
			this.labSeconds.Text = "Seconds:";
			this.labSeconds.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// secondsMaxDurTextBox
			// 
			this.secondsMaxDurTextBox.Location = new System.Drawing.Point(63, 12);
			this.secondsMaxDurTextBox.Name = "secondsMaxDurTextBox";
			this.secondsMaxDurTextBox.Size = new System.Drawing.Size(48, 20);
			this.secondsMaxDurTextBox.TabIndex = 15;
			this.secondsMaxDurTextBox.Text = "5";
			// 
			// MaxDurationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(217, 106);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.labSeconds);
			this.Controls.Add(this.secondsMaxDurTextBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MaxDurationForm";
			this.Text = "Set Max Duration";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label labSeconds;
		private System.Windows.Forms.TextBox secondsMaxDurTextBox;
	}
}