using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace DFM
{
    public partial class ErrorHandlingForm : Form
    {
        /* Class Variables */

        const bool DEBUG = true;

        /* Class Methods */

        /// <summary>
        /// The constructor.
        /// </summary>
        public ErrorHandlingForm(string message, Image image)
        {
            InitializeComponent();
            this.ErrorLabel.Text = message;
            this.ImageBox.Image = image;
        }
    }
}
