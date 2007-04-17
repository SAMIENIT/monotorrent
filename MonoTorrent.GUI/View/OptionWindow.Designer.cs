namespace MonoTorrent.GUI.View
{
    partial class OptionWindow
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
			this.SettingGroupBox = new System.Windows.Forms.GroupBox();
			this.MaxDownloadSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.MaxUploadSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.HalfOpenConnectionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.UseUPnPCheckBox = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SavePathTextBox = new System.Windows.Forms.TextBox();
			this.SavePathButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.MaxConnectionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.ListenPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.TorrentsPathButton = new System.Windows.Forms.Button();
			this.TorrentPathTextBox = new System.Windows.Forms.TextBox();
			this.SaveButton = new System.Windows.Forms.Button();
			this.QuitButton = new System.Windows.Forms.Button();
			this.SettingGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxDownloadSpeedNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxUploadSpeedNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.HalfOpenConnectionsNumericUpDown)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxConnectionsNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ListenPortNumericUpDown)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// SettingGroupBox
			// 
			this.SettingGroupBox.Controls.Add(this.MaxDownloadSpeedNumericUpDown);
			this.SettingGroupBox.Controls.Add(this.MaxUploadSpeedNumericUpDown);
			this.SettingGroupBox.Controls.Add(this.HalfOpenConnectionsNumericUpDown);
			this.SettingGroupBox.Controls.Add(this.UseUPnPCheckBox);
			this.SettingGroupBox.Controls.Add(this.label6);
			this.SettingGroupBox.Controls.Add(this.label5);
			this.SettingGroupBox.Controls.Add(this.label4);
			this.SettingGroupBox.Location = new System.Drawing.Point(12, 130);
			this.SettingGroupBox.Name = "SettingGroupBox";
			this.SettingGroupBox.Size = new System.Drawing.Size(253, 141);
			this.SettingGroupBox.TabIndex = 0;
			this.SettingGroupBox.TabStop = false;
			this.SettingGroupBox.Text = "Settings";
			// 
			// MaxDownloadSpeedNumericUpDown
			// 
			this.MaxDownloadSpeedNumericUpDown.Location = new System.Drawing.Point(157, 102);
			this.MaxDownloadSpeedNumericUpDown.Name = "MaxDownloadSpeedNumericUpDown";
			this.MaxDownloadSpeedNumericUpDown.Size = new System.Drawing.Size(90, 20);
			this.MaxDownloadSpeedNumericUpDown.TabIndex = 16;
			// 
			// MaxUploadSpeedNumericUpDown
			// 
			this.MaxUploadSpeedNumericUpDown.Location = new System.Drawing.Point(157, 75);
			this.MaxUploadSpeedNumericUpDown.Name = "MaxUploadSpeedNumericUpDown";
			this.MaxUploadSpeedNumericUpDown.Size = new System.Drawing.Size(90, 20);
			this.MaxUploadSpeedNumericUpDown.TabIndex = 15;
			// 
			// HalfOpenConnectionsNumericUpDown
			// 
			this.HalfOpenConnectionsNumericUpDown.Location = new System.Drawing.Point(157, 49);
			this.HalfOpenConnectionsNumericUpDown.Name = "HalfOpenConnectionsNumericUpDown";
			this.HalfOpenConnectionsNumericUpDown.Size = new System.Drawing.Size(90, 20);
			this.HalfOpenConnectionsNumericUpDown.TabIndex = 14;
			// 
			// UseUPnPCheckBox
			// 
			this.UseUPnPCheckBox.AutoSize = true;
			this.UseUPnPCheckBox.Location = new System.Drawing.Point(18, 19);
			this.UseUPnPCheckBox.Name = "UseUPnPCheckBox";
			this.UseUPnPCheckBox.Size = new System.Drawing.Size(74, 17);
			this.UseUPnPCheckBox.TabIndex = 13;
			this.UseUPnPCheckBox.Text = "Use uPnP";
			this.UseUPnPCheckBox.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 77);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Max upload speed :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(114, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Max download speed :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 51);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(141, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Max half open connections :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(62, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Listen port :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Max connections :";
			// 
			// SavePathTextBox
			// 
			this.SavePathTextBox.Location = new System.Drawing.Point(6, 19);
			this.SavePathTextBox.Name = "SavePathTextBox";
			this.SavePathTextBox.Size = new System.Drawing.Size(356, 20);
			this.SavePathTextBox.TabIndex = 14;
			// 
			// SavePathButton
			// 
			this.SavePathButton.Location = new System.Drawing.Point(368, 19);
			this.SavePathButton.Name = "SavePathButton";
			this.SavePathButton.Size = new System.Drawing.Size(74, 20);
			this.SavePathButton.TabIndex = 15;
			this.SavePathButton.Text = "Browse";
			this.SavePathButton.UseVisualStyleBackColor = true;
			this.SavePathButton.Click += new System.EventHandler(this.SavePathButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.MaxConnectionsNumericUpDown);
			this.groupBox1.Controls.Add(this.ListenPortNumericUpDown);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(271, 130);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(189, 88);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Security";
			// 
			// MaxConnectionsNumericUpDown
			// 
			this.MaxConnectionsNumericUpDown.Location = new System.Drawing.Point(108, 49);
			this.MaxConnectionsNumericUpDown.Name = "MaxConnectionsNumericUpDown";
			this.MaxConnectionsNumericUpDown.Size = new System.Drawing.Size(75, 20);
			this.MaxConnectionsNumericUpDown.TabIndex = 9;
			// 
			// ListenPortNumericUpDown
			// 
			this.ListenPortNumericUpDown.Location = new System.Drawing.Point(108, 23);
			this.ListenPortNumericUpDown.Name = "ListenPortNumericUpDown";
			this.ListenPortNumericUpDown.Size = new System.Drawing.Size(75, 20);
			this.ListenPortNumericUpDown.TabIndex = 8;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.SavePathButton);
			this.groupBox2.Controls.Add(this.SavePathTextBox);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(448, 55);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Save path";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.TorrentsPathButton);
			this.groupBox3.Controls.Add(this.TorrentPathTextBox);
			this.groupBox3.Location = new System.Drawing.Point(12, 73);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(448, 51);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Torrents path";
			// 
			// TorrentsPathButton
			// 
			this.TorrentsPathButton.Location = new System.Drawing.Point(368, 18);
			this.TorrentsPathButton.Name = "TorrentsPathButton";
			this.TorrentsPathButton.Size = new System.Drawing.Size(74, 20);
			this.TorrentsPathButton.TabIndex = 1;
			this.TorrentsPathButton.Text = "Browse";
			this.TorrentsPathButton.UseVisualStyleBackColor = true;
			this.TorrentsPathButton.Click += new System.EventHandler(this.TorrentsPathButton_Click);
			// 
			// TorrentPathTextBox
			// 
			this.TorrentPathTextBox.Location = new System.Drawing.Point(7, 19);
			this.TorrentPathTextBox.Name = "TorrentPathTextBox";
			this.TorrentPathTextBox.Size = new System.Drawing.Size(355, 20);
			this.TorrentPathTextBox.TabIndex = 0;
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(286, 248);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(75, 23);
			this.SaveButton.TabIndex = 4;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// QuitButton
			// 
			this.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.QuitButton.Location = new System.Drawing.Point(367, 248);
			this.QuitButton.Name = "QuitButton";
			this.QuitButton.Size = new System.Drawing.Size(75, 23);
			this.QuitButton.TabIndex = 5;
			this.QuitButton.Text = "Cancel";
			this.QuitButton.UseVisualStyleBackColor = true;
			this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// OptionWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.QuitButton;
			this.ClientSize = new System.Drawing.Size(472, 285);
			this.Controls.Add(this.QuitButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.SettingGroupBox);
			this.Controls.Add(this.groupBox2);
			this.Name = "OptionWindow";
			this.ShowInTaskbar = false;
			this.Text = "OptionWindow";
			this.SettingGroupBox.ResumeLayout(false);
			this.SettingGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxDownloadSpeedNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxUploadSpeedNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.HalfOpenConnectionsNumericUpDown)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxConnectionsNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ListenPortNumericUpDown)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox UseUPnPCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SavePathButton;
        private System.Windows.Forms.TextBox SavePathTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button TorrentsPathButton;
        private System.Windows.Forms.TextBox TorrentPathTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.NumericUpDown MaxDownloadSpeedNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxUploadSpeedNumericUpDown;
        private System.Windows.Forms.NumericUpDown HalfOpenConnectionsNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxConnectionsNumericUpDown;
        private System.Windows.Forms.NumericUpDown ListenPortNumericUpDown;
    }
}