namespace MonoTorrent.GUI.View
{
    partial class CreateWindow
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SaveToBrowseButton = new System.Windows.Forms.Button();
            this.SaveToTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FromPathBrowseButton = new System.Windows.Forms.Button();
            this.FromPathTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackerURLTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateByTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.Okbutton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SaveToBrowseButton);
            this.groupBox1.Controls.Add(this.SaveToTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save to";
            // 
            // SaveToBrowseButton
            // 
            this.SaveToBrowseButton.Location = new System.Drawing.Point(298, 16);
            this.SaveToBrowseButton.Name = "SaveToBrowseButton";
            this.SaveToBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.SaveToBrowseButton.TabIndex = 1;
            this.SaveToBrowseButton.Text = "Browse";
            this.SaveToBrowseButton.UseVisualStyleBackColor = true;
            this.SaveToBrowseButton.Click += new System.EventHandler(this.SaveToBrowseButton_Click);
            // 
            // SaveToTextBox
            // 
            this.SaveToTextBox.Location = new System.Drawing.Point(15, 20);
            this.SaveToTextBox.Name = "SaveToTextBox";
            this.SaveToTextBox.Size = new System.Drawing.Size(276, 20);
            this.SaveToTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FromPathBrowseButton);
            this.groupBox2.Controls.Add(this.FromPathTextBox);
            this.groupBox2.Location = new System.Drawing.Point(10, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(399, 51);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "From path";
            // 
            // FromPathBrowseButton
            // 
            this.FromPathBrowseButton.Location = new System.Drawing.Point(300, 16);
            this.FromPathBrowseButton.Name = "FromPathBrowseButton";
            this.FromPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.FromPathBrowseButton.TabIndex = 1;
            this.FromPathBrowseButton.Text = "Browse";
            this.FromPathBrowseButton.UseVisualStyleBackColor = true;
            this.FromPathBrowseButton.Click += new System.EventHandler(this.FromPathBrowseButton_Click);
            // 
            // FromPathTextBox
            // 
            this.FromPathTextBox.Location = new System.Drawing.Point(15, 20);
            this.FromPathTextBox.Name = "FromPathTextBox";
            this.FromPathTextBox.Size = new System.Drawing.Size(278, 20);
            this.FromPathTextBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TrackerURLTextBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.CreateByTextBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.CommentTextBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 106);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tracker URL :";
            // 
            // TrackerURLTextBox
            // 
            this.TrackerURLTextBox.Location = new System.Drawing.Point(84, 74);
            this.TrackerURLTextBox.Name = "TrackerURLTextBox";
            this.TrackerURLTextBox.Size = new System.Drawing.Size(206, 20);
            this.TrackerURLTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Create by :";
            // 
            // CreateByTextBox
            // 
            this.CreateByTextBox.Location = new System.Drawing.Point(84, 48);
            this.CreateByTextBox.Name = "CreateByTextBox";
            this.CreateByTextBox.Size = new System.Drawing.Size(206, 20);
            this.CreateByTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comment :";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Location = new System.Drawing.Point(84, 22);
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(206, 20);
            this.CommentTextBox.TabIndex = 0;
            // 
            // Okbutton
            // 
            this.Okbutton.Location = new System.Drawing.Point(334, 172);
            this.Okbutton.Name = "Okbutton";
            this.Okbutton.Size = new System.Drawing.Size(75, 23);
            this.Okbutton.TabIndex = 3;
            this.Okbutton.Text = "OK";
            this.Okbutton.UseVisualStyleBackColor = true;
            this.Okbutton.Click += new System.EventHandler(this.Okbutton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(334, 214);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 265);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.Okbutton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CreateWindow";
            this.Text = "CreateWindow";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox CommentTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CreateByTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TrackerURLTextBox;
        private System.Windows.Forms.Button SaveToBrowseButton;
        private System.Windows.Forms.TextBox SaveToTextBox;
        private System.Windows.Forms.Button FromPathBrowseButton;
        private System.Windows.Forms.TextBox FromPathTextBox;
        private System.Windows.Forms.Button Okbutton;
        private System.Windows.Forms.Button CancelButton;
    }
}