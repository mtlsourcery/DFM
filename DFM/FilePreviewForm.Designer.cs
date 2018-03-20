namespace DFM
{
    partial class FilePreviewForm
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
            this.PreviewTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PreviewTextBox
            // 
            this.PreviewTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewTextBox.Location = new System.Drawing.Point(0, 0);
            this.PreviewTextBox.Multiline = true;
            this.PreviewTextBox.Name = "PreviewTextBox";
            this.PreviewTextBox.ReadOnly = true;
            this.PreviewTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PreviewTextBox.Size = new System.Drawing.Size(606, 516);
            this.PreviewTextBox.TabIndex = 0;
            // 
            // FilePreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 516);
            this.Controls.Add(this.PreviewTextBox);
            this.Name = "FilePreviewForm";
            this.Text = "Preview - Filename.ext";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PreviewTextBox;
    }
}