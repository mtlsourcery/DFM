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
            this.TypeLabel = new System.Windows.Forms.Label();
            this.FiletypeCBox = new System.Windows.Forms.ComboBox();
            this.RemoveFileButton = new System.Windows.Forms.Button();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLabel.Location = new System.Drawing.Point(176, 13);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(60, 16);
            this.FileLabel.TabIndex = 0;
            this.FileLabel.Text = "File(s): ";
            // 
            // AddFileButton
            // 
            this.AddFileButton.Location = new System.Drawing.Point(434, 34);
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
            this.SaveDirTextBox.Location = new System.Drawing.Point(179, 215);
            this.SaveDirTextBox.MaxLength = 40;
            this.SaveDirTextBox.Name = "SaveDirTextBox";
            this.SaveDirTextBox.ReadOnly = true;
            this.SaveDirTextBox.Size = new System.Drawing.Size(249, 22);
            this.SaveDirTextBox.TabIndex = 6;
            this.SaveDirTextBox.Text = "No folder selected";
            // 
            // SaveDirButton
            // 
            this.SaveDirButton.Location = new System.Drawing.Point(434, 215);
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
            this.SaveDirLabel.Location = new System.Drawing.Point(176, 196);
            this.SaveDirLabel.Name = "SaveDirLabel";
            this.SaveDirLabel.Size = new System.Drawing.Size(119, 16);
            this.SaveDirLabel.TabIndex = 8;
            this.SaveDirLabel.Text = "Save Directory: ";
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessLabel.Location = new System.Drawing.Point(9, 239);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(147, 16);
            this.ProcessLabel.TabIndex = 9;
            this.ProcessLabel.Text = "Processing Options:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 269);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Fill lab analysis certificate";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 295);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(156, 20);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Export neph. data plot";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 321);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(237, 20);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Export combined data spreadsheet";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(363, 321);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(177, 24);
            this.ProcessButton.TabIndex = 13;
            this.ProcessButton.Text = "Process Output";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeLabel.Location = new System.Drawing.Point(12, 13);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(115, 16);
            this.TypeLabel.TabIndex = 1;
            this.TypeLabel.Text = "Data File Type:";
            // 
            // FiletypeCBox
            // 
            this.FiletypeCBox.FormattingEnabled = true;
            this.FiletypeCBox.Items.AddRange(new object[] {
            "MicroPEM Data (.csv)",
            "XRF Data (.rtf)",
            "FWS Data (.xlsx)"});
            this.FiletypeCBox.Location = new System.Drawing.Point(12, 32);
            this.FiletypeCBox.Name = "FiletypeCBox";
            this.FiletypeCBox.Size = new System.Drawing.Size(155, 24);
            this.FiletypeCBox.TabIndex = 2;
            // 
            // RemoveFileButton
            // 
            this.RemoveFileButton.Location = new System.Drawing.Point(434, 64);
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
            this.FileListBox.Location = new System.Drawing.Point(179, 32);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.FileListBox.Size = new System.Drawing.Size(249, 148);
            this.FileListBox.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(552, 353);
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
            this.Controls.Add(this.FiletypeCBox);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.FileLabel);
            this.Name = "MainForm";
            this.Text = "MTL Data File Manager";
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
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox FiletypeCBox;
        private System.Windows.Forms.Button RemoveFileButton;
        private System.Windows.Forms.ListBox FileListBox;
    }
}

