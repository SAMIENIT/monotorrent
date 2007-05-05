namespace MonoTorrent.GUI.View
{
	partial class MiniWindow
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.MiniListView = new MonoTorrent.GUI.View.Control.ImageListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colProgress = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // MiniListView
            // 
            this.MiniListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MiniListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colProgress});
            this.MiniListView.FullRowSelect = true;
            this.MiniListView.Location = new System.Drawing.Point(0, 0);
            this.MiniListView.Name = "MiniListView";
            this.MiniListView.Scrollable = false;
            this.MiniListView.Size = new System.Drawing.Size(442, 166);
            this.MiniListView.TabIndex = 0;
            this.MiniListView.UseCompatibleStateImageBehavior = false;
            this.MiniListView.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 199;
            // 
            // colProgress
            // 
            this.colProgress.Text = "Progress";
            this.colProgress.Width = 235;
            // 
            // MiniWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(442, 166);
            this.Controls.Add(this.MiniListView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiniWindow";
            this.Opacity = 0.6;
            this.ShowInTaskbar = false;
            this.Text = "MiniWindow";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MiniWindow_FormClosing);
            this.ResumeLayout(false);

		}

		#endregion

        private Control.ImageListView MiniListView;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colProgress;
	}
}