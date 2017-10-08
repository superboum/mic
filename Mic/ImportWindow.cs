using System.Linq;
using MicCore;
using Gtk;

namespace Mic
{
	public partial class ImportWindow : Window
	{

		public USBDrive Drive { get; private set; }

		public ImportWindow(USBDrive drive) :
				base(WindowType.Toplevel)
		{
			Drive = drive;
			Build();
			createNodeView();
		}

		protected void RenderSize(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			AudioFile file = model.GetValue(iter, 0) as AudioFile;
			(cell as CellRendererText).Text = file.HumanReadableSize();
		}

		protected void RenderFile(TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			AudioFile file = model.GetValue(iter, 0) as AudioFile;
			(cell as CellRendererText).Text = file.File.FullName;
		}

		protected void addColumn(string name, TreeCellDataFunc tcdf, EditedHandler eh)
		{
			var renderer = new CellRendererText();
			if (eh != null)
			{
				renderer.Editable = true;
				renderer.Edited += eh;
			}

			var column = new TreeViewColumn();
			column.Title = name;
			column.PackStart(renderer, true);
			column.Resizable = true;
			column.SetCellDataFunc(renderer, new TreeCellDataFunc(tcdf));

			importView.AppendColumn(column);
		}

		protected void createNodeView()
		{
			importView.AppendColumn("Sel.", new Gtk.CellRendererToggle(), 0);
			addColumn("Fichier", RenderFile, null);
			addColumn("Taille", RenderSize, null);
			importView.GetColumn(1).Expand = true;

			TreeStore store = new Gtk.TreeStore(typeof(AudioFile));
			Drive.AudioFiles.ToList().ForEach((obj) => store.AppendValues(obj));
			importView.Model = store;
		}
	}
}
