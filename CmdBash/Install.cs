﻿using System;
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
			myPath.Text = MyProgram.getPath();
			InstallCheckBox.Visible = false;
			InstallCheckBox.Checked = MyProgram.isInstalled();
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
				sucsess= MyProgram.Install();
			}
			else {
				sucsess = MyProgram.Uninstall();
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

	class MyProgram
	{
		public static string getPath() {
			string path =Application.ExecutablePath;
			string directoryName = Path.GetDirectoryName(path);

			return directoryName;
		}
		public static bool isInstalled() {
			string myPath = getPath();
			string pathVariable = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
			if (!pathVariable.Split(';').Contains(myPath))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static bool Install()
		{
			if (isInstalled())
			{
				return true;
			}
			// Путь, который нужно добавить в переменную среды Path
			string pathToAdd = getPath();

			// Получаем текущее значение переменной среды Path
			string pathVariable = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);

			// Проверяем, не содержит ли переменная среды Path уже добавляемый путь
			if (!pathVariable.Split(';').Contains(pathToAdd))
			{
				// Добавляем путь в переменную среды Path
				string newPathVariable = string.Join(";", pathVariable, pathToAdd);
				Environment.SetEnvironmentVariable("Path", newPathVariable, EnvironmentVariableTarget.User);
			}
			if (isInstalled()) {
				return true;
			}
			return false;
		}

		public static bool Uninstall()
		{
			if (!isInstalled())
			{
				return true;
			}
			string pathToRemove = getPath(); // путь, который нужно удалить
			string pathVariable = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
			string[] paths = pathVariable.Split(';'); // разделяем строку на массив путей

			List<string> newPaths = new List<string>(); // создаем новый список путей

			foreach (string path in paths)
			{
				if (!path.Equals(pathToRemove, StringComparison.OrdinalIgnoreCase)) // если путь не совпадает с удаляемым путем, добавляем его в новый список
				{
					newPaths.Add(path);
				}
			}

			string newPathVariable = string.Join(";", newPaths); // объединяем новый список путей в строку с разделителем ";"

			Environment.SetEnvironmentVariable("Path", newPathVariable, EnvironmentVariableTarget.User);

			if (isInstalled())
			{
				return false;
			}
			return true;
		}
	}

}