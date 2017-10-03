using System;
using Gtk;
using MicCore;

namespace Mic
{
	class MainClass
	{
		static void HandleDriveChange(object sender, EventArgs e)
		{
			Gtk.Application.Invoke(delegate
			{
				ImportWindow iw = new ImportWindow();
				iw.Show();
			});
		}

		public static void Main(string[] args)
		{
			Application.Init();
			Gtk.Settings.Default.SetLongProperty ("gtk-button-images", 1, "");
			MainWindow win = new MainWindow();
			win.Show();

			var monitor = new MonitorUSBDrives();
			monitor.DriveChange += HandleDriveChange;

			Application.Run();
		}
	}
}
