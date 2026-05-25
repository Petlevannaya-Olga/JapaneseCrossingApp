namespace JapaneseCrossingApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			buttonToRight = new Button();
			buttonToLeft = new Button();
			toolTip1 = new ToolTip(components);
			timer1 = new System.Windows.Forms.Timer(components);
			buttonHint = new Button();
			buttonRestart = new Button();
			textBoxProcess = new TextBox();
			SuspendLayout();
			// 
			// buttonToRight
			// 
			buttonToRight.BackgroundImage = Properties.Resources.icons8_arrow_40;
			buttonToRight.BackgroundImageLayout = ImageLayout.Stretch;
			buttonToRight.Location = new Point(12, 570);
			buttonToRight.Name = "buttonToRight";
			buttonToRight.Size = new Size(94, 29);
			buttonToRight.TabIndex = 0;
			buttonToRight.UseVisualStyleBackColor = true;
			buttonToRight.Click += ButtonToRight_Click;
			// 
			// buttonToLeft
			// 
			buttonToLeft.BackgroundImage = Properties.Resources.icons8_arrow_pointing_left_40;
			buttonToLeft.BackgroundImageLayout = ImageLayout.Stretch;
			buttonToLeft.Location = new Point(1009, 570);
			buttonToLeft.Name = "buttonToLeft";
			buttonToLeft.Size = new Size(94, 29);
			buttonToLeft.TabIndex = 1;
			buttonToLeft.UseVisualStyleBackColor = true;
			buttonToLeft.Click += ButtonToLeft_Click;
			// 
			// timer1
			// 
			timer1.Tick += Timer1_Tick;
			// 
			// buttonHint
			// 
			buttonHint.Location = new Point(1011, 12);
			buttonHint.Name = "buttonHint";
			buttonHint.Size = new Size(94, 29);
			buttonHint.TabIndex = 1;
			buttonHint.Text = "Подсказка";
			buttonHint.UseVisualStyleBackColor = true;
			buttonHint.Click += ButtonHint_Click;
			// 
			// buttonRestart
			// 
			buttonRestart.Location = new Point(1011, 47);
			buttonRestart.Name = "buttonRestart";
			buttonRestart.Size = new Size(94, 29);
			buttonRestart.TabIndex = 1;
			buttonRestart.Text = "Заново";
			buttonRestart.UseVisualStyleBackColor = true;
			buttonRestart.Click += ButtonRestart_Click;
			// 
			// textBoxProcess
			// 
			textBoxProcess.Location = new Point(328, 13);
			textBoxProcess.Multiline = true;
			textBoxProcess.Name = "textBoxProcess";
			textBoxProcess.ReadOnly = true;
			textBoxProcess.Size = new Size(484, 77);
			textBoxProcess.TabIndex = 2;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = Properties.Resources.background1;
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(1117, 613);
			Controls.Add(textBoxProcess);
			Controls.Add(buttonRestart);
			Controls.Add(buttonHint);
			Controls.Add(buttonToLeft);
			Controls.Add(buttonToRight);
			DoubleBuffered = true;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Японская переправа";
			Paint += Form1_Paint;
			MouseDown += Form1_MouseDown;
			MouseMove += Form1_MouseMove;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button buttonToRight;
        private Button buttonToLeft;
        private ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
		private Button buttonHint;
		private Button buttonRestart;
		private TextBox textBoxProcess;
	}
}
