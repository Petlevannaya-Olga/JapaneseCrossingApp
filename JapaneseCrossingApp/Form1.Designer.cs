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
			SuspendLayout();
			// 
			// buttonToRight
			// 
			buttonToRight.Location = new Point(12, 570);
			buttonToRight.Name = "buttonToRight";
			buttonToRight.Size = new Size(94, 29);
			buttonToRight.TabIndex = 0;
			buttonToRight.Text = "Туда";
			buttonToRight.UseVisualStyleBackColor = true;
			buttonToRight.Click += ButtonToRight_Click;
			// 
			// buttonToLeft
			// 
			buttonToLeft.Location = new Point(1009, 570);
			buttonToLeft.Name = "buttonToLeft";
			buttonToLeft.Size = new Size(94, 29);
			buttonToLeft.TabIndex = 1;
			buttonToLeft.Text = "Обратно";
			buttonToLeft.UseVisualStyleBackColor = true;
			buttonToLeft.Click += ButtonToLeft_Click;
			// 
			// timer1
			// 
			timer1.Tick += Timer1_Tick;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackgroundImage = Properties.Resources.background1;
			BackgroundImageLayout = ImageLayout.Stretch;
			ClientSize = new Size(1117, 613);
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
		}

		#endregion

		private Button buttonToRight;
        private Button buttonToLeft;
        private ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
    }
}
