using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFM
{
    /// <summary>
    /// A form to display the contents of a selected file as read-only.
    /// </summary>
    public partial class FilePreviewForm : Form
    {
        /* Class Variables */

        /* Class Methods */ 

        /// <summary>
        /// The constructor for FilePreviewForm.
        /// </summary>
        /// <param name="fileString">The file content to be displayed.</param>
        public FilePreviewForm(string fileString)
        {
            InitializeComponent();

            // Dipslay the file contents
            PreviewTextBox.Text = fileString;
        }
    }
}
