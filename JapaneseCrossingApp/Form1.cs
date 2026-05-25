namespace JapaneseCrossingApp
{
	public partial class Form1 : Form
	{
		private Game _game = new();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			_game.Draw(e.Graphics);
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			var person = _game.FindPersonAt(e.X, e.Y);

			Cursor = person is null ? Cursors.Arrow : Cursors.Hand;

			if (person is null)
			{
				toolTip1.Hide(this);
				return;
			}

			toolTip1.Show(person.Name, this, new Point(e.X, e.Y));
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (_game.IsAnimationRunning)
			{
				return;
			}

			var person = _game.FindPersonAt(e.X, e.Y);
			if (person is null)
			{
				return;
			}

			try
			{
				if (person.InBoat)
				{
					_game.Disembark(person);
					ShowVictoryMessageIfNeeded();
				}
				else
				{
					_game.Embark(person);
				}

				Invalidate();
			}
			catch (InvalidOperationException ex)
			{
				MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void ButtonToRight_Click(object sender, EventArgs e)
		{
			StartBoatMove(SideKind.Right);
		}

		private void ButtonToLeft_Click(object sender, EventArgs e)
		{
			StartBoatMove(SideKind.Left);
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			try
			{
				_game.AnimationStep();
				timer1.Enabled = _game.IsAnimationRunning;
				Invalidate();
			}
			catch (InvalidOperationException ex)
			{
				timer1.Enabled = false;
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void StartBoatMove(SideKind targetSide)
		{
			try
			{
				AddMoveToHistory(targetSide);
				_game.StartMove(targetSide);
				timer1.Enabled = true;
			}
			catch (InvalidOperationException ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ShowVictoryMessageIfNeeded()
		{
			if (!_game.IsSuccess)
			{
				return;
			}

			MessageBox.Show(
				$"Поздравляем с победой за {_game.MoveCount} ходов",
				"Победа",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information);
		}

		private void ButtonHint_Click(object sender, EventArgs e)
		{
			var form = new HintForm();
			form.ShowDialog();
		}

		private void ButtonRestart_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			_game = new Game();
			Invalidate();
		}

		private void AddMoveToHistory(SideKind targetSide)
		{
			textBoxProcess.AppendText(
				_game.GetCurrentMoveDescription(targetSide) + Environment.NewLine);
		}
	}
}
