using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		createNodeView();
	}

	protected void editStudent(object o, Gtk.EditedArgs args)
	{
		
	}

	protected void createNodeView()
	{
		var renderer = new Gtk.CellRendererText();
		renderer.Editable = true;
		renderer.Edited += editStudent;

		treeviewImported.AppendColumn("Elève", renderer, "text", 0);
		treeviewImported.AppendColumn("Fichier original", new Gtk.CellRendererText(), "text", 1);
		treeviewImported.AppendColumn("Durée", new Gtk.CellRendererText(), "text", 2);
		treeviewImported.AppendColumn("Taille", new Gtk.CellRendererText(), "text", 3);

		foreach (var col in treeviewImported.Columns)
		{
			col.Expand = true;
			col.Resizable = true;
		}

		Gtk.TreeStore store = new Gtk.TreeStore(typeof(string), typeof(string), typeof(string), typeof(string));
		Gtk.TreeIter iter = store.AppendValues("Exercice 1");
		store.AppendValues(iter, "Toto", "VOICE.MP3", "1:20", "12Mo");

		iter = store.AppendValues("Exercice 2");
		store.AppendValues(iter, "Toto", "VOICE.MP3", "2:40", "12Mo");

		treeviewImported.Model = store;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
