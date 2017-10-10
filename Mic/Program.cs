using Gtk;
using MicCore;

namespace Mic
{
	class Program
	{
		public static Command Com { get; private set; }

		public static void Main(string[] args)
		{
			Application.Init();
			Gtk.Settings.Default.SetLongProperty ("gtk-button-images", 1, "");
			MainWindow win = new MainWindow();
			win.Show();
			var miw = new ManageImportWindow();
			Program.Com = new Command();

			Application.Run();
		}
	}
}
