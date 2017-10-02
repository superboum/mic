
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FichiersAction;

	private global::Gtk.Action FichierAction;

	private global::Gtk.Action AideAction;

	private global::Gtk.Action addAction;

	private global::Gtk.Action editAction;

	private global::Gtk.ToggleAction helpAction;

	private global::Gtk.RadioAction newAction;

	private global::Gtk.Action openAction;

	private global::Gtk.VBox vboxMain;

	private global::Gtk.Label label2;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TreeView treeviewImported;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FichiersAction = new global::Gtk.Action("FichiersAction", global::Mono.Unix.Catalog.GetString("Fichiers"), null, null);
		this.FichiersAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Fichiers");
		w1.Add(this.FichiersAction, null);
		this.FichierAction = new global::Gtk.Action("FichierAction", global::Mono.Unix.Catalog.GetString("Fichier"), null, null);
		this.FichierAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Fichier");
		w1.Add(this.FichierAction, null);
		this.AideAction = new global::Gtk.Action("AideAction", global::Mono.Unix.Catalog.GetString("Aide"), null, null);
		this.AideAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Aide");
		w1.Add(this.AideAction, null);
		this.addAction = new global::Gtk.Action("addAction", null, null, "gtk-add");
		w1.Add(this.addAction, null);
		this.editAction = new global::Gtk.Action("editAction", null, null, "gtk-edit");
		this.editAction.Sensitive = false;
		w1.Add(this.editAction, null);
		this.helpAction = new global::Gtk.ToggleAction("helpAction", null, null, "gtk-help");
		w1.Add(this.helpAction, null);
		this.newAction = new global::Gtk.RadioAction("newAction", null, null, "gtk-new", 0);
		this.newAction.Group = new global::GLib.SList(global::System.IntPtr.Zero);
		w1.Add(this.newAction, null);
		this.openAction = new global::Gtk.Action("openAction", null, null, "gtk-open");
		w1.Add(this.openAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("Mic");
		this.Icon = global::Stetic.IconLoader.LoadIcon(this, "gtk-media-record", global::Gtk.IconSize.Menu);
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vboxMain = new global::Gtk.VBox();
		this.vboxMain.Name = "vboxMain";
		this.vboxMain.Spacing = 6;
		this.vboxMain.BorderWidth = ((uint)(20));
		// Container child vboxMain.Gtk.Box+BoxChild
		this.label2 = new global::Gtk.Label();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("En attente de la connexion d\'un microphone...");
		this.vboxMain.Add(this.label2);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.label2]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vboxMain.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.treeviewImported = new global::Gtk.TreeView();
		this.treeviewImported.CanFocus = true;
		this.treeviewImported.Name = "treeviewImported";
		this.GtkScrolledWindow.Add(this.treeviewImported);
		this.vboxMain.Add(this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vboxMain[this.GtkScrolledWindow]));
		w4.Position = 1;
		this.Add(this.vboxMain);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 632;
		this.DefaultHeight = 321;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
	}
}
