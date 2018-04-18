namespace DFM
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.FileLabel = new System.Windows.Forms.Label();
            this.AddFileButton = new System.Windows.Forms.Button();
            this.SaveDirTextBox = new System.Windows.Forms.TextBox();
            this.SaveDirButton = new System.Windows.Forms.Button();
            this.SaveDirLabel = new System.Windows.Forms.Label();
            this.ProcessLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.RemoveFileButton = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.PreviewFileButton = new System.Windows.Forms.Button();
            this.DataListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ViewDataButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLabel.Location = new System.Drawing.Point(15, 44);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(60, 16);
            this.FileLabel.TabIndex = 0;
            this.FileLabel.Text = "File(s): ";
            // 
            // AddFileButton
            // 
            this.AddFileButton.Location = new System.Drawing.Point(273, 62);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(106, 24);
            this.AddFileButton.TabIndex = 4;
            this.AddFileButton.Text = "Add Files";
            this.AddFileButton.UseVisualStyleBackColor = true;
            this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // SaveDirTextBox
            // 
            this.SaveDirTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SaveDirTextBox.HideSelection = false;
            this.SaveDirTextBox.Location = new System.Drawing.Point(18, 493);
            this.SaveDirTextBox.MaxLength = 40;
            this.SaveDirTextBox.Name = "SaveDirTextBox";
            this.SaveDirTextBox.ReadOnly = true;
            this.SaveDirTextBox.Size = new System.Drawing.Size(249, 22);
            this.SaveDirTextBox.TabIndex = 6;
            this.SaveDirTextBox.Text = "No folder selected";
            // 
            // SaveDirButton
            // 
            this.SaveDirButton.Location = new System.Drawing.Point(273, 491);
            this.SaveDirButton.Name = "SaveDirButton";
            this.SaveDirButton.Size = new System.Drawing.Size(106, 24);
            this.SaveDirButton.TabIndex = 7;
            this.SaveDirButton.Text = "Select Folder";
            this.SaveDirButton.UseVisualStyleBackColor = true;
            this.SaveDirButton.Click += new System.EventHandler(this.SaveDirButton_Click);
            // 
            // SaveDirLabel
            // 
            this.SaveDirLabel.AutoSize = true;
            this.SaveDirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDirLabel.Location = new System.Drawing.Point(15, 473);
            this.SaveDirLabel.Name = "SaveDirLabel";
            this.SaveDirLabel.Size = new System.Drawing.Size(119, 16);
            this.SaveDirLabel.TabIndex = 8;
            this.SaveDirLabel.Text = "Save Directory: ";
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessLabel.Location = new System.Drawing.Point(15, 368);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(147, 16);
            this.ProcessLabel.TabIndex = 9;
            this.ProcessLabel.Text = "Processing Options:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(18, 387);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Fill lab analysis certificate";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(18, 413);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(156, 20);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Export neph. data plot";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(18, 439);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(237, 20);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Export combined data spreadsheet";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(202, 526);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(177, 24);
            this.ProcessButton.TabIndex = 13;
            this.ProcessButton.Text = "Process Output";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // RemoveFileButton
            // 
            this.RemoveFileButton.Location = new System.Drawing.Point(273, 92);
            this.RemoveFileButton.Name = "RemoveFileButton";
            this.RemoveFileButton.Size = new System.Drawing.Size(106, 24);
            this.RemoveFileButton.TabIndex = 14;
            this.RemoveFileButton.Text = "Remove Files";
            this.RemoveFileButton.UseVisualStyleBackColor = true;
            this.RemoveFileButton.Click += new System.EventHandler(this.RemoveFileButton_Click);
            // 
            // FileListBox
            // 
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.ItemHeight = 16;
            this.FileListBox.Location = new System.Drawing.Point(18, 63);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.FileListBox.Size = new System.Drawing.Size(249, 132);
            this.FileListBox.TabIndex = 15;
            // 
            // PreviewFileButton
            // 
            this.PreviewFileButton.Location = new System.Drawing.Point(273, 122);
            this.PreviewFileButton.Name = "PreviewFileButton";
            this.PreviewFileButton.Size = new System.Drawing.Size(106, 24);
            this.PreviewFileButton.TabIndex = 16;
            this.PreviewFileButton.Text = "Preview Files";
            this.PreviewFileButton.UseVisualStyleBackColor = true;
            this.PreviewFileButton.Click += new System.EventHandler(this.PreviewFileButton_Click);
            // 
            // DataListBox
            // 
            this.DataListBox.FormattingEnabled = true;
            this.DataListBox.ItemHeight = 16;
            this.DataListBox.Location = new System.Drawing.Point(18, 220);
            this.DataListBox.Name = "DataListBox";
            this.DataListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DataListBox.Size = new System.Drawing.Size(249, 132);
            this.DataListBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Data Found: ";
            // 
            // MenuStrip
            // 
            this.MenuStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSettings,
            this.MenuHelp});
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(50, 20);
            this.MenuStrip.Text = "Menu";
            // 
            // MenuSettings
            // 
            this.MenuSettings.Name = "MenuSettings";
            this.MenuSettings.Size = new System.Drawing.Size(180, 22);
            this.MenuSettings.Text = "Settings";
            this.MenuSettings.Click += new System.EventHandler(this.MenuSettings_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(180, 22);
            this.MenuHelp.Text = "Help";
            this.MenuHelp.Click += new System.EventHandler(this.MenuHelp_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(397, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ViewDataButton
            // 
            this.ViewDataButton.Location = new System.Drawing.Point(273, 220);
            this.ViewDataButton.Name = "ViewDataButton";
            this.ViewDataButton.Size = new System.Drawing.Size(106, 24);
            this.ViewDataButton.TabIndex = 20;
            this.ViewDataButton.Text = "View Data";
            this.ViewDataButton.UseVisualStyleBackColor = true;
            this.ViewDataButton.Click += new System.EventHandler(this.ViewDataButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(397, 563);
            this.Controls.Add(this.ViewDataButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataListBox);
            this.Controls.Add(this.PreviewFileButton);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.RemoveFileButton);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ProcessLabel);
            this.Controls.Add(this.SaveDirLabel);
            this.Controls.Add(this.SaveDirButton);
            this.Controls.Add(this.SaveDirTextBox);
            this.Controls.Add(this.AddFileButton);
            this.Controls.Add(this.FileLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MTL Data File Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Button AddFileButton;
        private System.Windows.Forms.TextBox SaveDirTextBox;
        private System.Windows.Forms.Button SaveDirButton;
        private System.Windows.Forms.Label SaveDirLabel;
        private System.Windows.Forms.Label ProcessLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Button RemoveFileButton;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.Button PreviewFileButton;
        private System.Windows.Forms.ListBox DataListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuSettings;
        private System.Windows.Forms.ToolStripMenuItem MenuHelp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button ViewDataButton;
    }
}

