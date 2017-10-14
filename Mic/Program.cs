using System;
using Gtk;
using MicCore;

namespace Mic
{
	class Program
	{

		public static MainWindow MainWin { get; private set; }

		public static void Main(string[] args)
		{
			Application.Init();
			Gtk.Settings.Default.SetLongProperty ("gtk-button-images", 1, "");
			Gtk.Settings.Default.ThemeName = "MS-Windows";
			MainWin = new MainWindow();
			MainWin.Show();
			var miw = new ManageImportWindow();

			Application.Run();
		}
	}
}
