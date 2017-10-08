using System.Linq;
using MicCore;
using Gtk;
using System;

namespace Mic
{
	public partial class ImportWindow : Window
	{

		public USBDrive Drive { get; private set; }
		TreeStore store;

		public ImportWindow(USBDrive drive) : base(WindowType.Toplevel)
		{
			Drive = drive;
 			store = new TreeStore(typeof(AudioFile));
			Build();
			createNodeView();
		}

		protected void RenderSelection(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			var file = model.GetValue(iter, 0) as AudioFile;
			(cell as CellRendererToggle).Active = file.Selected;
		}

		protected void RenderSize(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			var file = model.GetValue(iter, 0) as AudioFile;
			(cell as CellRendererText).Text = file.HumanReadableSize();
		}

		protected void RenderFile(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			AudioFile file = model.GetValue(iter, 0) as AudioFile;
			(cell as CellRendererText).Text = file.File.FullName;
		}

		protected void ToggleSelection(object sender, ToggledArgs args)
		{
			Console.WriteLine("Toggle");
			TreeIter iter;
			if (store.GetIterFromString(out iter, args.Path))
			{
				var file = store.GetValue(iter, 0) as AudioFile;
				file.Selected = !file.Selected;
			}
		}

		protected void AddToggleColumn(string name, TreeCellDataFunc tcdf, ToggledHandler th)
		{
			CellRendererToggle renderer = new CellRendererToggle();
			if (th != null)
			{
				renderer.Toggled += th;
			}
			AddColumn(name, renderer, tcdf);
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

			importView.AppendColumn(column);
		}

		protected void createNodeView()
		{
			AddToggleColumn("Sel.", RenderSelection, ToggleSelection);
			AddTextColumn("Fichier", RenderFile, null);
			AddTextColumn("Taille", RenderSize, null);
			// @TODO Add column length and/or preview
			importView.GetColumn(1).Expand = true;

			Drive.AudioFiles.ToList().ForEach((obj) => store.AppendValues(obj));
			importView.Model = store;
		}
	}
}
