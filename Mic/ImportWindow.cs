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
		const string COMBO_STUDENT = "Nom de l'élève";
		const string COMBO_EXERCICE = "Nom de l'exercice";

		public ImportWindow(USBDrive drive) : base(WindowType.Toplevel)
		{
			Drive = drive;
 			store = new TreeStore(typeof(AudioFile));

			Build();
			CreateNodeView();
			CreateCompletionEntry();
		}

		protected void CreateCompletionEntry()
		{
			ListStore studentsStore = new ListStore(typeof(string));
			Program.Com.Students.ToList().ForEach((Student s) => studentsStore.AppendValues(s.Name));

			entryStudent.Completion = new EntryCompletion();
			entryStudent.Completion.Model = studentsStore;
			entryStudent.Completion.TextColumn = 0;

			ListStore exercicesStore = new ListStore(typeof(string));
			Program.Com.Exercices.ToList().ForEach((Exercice e) => exercicesStore.AppendValues(e.Name));

			entryExercice.Completion = new EntryCompletion();
			entryExercice.Completion.Model = exercicesStore;
			entryExercice.Completion.TextColumn = 0;
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
			//Console.WriteLine("Toggle");
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
				renderer.Toggled += CheckImport; // @TODO might need a refactor
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

		protected void PopulateStore()
		{
			store.Clear();
			Drive.AudioFiles.ToList().ForEach((obj) => store.AppendValues(obj));
		}

		protected void CreateNodeView()
		{
			AddToggleColumn("Sel.", RenderSelection, ToggleSelection);
			AddTextColumn("Fichier", RenderFile, null);
			AddTextColumn("Taille", RenderSize, null);
			// @TODO Add column length and/or preview
			importView.GetColumn(1).Expand = true;
			importView.Model = store;
			PopulateStore();
		}

		protected void FocusInStudent(object o, FocusInEventArgs args)
		{
			var entry = o as Entry;
			if (entry.Text == COMBO_STUDENT)
				entry.Text = "";
		}

		protected void FocusOutStudent(object o, FocusOutEventArgs args)
		{
			var entry = o as Entry;
			if (entry.Text == "")
				entry.Text = COMBO_STUDENT;
		}

		protected void FocusInExercice(object o, FocusInEventArgs args)
		{
			var entry = o as Entry;
			if (entry.Text == COMBO_EXERCICE)
				entry.Text = "";
		}

		protected void FocusOutExercice(object o, FocusOutEventArgs args)
		{
			var entry = o as Entry;
			if (entry.Text == "")
				entry.Text = COMBO_EXERCICE;
		}

		protected void CheckImport(object sender, EventArgs e)
		{
			bool canImport = 
				entryStudent.Text != "" && entryStudent.Text != COMBO_STUDENT &&
				entryExercice.Text != "" && entryExercice.Text != COMBO_EXERCICE &&
				Drive.AudioFiles.Any((AudioFile a) => a.Selected);

			buttonImport.Sensitive = canImport;
		}

		protected void DoImport(object sender, EventArgs e)
		{
			Program.Com.Import(entryStudent.Text, entryExercice.Text, Drive);
			PopulateStore();
		}
	}
}
