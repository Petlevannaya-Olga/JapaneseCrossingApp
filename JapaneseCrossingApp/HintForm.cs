using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JapaneseCrossingApp
{
	public partial class HintForm : Form
	{
		public HintForm()
		{
			InitializeComponent();
		}

		private void ButtonClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void HintForm_Load(object sender, EventArgs e)
		{
			textBox.Text += "1. Полицейский + Преступник →\r\n";
			textBox.Text += "2. Полицейский ←\r\n";
			textBox.Text += "3. Полицейский + Сын 1 →\r\n";
			textBox.Text += "4. Полицейский + Преступник ←\r\n";
			textBox.Text += "5. Отец + Сын 2 →\r\n";
			textBox.Text += "6. Отец ←\r\n";
			textBox.Text += "7. Отец + Мать →\r\n";
			textBox.Text += "8. Мать ←\r\n";
			textBox.Text += "9. Полицейский + Преступник →\r\n";
			textBox.Text += "10. Отец ←\r\n";
			textBox.Text += "11. Отец + Мать →\r\n";
			textBox.Text += "12. Мать ←\r\n";
			textBox.Text += "13. Мать + Дочь 1 →\r\n";
			textBox.Text += "14. Полицейский + Преступник ←\r\n";
			textBox.Text += "15. Полицейский + Дочь 2 →\r\n";
			textBox.Text += "16. Полицейский ←\r\n";
			textBox.Text += "17. Полицейский + Преступник →";

			textBox.TabStop = false;
		}
	}
}
