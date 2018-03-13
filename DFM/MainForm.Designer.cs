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
            this.fileLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.FiletypeCBox = new System.Windows.Forms.ComboBox();
            this.fileopenButton = new System.Windows.Forms.Button();
            this.FilenameTBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.Location = new System.Drawing.Point(170, 13);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(42, 16);
            this.fileLabel.TabIndex = 0;
            this.fileLabel.Text = "File: ";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(12, 13);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(115, 16);
            this.typeLabel.TabIndex = 1;
            this.typeLabel.Text = "Data File Type:";
            // 
            // FiletypeCBox
            // 
            this.FiletypeCBox.FormattingEnabled = true;
            this.FiletypeCBox.Location = new System.Drawing.Point(12, 32);
            this.FiletypeCBox.Name = "FiletypeCBox";
            this.FiletypeCBox.Size = new System.Drawing.Size(121, 24);
            this.FiletypeCBox.TabIndex = 2;
            // 
            // fileopenButton
            // 
            this.fileopenButton.Location = new System.Drawing.Point(410, 34);
            this.fileopenButton.Name = "fileopenButton";
            this.fileopenButton.Size = new System.Drawing.Size(97, 24);
            this.fileopenButton.TabIndex = 4;
            this.fileopenButton.Text = "Select File";
            this.fileopenButton.UseVisualStyleBackColor = true;
            this.fileopenButton.Click += new System.EventHandler(this.FileopenButton_Click);
            // 
            // FilenameTBox
            // 
            this.FilenameTBox.Enabled = false;
            this.FilenameTBox.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FilenameTBox.HideSelection = false;
            this.FilenameTBox.Location = new System.Drawing.Point(173, 34);
            this.FilenameTBox.MaxLength = 40;
            this.FilenameTBox.Name = "FilenameTBox";
            this.FilenameTBox.Size = new System.Drawing.Size(207, 22);
            this.FilenameTBox.TabIndex = 5;
            this.FilenameTBox.Text = "No file selected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 285);
            this.Controls.Add(this.FilenameTBox);
            this.Controls.Add(this.fileopenButton);
            this.Controls.Add(this.FiletypeCBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.fileLabel);
            this.Name = "MainForm";
            this.Text = "MTL Data File Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox FiletypeCBox;
        private System.Windows.Forms.Button fileopenButton;
        private System.Windows.Forms.TextBox FilenameTBox;
    }
}

