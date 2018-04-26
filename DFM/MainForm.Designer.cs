﻿namespace DFM
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
            this.LabCert_ChBox = new System.Windows.Forms.CheckBox();
            this.Excel_ChBox = new System.Windows.Forms.CheckBox();
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
            this.FilenameBox = new System.Windows.Forms.TextBox();
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.CSV_ChBox = new System.Windows.Forms.CheckBox();
            this.ClearFilesButton = new System.Windows.Forms.Button();
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
            this.SaveDirTextBox.Location = new System.Drawing.Point(18, 386);
            this.SaveDirTextBox.MaxLength = 40;
            this.SaveDirTextBox.Name = "SaveDirTextBox";
            this.SaveDirTextBox.ReadOnly = true;
            this.SaveDirTextBox.Size = new System.Drawing.Size(249, 22);
            this.SaveDirTextBox.TabIndex = 6;
            this.SaveDirTextBox.Text = "No folder selected";
            // 
            // SaveDirButton
            // 
            this.SaveDirButton.Location = new System.Drawing.Point(273, 384);
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
            this.SaveDirLabel.Location = new System.Drawing.Point(15, 366);
            this.SaveDirLabel.Name = "SaveDirLabel";
            this.SaveDirLabel.Size = new System.Drawing.Size(119, 16);
            this.SaveDirLabel.TabIndex = 8;
            this.SaveDirLabel.Text = "Save Directory: ";
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessLabel.Location = new System.Drawing.Point(15, 272);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(147, 16);
            this.ProcessLabel.TabIndex = 9;
            this.ProcessLabel.Text = "Processing Options:";
            // 
            // LabCert_ChBox
            // 
            this.LabCert_ChBox.AutoSize = true;
            this.LabCert_ChBox.Location = new System.Drawing.Point(18, 336);
            this.LabCert_ChBox.Name = "LabCert_ChBox";
            this.LabCert_ChBox.Size = new System.Drawing.Size(179, 20);
            this.LabCert_ChBox.TabIndex = 10;
            this.LabCert_ChBox.Text = "Fill lab analysis certificate";
            this.LabCert_ChBox.UseVisualStyleBackColor = true;
            // 
            // Excel_ChBox
            // 
            this.Excel_ChBox.AutoSize = true;
            this.Excel_ChBox.Location = new System.Drawing.Point(18, 296);
            this.Excel_ChBox.Name = "Excel_ChBox";
            this.Excel_ChBox.Size = new System.Drawing.Size(238, 20);
            this.Excel_ChBox.TabIndex = 12;
            this.Excel_ChBox.Text = "Export merged data to spreadsheet";
            this.Excel_ChBox.UseVisualStyleBackColor = true;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(202, 471);
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
            this.FileListBox.Size = new System.Drawing.Size(249, 84);
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
            this.DataListBox.Location = new System.Drawing.Point(18, 175);
            this.DataListBox.Name = "DataListBox";
            this.DataListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DataListBox.Size = new System.Drawing.Size(249, 84);
            this.DataListBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 155);
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
            this.MenuSettings.Size = new System.Drawing.Size(116, 22);
            this.MenuSettings.Text = "Settings";
            this.MenuSettings.Click += new System.EventHandler(this.MenuSettings_Click);
            // 
            // MenuHelp
            // 
            this.MenuHelp.Name = "MenuHelp";
            this.MenuHelp.Size = new System.Drawing.Size(116, 22);
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
            this.ViewDataButton.Location = new System.Drawing.Point(273, 175);
            this.ViewDataButton.Name = "ViewDataButton";
            this.ViewDataButton.Size = new System.Drawing.Size(106, 24);
            this.ViewDataButton.TabIndex = 20;
            this.ViewDataButton.Text = "View Data";
            this.ViewDataButton.UseVisualStyleBackColor = true;
            this.ViewDataButton.Click += new System.EventHandler(this.ViewDataButton_Click);
            // 
            // FilenameBox
            // 
            this.FilenameBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FilenameBox.HideSelection = false;
            this.FilenameBox.Location = new System.Drawing.Point(18, 434);
            this.FilenameBox.MaxLength = 40;
            this.FilenameBox.Name = "FilenameBox";
            this.FilenameBox.Size = new System.Drawing.Size(361, 22);
            this.FilenameBox.TabIndex = 21;
            this.FilenameBox.Text = "output filename";
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.AutoSize = true;
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(15, 414);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(266, 16);
            this.FileNameLabel.TabIndex = 22;
            this.FileNameLabel.Text = "Output Filename (exclude extension): ";
            // 
            // CSV_ChBox
            // 
            this.CSV_ChBox.AutoSize = true;
            this.CSV_ChBox.Location = new System.Drawing.Point(18, 316);
            this.CSV_ChBox.Name = "CSV_ChBox";
            this.CSV_ChBox.Size = new System.Drawing.Size(209, 20);
            this.CSV_ChBox.TabIndex = 23;
            this.CSV_ChBox.Text = "Export merged data to CSV file";
            this.CSV_ChBox.UseVisualStyleBackColor = true;
            // 
            // ClearFilesButton
            // 
            this.ClearFilesButton.Location = new System.Drawing.Point(273, 205);
            this.ClearFilesButton.Name = "ClearFilesButton";
            this.ClearFilesButton.Size = new System.Drawing.Size(106, 24);
            this.ClearFilesButton.TabIndex = 24;
            this.ClearFilesButton.Text = "Clear All Files";
            this.ClearFilesButton.UseVisualStyleBackColor = true;
            this.ClearFilesButton.Click += new System.EventHandler(this.ClearFilesButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(397, 507);
            this.Controls.Add(this.ClearFilesButton);
            this.Controls.Add(this.CSV_ChBox);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.FilenameBox);
            this.Controls.Add(this.ViewDataButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataListBox);
            this.Controls.Add(this.PreviewFileButton);
            this.Controls.Add(this.FileListBox);
            this.Controls.Add(this.RemoveFileButton);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.Excel_ChBox);
            this.Controls.Add(this.LabCert_ChBox);
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
        private System.Windows.Forms.CheckBox LabCert_ChBox;
        private System.Windows.Forms.CheckBox Excel_ChBox;
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
        private System.Windows.Forms.TextBox FilenameBox;
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.CheckBox CSV_ChBox;
        private System.Windows.Forms.Button ClearFilesButton;
    }
}

