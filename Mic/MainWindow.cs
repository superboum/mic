using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		this.exercicesListView.HeadersVisible = true;
		this.exercicesListView.AppendColumn("Nom de l'exercice", new Gtk.CellRendererText(), "text", 0);
		this.exercicesListView.AppendColumn("Nombre d'élèves", new Gtk.CellRendererText(), "text", 1);
        this.exercicesListView.AppendColumn("Nombre de pistes", new Gtk.CellRendererText(), "text", 2);
		this.exercicesListView.NodeStore = new Gtk.NodeStore(typeof(Mic.ExerciceNode));
		this.exercicesListView.NodeStore.AddNode(new Mic.ExerciceNode("Exercice 1", 12, 15));
        this.exercicesListView.NodeStore.AddNode(new Mic.ExerciceNode("Bidon de fuel", 42, 66));
        this.exercicesListView.NodeStore.AddNode(new Mic.ExerciceNode("Schloss", 1, 0));
		this.exercicesListView.ShowAll();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}
}
