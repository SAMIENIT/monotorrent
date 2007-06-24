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
            this.OptionsTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTabPage = new System.Windows.Forms.TabPage();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SavePathButton = new System.Windows.Forms.Button();
            this.SavePathTextBox = new System.Windows.Forms.TextBox();
            this.SettingGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AssociateButton = new System.Windows.Forms.Button();
            this.MaxDownloadSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MaxUploadSpeedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.HalfOpenConnectionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.UseUPnPCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TorrentsPathButton = new System.Windows.Forms.Button();
            this.TorrentPathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MaxConnectionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ListenPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AppearanceTabPage = new System.Windows.Forms.TabPage();
            this.QuitButtonApp = new System.Windows.Forms.Button();
            this.SaveButtonApp = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.picExample = new System.Windows.Forms.PictureBox();
            this.lstButtons = new System.Windows.Forms.ListBox();
            this.OptionsTabControl.SuspendLayout();
            this.GeneralTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SettingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDownloadSpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUploadSpeedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfOpenConnectionsNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectionsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListenPortNumericUpDown)).BeginInit();
            this.AppearanceTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExample)).BeginInit();
            this.SuspendLayout();
            // 
            // OptionsTabControl
            // 
            this.OptionsTabControl.Controls.Add(this.GeneralTabPage);
            this.OptionsTabControl.Controls.Add(this.AppearanceTabPage);
            this.OptionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.OptionsTabControl.Name = "OptionsTabControl";
            this.OptionsTabControl.SelectedIndex = 0;
            this.OptionsTabControl.Size = new System.Drawing.Size(469, 283);
            this.OptionsTabControl.TabIndex = 6;
            // 
            // GeneralTabPage
            // 
            this.GeneralTabPage.Controls.Add(this.QuitButton);
            this.GeneralTabPage.Controls.Add(this.SaveButton);
            this.GeneralTabPage.Controls.Add(this.groupBox2);
            this.GeneralTabPage.Controls.Add(this.SettingGroupBox);
            this.GeneralTabPage.Controls.Add(this.groupBox3);
            this.GeneralTabPage.Controls.Add(this.groupBox1);
            this.GeneralTabPage.Location = new System.Drawing.Point(4, 22);
            this.GeneralTabPage.Name = "GeneralTabPage";
            this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTabPage.Size = new System.Drawing.Size(461, 257);
            this.GeneralTabPage.TabIndex = 0;
            this.GeneralTabPage.Text = "General";
            this.GeneralTabPage.UseVisualStyleBackColor = true;
            // 
            // QuitButton
            // 
            this.QuitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitButton.Location = new System.Drawing.Point(379, 227);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(75, 23);
            this.QuitButton.TabIndex = 15;
            this.QuitButton.Text = "Cancel";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(298, 227);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 14;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SavePathButton);
            this.groupBox2.Controls.Add(this.SavePathTextBox);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 55);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save path";
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
            // SavePathTextBox
            // 
            this.SavePathTextBox.Location = new System.Drawing.Point(6, 19);
            this.SavePathTextBox.Name = "SavePathTextBox";
            this.SavePathTextBox.Size = new System.Drawing.Size(356, 20);
            this.SavePathTextBox.TabIndex = 14;
            // 
            // SettingGroupBox
            // 
            this.SettingGroupBox.Controls.Add(this.label1);
            this.SettingGroupBox.Controls.Add(this.AssociateButton);
            this.SettingGroupBox.Controls.Add(this.MaxDownloadSpeedNumericUpDown);
            this.SettingGroupBox.Controls.Add(this.MaxUploadSpeedNumericUpDown);
            this.SettingGroupBox.Controls.Add(this.HalfOpenConnectionsNumericUpDown);
            this.SettingGroupBox.Controls.Add(this.UseUPnPCheckBox);
            this.SettingGroupBox.Controls.Add(this.label6);
            this.SettingGroupBox.Controls.Add(this.label5);
            this.SettingGroupBox.Controls.Add(this.label4);
            this.SettingGroupBox.Location = new System.Drawing.Point(6, 124);
            this.SettingGroupBox.Name = "SettingGroupBox";
            this.SettingGroupBox.Size = new System.Drawing.Size(234, 126);
            this.SettingGroupBox.TabIndex = 6;
            this.SettingGroupBox.TabStop = false;
            this.SettingGroupBox.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Associate torrent files :";
            this.label1.Visible = false;
            // 
            // AssociateButton
            // 
            this.AssociateButton.Location = new System.Drawing.Point(148, 117);
            this.AssociateButton.Name = "AssociateButton";
            this.AssociateButton.Size = new System.Drawing.Size(75, 23);
            this.AssociateButton.TabIndex = 17;
            this.AssociateButton.Text = "Associate";
            this.AssociateButton.UseVisualStyleBackColor = true;
            this.AssociateButton.Visible = false;
            this.AssociateButton.Click += new System.EventHandler(this.AssociateButton_Click);
            // 
            // MaxDownloadSpeedNumericUpDown
            // 
            this.MaxDownloadSpeedNumericUpDown.Location = new System.Drawing.Point(148, 91);
            this.MaxDownloadSpeedNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MaxDownloadSpeedNumericUpDown.Name = "MaxDownloadSpeedNumericUpDown";
            this.MaxDownloadSpeedNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.MaxDownloadSpeedNumericUpDown.TabIndex = 16;
            // 
            // MaxUploadSpeedNumericUpDown
            // 
            this.MaxUploadSpeedNumericUpDown.Location = new System.Drawing.Point(148, 64);
            this.MaxUploadSpeedNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MaxUploadSpeedNumericUpDown.Name = "MaxUploadSpeedNumericUpDown";
            this.MaxUploadSpeedNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.MaxUploadSpeedNumericUpDown.TabIndex = 15;
            // 
            // HalfOpenConnectionsNumericUpDown
            // 
            this.HalfOpenConnectionsNumericUpDown.Location = new System.Drawing.Point(148, 38);
            this.HalfOpenConnectionsNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.HalfOpenConnectionsNumericUpDown.Name = "HalfOpenConnectionsNumericUpDown";
            this.HalfOpenConnectionsNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.HalfOpenConnectionsNumericUpDown.TabIndex = 14;
            // 
            // UseUPnPCheckBox
            // 
            this.UseUPnPCheckBox.AutoSize = true;
            this.UseUPnPCheckBox.Location = new System.Drawing.Point(7, 19);
            this.UseUPnPCheckBox.Name = "UseUPnPCheckBox";
            this.UseUPnPCheckBox.Size = new System.Drawing.Size(74, 17);
            this.UseUPnPCheckBox.TabIndex = 13;
            this.UseUPnPCheckBox.Text = "Use uPnP";
            this.UseUPnPCheckBox.UseVisualStyleBackColor = true;
            this.UseUPnPCheckBox.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Max upload speed :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max download speed :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max half open connections :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TorrentsPathButton);
            this.groupBox3.Controls.Add(this.TorrentPathTextBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 51);
            this.groupBox3.TabIndex = 9;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MaxConnectionsNumericUpDown);
            this.groupBox1.Controls.Add(this.ListenPortNumericUpDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(246, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Security";
            // 
            // MaxConnectionsNumericUpDown
            // 
            this.MaxConnectionsNumericUpDown.Location = new System.Drawing.Point(127, 49);
            this.MaxConnectionsNumericUpDown.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.MaxConnectionsNumericUpDown.Name = "MaxConnectionsNumericUpDown";
            this.MaxConnectionsNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.MaxConnectionsNumericUpDown.TabIndex = 9;
            // 
            // ListenPortNumericUpDown
            // 
            this.ListenPortNumericUpDown.Location = new System.Drawing.Point(127, 23);
            this.ListenPortNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ListenPortNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ListenPortNumericUpDown.Name = "ListenPortNumericUpDown";
            this.ListenPortNumericUpDown.Size = new System.Drawing.Size(75, 20);
            this.ListenPortNumericUpDown.TabIndex = 8;
            this.ListenPortNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            // AppearanceTabPage
            // 
            this.AppearanceTabPage.Controls.Add(this.QuitButtonApp);
            this.AppearanceTabPage.Controls.Add(this.SaveButtonApp);
            this.AppearanceTabPage.Controls.Add(this.groupBox4);
            this.AppearanceTabPage.Location = new System.Drawing.Point(4, 22);
            this.AppearanceTabPage.Name = "AppearanceTabPage";
            this.AppearanceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.AppearanceTabPage.Size = new System.Drawing.Size(461, 257);
            this.AppearanceTabPage.TabIndex = 1;
            this.AppearanceTabPage.Text = "Appearance";
            this.AppearanceTabPage.UseVisualStyleBackColor = true;
            // 
            // QuitButtonApp
            // 
            this.QuitButtonApp.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitButtonApp.Location = new System.Drawing.Point(379, 227);
            this.QuitButtonApp.Name = "QuitButtonApp";
            this.QuitButtonApp.Size = new System.Drawing.Size(75, 23);
            this.QuitButtonApp.TabIndex = 17;
            this.QuitButtonApp.Text = "Cancel";
            this.QuitButtonApp.UseVisualStyleBackColor = true;
            this.QuitButtonApp.Click += new System.EventHandler(this.QuitButtonApp_Click);
            // 
            // SaveButtonApp
            // 
            this.SaveButtonApp.Location = new System.Drawing.Point(298, 227);
            this.SaveButtonApp.Name = "SaveButtonApp";
            this.SaveButtonApp.Size = new System.Drawing.Size(75, 23);
            this.SaveButtonApp.TabIndex = 16;
            this.SaveButtonApp.Text = "Save";
            this.SaveButtonApp.UseVisualStyleBackColor = true;
            this.SaveButtonApp.Click += new System.EventHandler(this.SaveButtonApp_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.picExample);
            this.groupBox4.Controls.Add(this.lstButtons);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 124);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buttons";
            // 
            // picExample
            // 
            this.picExample.Location = new System.Drawing.Point(151, 19);
            this.picExample.Name = "picExample";
            this.picExample.Size = new System.Drawing.Size(291, 95);
            this.picExample.TabIndex = 3;
            this.picExample.TabStop = false;
            // 
            // lstButtons
            // 
            this.lstButtons.FormattingEnabled = true;
            this.lstButtons.Location = new System.Drawing.Point(6, 19);
            this.lstButtons.Name = "lstButtons";
            this.lstButtons.Size = new System.Drawing.Size(139, 95);
            this.lstButtons.TabIndex = 2;
            this.lstButtons.SelectedIndexChanged += new System.EventHandler(this.lstButtons_SelectedIndexChanged);
            // 
            // OptionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 283);
            this.Controls.Add(this.OptionsTabControl);
            this.MaximizeBox = false;
            this.Name = "OptionWindow";
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.OptionsTabControl.ResumeLayout(false);
            this.GeneralTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SettingGroupBox.ResumeLayout(false);
            this.SettingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxDownloadSpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxUploadSpeedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HalfOpenConnectionsNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxConnectionsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListenPortNumericUpDown)).EndInit();
            this.AppearanceTabPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExample)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl OptionsTabControl;
        private System.Windows.Forms.TabPage GeneralTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SavePathButton;
        private System.Windows.Forms.TextBox SavePathTextBox;
        private System.Windows.Forms.GroupBox SettingGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AssociateButton;
        private System.Windows.Forms.NumericUpDown MaxDownloadSpeedNumericUpDown;
        private System.Windows.Forms.NumericUpDown MaxUploadSpeedNumericUpDown;
        private System.Windows.Forms.NumericUpDown HalfOpenConnectionsNumericUpDown;
        private System.Windows.Forms.CheckBox UseUPnPCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button TorrentsPathButton;
        private System.Windows.Forms.TextBox TorrentPathTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown MaxConnectionsNumericUpDown;
        private System.Windows.Forms.NumericUpDown ListenPortNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage AppearanceTabPage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox picExample;
        private System.Windows.Forms.ListBox lstButtons;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button QuitButtonApp;
        private System.Windows.Forms.Button SaveButtonApp;

    }
}