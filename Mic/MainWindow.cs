using System;
using System.Linq;
using Gtk;
using MicCore;

namespace Mic
{
	public partial class MainWindow : Window
	{

		TreeStore store;

		public MainWindow() : base(WindowType.Toplevel)
		{
			Build();
			createNodeView();
			Refresh();
		}

		protected void EditStudent(object o, EditedArgs args)
		{

		}

		protected void RenderStudent(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			var a = model.GetValue(iter, 0) as AudioFile;
			if (a != null)
			{
				(cell as CellRendererText).Text = a.AssociatedStudent.Name;
			}
			else 
			{
				var e = model.GetValue(iter, 1) as Exercice;
				(cell as CellRendererText).Text = e.Name;
			}

		}

		protected void RenderFilename(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			var a = model.GetValue(iter, 0) as AudioFile;
			if (a != null)
			{
				(cell as CellRendererText).Text = a.OriginalFileName;
			}
			else
			{
				(cell as CellRendererText).Text = "";

			}
		}

		protected void RenderDate(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			var a = model.GetValue(iter, 0) as AudioFile;
			if (a != null)
			{
				(cell as CellRendererText).Text = a.AssociatedDatetime.ToString();
			}
			else
			{
				(cell as CellRendererText).Text = "";
			}
		}

		protected void RenderSize(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			var a = model.GetValue(iter, 0) as AudioFile;
			if (a != null)
			{
				(cell as CellRendererText).Text = a.HumanReadableSize();
			}
			else {
				(cell as CellRendererText).Text = "";
			}
		}

		protected void AddTextColumn(string name, TreeCellDataFunc tcdf, EditedHandler eh)
		{
			CellRendererText renderer = new CellRendererText();
			if (eh != null)
			{
				renderer.Editable = true;
				renderer.Edited += eh;
			}
			AddColumn(name, renderer, tcdf);
		}

		protected void AddColumn(string name, CellRenderer renderer, TreeCellDataFunc tcdf)
		{
			var column = new TreeViewColumn();
			column.Title = name;
			column.PackStart(renderer, true);
			column.Resizable = true;
			column.SetCellDataFunc(renderer, new TreeCellDataFunc(tcdf));

			treeviewImported.AppendColumn(column);
		}

		protected void createNodeView()
		{
			AddTextColumn("Elèves", RenderStudent, EditStudent);
            AddTextColumn("Nom original", RenderFilename, null);
            AddTextColumn("Date", RenderDate, null);
            AddTextColumn("Taille", RenderSize, null);
			treeviewImported.GetColumn(0).Expand = true;
			treeviewImported.GetColumn(1).Expand = true;
			/*treeviewImported.AppendColumn("Fichier original", new Gtk.CellRendererText(), "text", 1);
			treeviewImported.AppendColumn("Durée", new Gtk.CellRendererText(), "text", 2);
			treeviewImported.AppendColumn("Taille", new Gtk.CellRendererText(), "text", 3);*/


			store = new Gtk.TreeStore(typeof(AudioFile), typeof(Exercice));
			treeviewImported.Model = store;
		}

		public void Refresh()
		{
			store.Clear();
			TreeIter iter;
			Command.Instance.AlreadyImported.Keys.ToList().ForEach(delegate (MicCore.Exercice e) {
			iter = store.AppendValues(null, e);
			Command.Instance.AlreadyImported[e]
				   .ToList()
				   .ForEach((a) => store.AppendValues(iter, a, null));
			});
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
			a.RetVal = true;
		}
	}
}
