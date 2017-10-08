
// This file has been generated by the GUI designer. Do not modify.
namespace Mic
{
	public partial class ImportWindow
	{
		private global::Gtk.VBox vbox4;

		private global::Gtk.ScrolledWindow GtkScrolledWindow;

		private global::Gtk.NodeView importView;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Button clearMicButton;

		private global::Gtk.Button buttonImport;

		private global::Gtk.ComboBoxEntry comboChooseStudent;

		private global::Gtk.ComboBoxEntry comboChooseExercice;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget Mic.ImportWindow
			this.Name = "Mic.ImportWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("Mic - Importer des fichiers depuis le microphone");
			this.Icon = global::Stetic.IconLoader.LoadIcon(this, "gtk-media-record", global::Gtk.IconSize.Menu);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(20));
			// Container child Mic.ImportWindow.Gtk.Container+ContainerChild
			this.vbox4 = new global::Gtk.VBox();
			this.vbox4.Name = "vbox4";
			this.vbox4.Spacing = 6;
			// Container child vbox4.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.importView = new global::Gtk.NodeView();
			this.importView.CanFocus = true;
			this.importView.Name = "importView";
			this.GtkScrolledWindow.Add(this.importView);
			this.vbox4.Add(this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox4.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.clearMicButton = new global::Gtk.Button();
			this.clearMicButton.CanFocus = true;
			this.clearMicButton.Name = "clearMicButton";
			this.clearMicButton.UseUnderline = true;
			this.clearMicButton.Label = global::Mono.Unix.Catalog.GetString("Vider le micro");
			this.hbox2.Add(this.clearMicButton);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.clearMicButton]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonImport = new global::Gtk.Button();
			this.buttonImport.Sensitive = false;
			this.buttonImport.CanFocus = true;
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.UseUnderline = true;
			this.buttonImport.Label = global::Mono.Unix.Catalog.GetString("Importer");
			this.hbox2.Add(this.buttonImport);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.buttonImport]));
			w4.PackType = ((global::Gtk.PackType)(1));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.comboChooseStudent = global::Gtk.ComboBoxEntry.NewText();
			this.comboChooseStudent.AppendText(global::Mono.Unix.Catalog.GetString("Nom de l\'élève"));
			this.comboChooseStudent.CanDefault = true;
			this.comboChooseStudent.Name = "comboChooseStudent";
			this.comboChooseStudent.Active = 0;
			this.hbox2.Add(this.comboChooseStudent);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.comboChooseStudent]));
			w5.PackType = ((global::Gtk.PackType)(1));
			w5.Position = 2;
			w5.Expand = false;
			w5.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.comboChooseExercice = global::Gtk.ComboBoxEntry.NewText();
			this.comboChooseExercice.AppendText(global::Mono.Unix.Catalog.GetString("Nom de l\'exercice"));
			this.comboChooseExercice.Name = "comboChooseExercice";
			this.comboChooseExercice.Active = 0;
			this.hbox2.Add(this.comboChooseExercice);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.comboChooseExercice]));
			w6.PackType = ((global::Gtk.PackType)(1));
			w6.Position = 3;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox4.Add(this.hbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox4[this.hbox2]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.Add(this.vbox4);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 571;
			this.DefaultHeight = 328;
			this.comboChooseStudent.HasDefault = true;
			this.Show();
		}
	}
}
