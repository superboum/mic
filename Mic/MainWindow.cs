using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		createNodeView();
	}

	protected void EditStudent(object o, Gtk.EditedArgs args)
	{
		
	}

	protected void RenderStudent(Gtk.TreeViewColumn column, Gtk.CellRenderer cell, Gtk.TreeModel model, Gtk.TreeIter iter) 
	{
		String toto = (String) model.GetValue(iter, 0);
		(cell as Gtk.CellRendererText).Text = toto;
	}

	protected void addColumn(String name, TreeCellDataFunc tcdf, EditedHandler eh)
	{
		var renderer = new Gtk.CellRendererText();
		if (eh != null)
		{
			renderer.Editable = true;
			renderer.Edited += eh;
		}

		var column = new Gtk.TreeViewColumn();
		column.Title = name;
		column.PackStart(renderer, true);
		column.Resizable = true;
		column.SetCellDataFunc(renderer, new Gtk.TreeCellDataFunc(tcdf));

		treeviewImported.AppendColumn(column);
	}

	protected void createNodeView()
	{
		addColumn("Elèves", RenderStudent, EditStudent);
		treeviewImported.AppendColumn("Fichier original", new Gtk.CellRendererText(), "text", 1);
		treeviewImported.AppendColumn("Durée", new Gtk.CellRendererText(), "text", 2);
		treeviewImported.AppendColumn("Taille", new Gtk.CellRendererText(), "text", 3);


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
