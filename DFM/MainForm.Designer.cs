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
            this.FileOpenButton = new System.Windows.Forms.Button();
            this.FilenameTBox = new System.Windows.Forms.TextBox();
            this.SaveDirTBox = new System.Windows.Forms.TextBox();
            this.SaveDirButton = new System.Windows.Forms.Button();
            this.SaveDirLabel = new System.Windows.Forms.Label();
            this.ProcessLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.FiletypeCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLabel.Location = new System.Drawing.Point(176, 13);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(42, 16);
            this.FileLabel.TabIndex = 0;
            this.FileLabel.Text = "File: ";
            // 
            // FileOpenButton
            // 
            this.FileOpenButton.Location = new System.Drawing.Point(443, 34);
            this.FileOpenButton.Name = "FileOpenButton";
            this.FileOpenButton.Size = new System.Drawing.Size(97, 24);
            this.FileOpenButton.TabIndex = 4;
            this.FileOpenButton.Text = "Select Files";
            this.FileOpenButton.UseVisualStyleBackColor = true;
            this.FileOpenButton.Click += new System.EventHandler(this.FileOpenButton_Click);
            // 
            // FilenameTBox
            // 
            this.FilenameTBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FilenameTBox.HideSelection = false;
            this.FilenameTBox.Location = new System.Drawing.Point(179, 34);
            this.FilenameTBox.MaxLength = 40;
            this.FilenameTBox.Name = "FilenameTBox";
            this.FilenameTBox.Size = new System.Drawing.Size(249, 22);
            this.FilenameTBox.TabIndex = 5;
            this.FilenameTBox.Text = "No file selected";
            // 
            // SaveDirTBox
            // 
            this.SaveDirTBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.SaveDirTBox.HideSelection = false;
            this.SaveDirTBox.Location = new System.Drawing.Point(179, 171);
            this.SaveDirTBox.MaxLength = 40;
            this.SaveDirTBox.Name = "SaveDirTBox";
            this.SaveDirTBox.Size = new System.Drawing.Size(249, 22);
            this.SaveDirTBox.TabIndex = 6;
            this.SaveDirTBox.Text = "No folder selected";
            // 
            // SaveDirButton
            // 
            this.SaveDirButton.Location = new System.Drawing.Point(443, 171);
            this.SaveDirButton.Name = "SaveDirButton";
            this.SaveDirButton.Size = new System.Drawing.Size(97, 24);
            this.SaveDirButton.TabIndex = 7;
            this.SaveDirButton.Text = "Select Folder";
            this.SaveDirButton.UseVisualStyleBackColor = true;
            this.SaveDirButton.Click += new System.EventHandler(this.SaveDirButton_Click);
            // 
            // SaveDirLabel
            // 
            this.SaveDirLabel.AutoSize = true;
            this.SaveDirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveDirLabel.Location = new System.Drawing.Point(176, 152);
            this.SaveDirLabel.Name = "SaveDirLabel";
            this.SaveDirLabel.Size = new System.Drawing.Size(119, 16);
            this.SaveDirLabel.TabIndex = 8;
            this.SaveDirLabel.Text = "Save Directory: ";
            // 
            // ProcessLabel
            // 
            this.ProcessLabel.AutoSize = true;
            this.ProcessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessLabel.Location = new System.Drawing.Point(9, 204);
            this.ProcessLabel.Name = "ProcessLabel";
            this.ProcessLabel.Size = new System.Drawing.Size(147, 16);
            this.ProcessLabel.TabIndex = 9;
            this.ProcessLabel.Text = "Processing Options:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 234);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(179, 20);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Fill lab analysis certificate";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 260);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(156, 20);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Export neph. data plot";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(12, 286);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(237, 20);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Export combined data spreadsheet";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(363, 286);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 318);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ProcessLabel);
            this.Controls.Add(this.SaveDirLabel);
            this.Controls.Add(this.SaveDirButton);
            this.Controls.Add(this.SaveDirTBox);
            this.Controls.Add(this.FilenameTBox);
            this.Controls.Add(this.FileOpenButton);
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
        private System.Windows.Forms.Button FileOpenButton;
        private System.Windows.Forms.TextBox FilenameTBox;
        private System.Windows.Forms.TextBox SaveDirTBox;
        private System.Windows.Forms.Button SaveDirButton;
        private System.Windows.Forms.Label SaveDirLabel;
        private System.Windows.Forms.Label ProcessLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.ComboBox FiletypeCBox;
    }
}

