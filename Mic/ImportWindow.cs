using System;
namespace Mic
{
	public partial class ImportWindow : Gtk.Window
	{
		public ImportWindow() :
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();
		}
	}
}
