using System;
namespace Mic
{
	public partial class ImportWindow : Gtk.Window
	{
		public ImportWindow() :
				base(Gtk.WindowType.Toplevel)
		{
			Build();
			createNodeView();
		}

		protected void createNodeView()
		{
			importView.AppendColumn("Sel.", new Gtk.CellRendererToggle(), 0);
			importView.AppendColumn("Fichier", new Gtk.CellRendererText(), "text", 1);
			importView.AppendColumn("Durée", new Gtk.CellRendererText(), "text", 2);
			importView.AppendColumn("Taille", new Gtk.CellRendererText(), "text", 3);
			importView.GetColumn(1).Expand = true;

			Gtk.TreeStore store = new Gtk.TreeStore(typeof(Boolean), typeof(string), typeof(string), typeof(string));
			store.AppendValues(true, "VOICE000.MP3", "1:30.251", "12Mo");
			importView.Model = store;
		}
	}
}
