
// This file has been generated by the GUI designer. Do not modify.
namespace TheElitePatchBeta
{
	public partial class Home
	{
		private global::Gtk.Notebook notebook1;
		private global::Gtk.Fixed fixed4;
		private global::Gtk.Label label4;
		private global::Gtk.Label label1;
		private global::Gtk.Fixed fixed1;
		private global::Gtk.Button button3;
		private global::Gtk.Label label2;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView textview3;
		private global::Gtk.Label label3;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget TheElitePatchBeta.Home
			this.Name = "TheElitePatchBeta.Home";
			this.Title = global::Mono.Unix.Catalog.GetString ("Home");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child TheElitePatchBeta.Home.Gtk.Container+ContainerChild
			this.notebook1 = new global::Gtk.Notebook ();
			this.notebook1.CanFocus = true;
			this.notebook1.Name = "notebook1";
			this.notebook1.CurrentPage = 1;
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.fixed4 = new global::Gtk.Fixed ();
			this.fixed4.Name = "fixed4";
			this.fixed4.HasWindow = false;
			// Container child fixed4.Gtk.Fixed+FixedChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("label4");
			this.fixed4.Add (this.label4);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed4 [this.label4]));
			w1.X = 41;
			w1.Y = 86;
			this.notebook1.Add (this.fixed4);
			// Notebook tab
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Home");
			this.notebook1.SetTabLabel (this.fixed4, this.label1);
			this.label1.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.fixed1 = new global::Gtk.Fixed ();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.button3 = new global::Gtk.Button ();
			this.button3.CanFocus = true;
			this.button3.Name = "button3";
			this.button3.UseUnderline = true;
			this.button3.Label = global::Mono.Unix.Catalog.GetString ("Patch \"The Pirate Bay\"");
			this.fixed1.Add (this.button3);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1 [this.button3]));
			w3.X = 6;
			w3.Y = 8;
			this.notebook1.Add (this.fixed1);
			global::Gtk.Notebook.NotebookChild w4 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.fixed1]));
			w4.Position = 1;
			// Notebook tab
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Patcher");
			this.notebook1.SetTabLabel (this.fixed1, this.label2);
			this.label2.ShowAll ();
			// Container child notebook1.Gtk.Notebook+NotebookChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.textview3 = new global::Gtk.TextView ();
			this.textview3.CanFocus = true;
			this.textview3.Name = "textview3";
			this.GtkScrolledWindow.Add (this.textview3);
			this.notebook1.Add (this.GtkScrolledWindow);
			global::Gtk.Notebook.NotebookChild w6 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.GtkScrolledWindow]));
			w6.Position = 2;
			// Notebook tab
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Contents of Hosts File");
			this.notebook1.SetTabLabel (this.GtkScrolledWindow, this.label3);
			this.label3.ShowAll ();
			this.Add (this.notebook1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 795;
			this.DefaultHeight = 498;
			this.Show ();
			this.button3.Clicked += new global::System.EventHandler (this.OnButton3Clicked);
		}
	}
}