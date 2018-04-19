namespace DFM
{
    partial class ViewDataForm
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
            this.DataTabs = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // DataTabs
            // 
            this.DataTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataTabs.Location = new System.Drawing.Point(0, 0);
            this.DataTabs.Name = "DataTabs";
            this.DataTabs.SelectedIndex = 0;
            this.DataTabs.Size = new System.Drawing.Size(516, 450);
            this.DataTabs.TabIndex = 0;
            // 
            // ViewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.DataTabs);
            this.Name = "ViewDataForm";
            this.Text = "TableForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl DataTabs;
    }
}