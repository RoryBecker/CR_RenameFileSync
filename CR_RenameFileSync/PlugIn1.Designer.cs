namespace CR_RenameFileSync
{
	partial class PlugIn1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public PlugIn1()
		{
			/// <summary>
			/// Required for Windows.Forms Class Composition Designer support
			/// </summary>
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			((System.ComponentModel.ISupportInitialize)(this.Images16x16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			this.LinkedIdentifierActivated += new DevExpress.CodeRush.Core.LinkedIdentifierEventHandler(this.PlugIn1_LinkedIdentifierActivated);
			this.LinkedIdentifierDeactivated += new DevExpress.CodeRush.Core.LinkedIdentifierEventHandler(this.PlugIn1_LinkedIdentifierDeactivated);
			((System.ComponentModel.ISupportInitialize)(this.Images16x16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion
	}
}