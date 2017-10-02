using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		createNodeView();
	}

	protected void createNodeView()
	{
		treeviewImported.AppendColumn("Elève", new Gtk.CellRendererText(), "text", 0);
		treeviewImported.AppendColumn("Fichier original", new Gtk.CellRendererText(), "text", 1);
		treeviewImported.AppendColumn("Taille", new Gtk.CellRendererText(), "text", 2);
		foreach (var col in treeviewImported.Columns)
		{
			col.Expand = true;
			col.Resizable = true;
		}

		Gtk.TreeStore store = new Gtk.TreeStore(typeof(string), typeof(string), typeof(string));
		Gtk.TreeIter iter = store.AppendValues("Exercice 1");
		store.AppendValues(iter, "Toto", "VOICE.MP3", "12Mo");

		iter = store.AppendValues("Exercice 2");
		store.AppendValues(iter, "Toto", "VOICE.MP3", "12Mo");

		treeviewImported.Model = store;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
