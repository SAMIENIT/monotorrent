namespace MonoTorrent.GUI.View
{
    partial class TorrentSettingWindow
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
            this.FastResumeCheckBox = new System.Windows.Forms.CheckBox();
            this.MaxConnectionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.MaxDownloadSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxUploadSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UploadSlotsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.SavePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.QuitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectionsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDownloadSpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUploadSpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UploadSlotsNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // FastResumeCheckBox
            // 
            this.FastResumeCheckBox.AutoSize = true;
            this.FastResumeCheckBox.Location = new System.Drawing.Point(15, 102);
            this.FastResumeCheckBox.Name = "FastResumeCheckBox";
            this.FastResumeCheckBox.Size = new System.Drawing.Size(124, 17);
            this.FastResumeCheckBox.TabIndex = 0;
            this.FastResumeCheckBox.Text = "Fast resume enabled";
            this.FastResumeCheckBox.UseVisualStyleBackColor = true;
            // 
            // MaxConnectionsNumericUpDown
            // 
            this.MaxConnectionsNumericUpDown.Location = new System.Drawing.Point(142, 8);
            this.MaxConnectionsNumericUpDown.Name = "MaxConnectionsNumericUpDown";
            this.MaxConnectionsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.MaxConnectionsNumericUpDown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Max connections :";
            // 
            // MaxDownloadSpeedNumericUpDown
            // 
            this.MaxDownloadSpeedNumericUpDown.Location = new System.Drawing.Point(142, 35);
            this.MaxDownloadSpeedNumericUpDown.Name = "MaxDownloadSpeedNumericUpDown";
            this.MaxDownloadSpeedNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.MaxDownloadSpeedNumericUpDown.TabIndex = 3;
            // 
            // MaxUploadSpeedNumericUpDown
            // 
            this.MaxUploadSpeedNumericUpDown.Location = new System.Drawing.Point(414, 8);
            this.MaxUploadSpeedNumericUpDown.Name = "MaxUploadSpeedNumericUpDown";
            this.MaxUploadSpeedNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.MaxUploadSpeedNumericUpDown.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max download speed :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max upload speed :";
            // 
            // UploadSlotsNumericUpDown
            // 
            this.UploadSlotsNumericUpDown.Location = new System.Drawing.Point(414, 35);
            this.UploadSlotsNumericUpDown.Name = "UploadSlotsNumericUpDown";
            this.UploadSlotsNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.UploadSlotsNumericUpDown.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(284, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Upload slots :";
            // 
            // SavePathTextBox
            // 
            this.SavePathTextBox.Location = new System.Drawing.Point(142, 64);
            this.SavePathTextBox.Name = "SavePathTextBox";
            this.SavePathTextBox.Size = new System.Drawing.Size(311, 20);
            this.SavePathTextBox.TabIndex = 9;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(459, 61);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 10;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Save path :";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(378, 102);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitButton.Location = new System.Drawing.Point(459, 102);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 13;
            this.QuitButton.Text = "Cancel";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // TorrentSettingWindow
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.QuitButton;
            this.ClientSize = new System.Drawing.Size(543, 132);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.SavePathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UploadSlotsNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MaxUploadSpeedNumericUpDown);
            this.Controls.Add(this.MaxDownloadSpeedNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MaxConnectionsNumericUpDown);
            this.Controls.Add(this.FastResumeCheckBox);
            this.Name = "TorrentSettingWindow";
            this.Text = "Torrent Setting";
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectionsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDownloadSpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUploadSpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UploadSlotsNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox FastResumeCheckBox;
        private System.Windows.Forms.NumericUpDown MaxConnectionsNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown MaxDownloadSpeedNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxUploadSpeedNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UploadSlotsNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SavePathTextBox;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button QuitButton;
    }
}