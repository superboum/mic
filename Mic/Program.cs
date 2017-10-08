using Gtk;

namespace Mic
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();
			Gtk.Settings.Default.SetLongProperty ("gtk-button-images", 1, "");
			MainWindow win = new MainWindow();
			win.Show();

			var miw = new ManageImportWindow();

			Application.Run();
		}
	}
}
