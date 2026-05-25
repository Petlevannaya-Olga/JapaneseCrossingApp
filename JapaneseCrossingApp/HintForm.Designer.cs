namespace JapaneseCrossingApp
{
	partial class HintForm
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
			textBox = new TextBox();
			buttonClose = new Button();
			SuspendLayout();
			// 
			// textBox
			// 
			textBox.Location = new Point(12, 12);
			textBox.Multiline = true;
			textBox.Name = "textBox";
			textBox.ReadOnly = true;
			textBox.Size = new Size(431, 538);
			textBox.TabIndex = 0;
			// 
			// buttonClose
			// 
			buttonClose.Location = new Point(349, 556);
			buttonClose.Name = "buttonClose";
			buttonClose.Size = new Size(94, 29);
			buttonClose.TabIndex = 1;
			buttonClose.Text = "Закрыть";
			buttonClose.UseVisualStyleBackColor = true;
			buttonClose.Click += ButtonClose_Click;
			// 
			// HintForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(455, 595);
			Controls.Add(buttonClose);
			Controls.Add(textBox);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "HintForm";
			StartPosition = FormStartPosition.CenterParent;
			Text = "HintForm";
			Load += HintForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox;
		private Button buttonClose;
	}
}