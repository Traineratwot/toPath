using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CmdBash
{


	public partial class Install : Form
	{
		public Install()
		{
			InitializeComponent();
		}

		private void Install_Load(object sender, EventArgs e)
		{
			myPath.Text = Path.GetMYPath();
			InstallCheckBox.Visible = false;
			InstallCheckBox.Checked = Path.isInstalled();
			InstallCheckBox.Visible = true;
			Swich_checBox();
		}

		void Swich_checBox() {
			
			if (InstallCheckBox.Checked)
			{
				InstallCheckBox.Text = "Удалить";
			}
			else
			{
				InstallCheckBox.Text = "Установить";
			}
		}

		private void Install_checkBox(object sender, EventArgs e)
		{
			if (!InstallCheckBox.Visible) {
				return;
			}
			bool isChecked = InstallCheckBox.Checked;
			bool sucsess;
			if (isChecked)
			{
				sucsess= Path.Install();
			}
			else {
				sucsess = Path.Uninstall();
			}

			if (sucsess)
			{
				Log(String.Format("Удалось {0}", isChecked ? "установить" : "удалить"));
			}
			else {
				Log(String.Format("Не удалось {0}", isChecked ? "установить" : "удалить"));
			}
			Swich_checBox();
		}

		public void Log(string text ) {
			Logger.Text = text;
			Console.WriteLine(text);
		}
	}
}
