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
            this.UseUPnPCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MaxUploadSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.MaxDownloadSpeedTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HalfOpenConnectionsTextBox = new System.Windows.Forms.TextBox();
            this.ListenPortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxConnectionsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SavePathTextBox = new System.Windows.Forms.TextBox();
            this.SavePathButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TorrentsPathButton = new System.Windows.Forms.Button();
            this.TorrentPathTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SettingGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingGroupBox
            // 
            this.SettingGroupBox.Controls.Add(this.UseUPnPCheckBox);
            this.SettingGroupBox.Controls.Add(this.label6);
            this.SettingGroupBox.Controls.Add(this.MaxUploadSpeedTextBox);
            this.SettingGroupBox.Controls.Add(this.label5);
            this.SettingGroupBox.Controls.Add(this.MaxDownloadSpeedTextBox);
            this.SettingGroupBox.Controls.Add(this.label4);
            this.SettingGroupBox.Controls.Add(this.HalfOpenConnectionsTextBox);
            this.SettingGroupBox.Location = new System.Drawing.Point(12, 130);
            this.SettingGroupBox.Name = "SettingGroupBox";
            this.SettingGroupBox.Size = new System.Drawing.Size(253, 141);
            this.SettingGroupBox.TabIndex = 0;
            this.SettingGroupBox.TabStop = false;
            this.SettingGroupBox.Text = "Settings";
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
            this.label6.Location = new System.Drawing.Point(15, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Max upload speed";
            // 
            // MaxUploadSpeedTextBox
            // 
            this.MaxUploadSpeedTextBox.Location = new System.Drawing.Point(156, 68);
            this.MaxUploadSpeedTextBox.Name = "MaxUploadSpeedTextBox";
            this.MaxUploadSpeedTextBox.Size = new System.Drawing.Size(81, 20);
            this.MaxUploadSpeedTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max download speed";
            // 
            // MaxDownloadSpeedTextBox
            // 
            this.MaxDownloadSpeedTextBox.Location = new System.Drawing.Point(156, 94);
            this.MaxDownloadSpeedTextBox.Name = "MaxDownloadSpeedTextBox";
            this.MaxDownloadSpeedTextBox.Size = new System.Drawing.Size(81, 20);
            this.MaxDownloadSpeedTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max half open connections";
            // 
            // HalfOpenConnectionsTextBox
            // 
            this.HalfOpenConnectionsTextBox.Location = new System.Drawing.Point(156, 42);
            this.HalfOpenConnectionsTextBox.Name = "HalfOpenConnectionsTextBox";
            this.HalfOpenConnectionsTextBox.Size = new System.Drawing.Size(81, 20);
            this.HalfOpenConnectionsTextBox.TabIndex = 6;
            // 
            // ListenPortTextBox
            // 
            this.ListenPortTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ListenPortTextBox.Location = new System.Drawing.Point(96, 23);
            this.ListenPortTextBox.Name = "ListenPortTextBox";
            this.ListenPortTextBox.Size = new System.Drawing.Size(81, 20);
            this.ListenPortTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Listen port";
            // 
            // MaxConnectionsTextBox
            // 
            this.MaxConnectionsTextBox.Location = new System.Drawing.Point(96, 49);
            this.MaxConnectionsTextBox.Name = "MaxConnectionsTextBox";
            this.MaxConnectionsTextBox.Size = new System.Drawing.Size(81, 20);
            this.MaxConnectionsTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Max connections";
            // 
            // SavePathTextBox
            // 
            this.SavePathTextBox.Location = new System.Drawing.Point(6, 19);
            this.SavePathTextBox.Name = "SavePathTextBox";
            this.SavePathTextBox.Size = new System.Drawing.Size(355, 20);
            this.SavePathTextBox.TabIndex = 14;
            // 
            // SavePathButton
            // 
            this.SavePathButton.Location = new System.Drawing.Point(367, 19);
            this.SavePathButton.Name = "SavePathButton";
            this.SavePathButton.Size = new System.Drawing.Size(75, 20);
            this.SavePathButton.TabIndex = 15;
            this.SavePathButton.Text = "Browse";
            this.SavePathButton.UseVisualStyleBackColor = true;
            this.SavePathButton.Click += new System.EventHandler(this.SavePathButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ListenPortTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.MaxConnectionsTextBox);
            this.groupBox1.Location = new System.Drawing.Point(271, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 88);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security";
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
            this.TorrentsPathButton.Location = new System.Drawing.Point(368, 19);
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
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(367, 248);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 285);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SettingGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Name = "OptionWindow";
            this.Text = "OptionWindow";
            this.SettingGroupBox.ResumeLayout(false);
            this.SettingGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ListenPortTextBox;
        private System.Windows.Forms.TextBox MaxDownloadSpeedTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HalfOpenConnectionsTextBox;
        private System.Windows.Forms.TextBox MaxConnectionsTextBox;
        private System.Windows.Forms.CheckBox UseUPnPCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MaxUploadSpeedTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SavePathButton;
        private System.Windows.Forms.TextBox SavePathTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button TorrentsPathButton;
        private System.Windows.Forms.TextBox TorrentPathTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}