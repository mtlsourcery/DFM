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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.fileopenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileLabel.Location = new System.Drawing.Point(158, 13);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(42, 16);
            this.fileLabel.TabIndex = 0;
            this.fileLabel.Text = "File: ";
            this.fileLabel.Click += new System.EventHandler(this.label1_Click);
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
            this.typeLabel.Click += new System.EventHandler(this.typelabel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 2;
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.filenameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.filenameLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.filenameLabel.Location = new System.Drawing.Point(152, 35);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(112, 18);
            this.filenameLabel.TabIndex = 3;
            this.filenameLabel.Text = "No file selected...";
            // 
            // fileopenButton
            // 
            this.fileopenButton.Location = new System.Drawing.Point(287, 32);
            this.fileopenButton.Name = "fileopenButton";
            this.fileopenButton.Size = new System.Drawing.Size(92, 23);
            this.fileopenButton.TabIndex = 4;
            this.fileopenButton.Text = "Select File";
            this.fileopenButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 222);
            this.Controls.Add(this.fileopenButton);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.comboBox1);
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.Button fileopenButton;
    }
}

