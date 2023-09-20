using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CmdBash
{
	internal static class Program
	{

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
		static void Main()
		{

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Install());
            }
            else if (args.Length > 1)
            {
                string action = args[1];
                string folder = "";
                if (args.Length == 3)
                {
                    folder = args[2];
                }
                if (action == "add")
                {
                    bool sucsess = Path.Install(folder);
                    if (sucsess)
                    {
                        Console.WriteLine(String.Format("Удалось {0}", "установить"));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Не удалось {0}", "установить"));
                    }
                }
                if (action == "remove")
                {
                    bool sucsess = Path.Uninstall(folder);
                    if (sucsess)
                    {
                        Console.WriteLine(String.Format("Удалось {0}", "удалить"));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Не удалось {0}", "удалить"));
                    }
                }

                if (action == "exists")
                {
                    bool sucsess = Path.isInstalled(folder);
                    if (sucsess)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Environment.Exit(404);
                    }
                }
            }
        }

    }
    class Path
    {
        public static string GetMYPath()
        {
            string path = Application.ExecutablePath;
            string directoryName = System.IO.Path.GetDirectoryName(path);

            return directoryName;
        }
        public static bool isInstalled(string myPath = "")
        {
            if (myPath == "")
            {
                myPath = GetMYPath();
            }
            string pathVariable = GetPath();
            if (!pathVariable.Split(';').Contains(myPath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Install(string pathToAdd = "")
        {
            if (isInstalled(pathToAdd))
            {
                return true;
            }
            // Путь, который нужно добавить в переменную среды Path
            if (pathToAdd == "")
            {
                pathToAdd = GetMYPath();
            }

            // Получаем текущее значение переменной среды Path
            string pathVariable = GetPath();

            // Проверяем, не содержит ли переменная среды Path уже добавляемый путь
            if (!pathVariable.Split(';').Contains(pathToAdd))
            {
                // Добавляем путь в переменную среды Path
                string newPathVariable = string.Join(";", pathVariable, pathToAdd);
                SetPath(newPathVariable);
            }
            if (isInstalled())
            {
                return true;
            }
            return false;
        }

        public static bool Uninstall(string pathToRemove = "")
        {
            if (!isInstalled(pathToRemove))
            {
                return true;
            }
            if (pathToRemove == "")
            {
                pathToRemove = GetMYPath();
            }

            string pathVariable = GetPath();
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
            SetPath(newPathVariable);

            if (isInstalled())
            {
                return false;
            }
            return true;
        }

        public static void SetPath(string paths)
        {
            Environment.SetEnvironmentVariable("Path", paths, EnvironmentVariableTarget.User);
        }
        public static string GetPath()
        {
            return Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
        }
    }
}
