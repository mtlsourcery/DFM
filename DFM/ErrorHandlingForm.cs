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

        const int padding = 5;
        const bool DEBUG = true;

        /* Class Methods */

        /// <summary>
        /// The constructor.
        /// </summary>
        public ErrorHandlingForm(string message, Image image)
        {
            InitializeComponent();

            this.ErrorLabel.Text = message;
            this.ErrorLabel.Font = new Font(ErrorLabel.Font, FontStyle.Bold);
            this.ImageBox.Image = image;

            /* Tune the position and size of controls based on each others'
             * dimensions. Locations of these in ErrorHandlingForm.cs[Design]
             * are not representative of the actual locations when the form is
             * launched, because we are modifying them below.
             */ 

            this.ImageBox.Width = image.Width;
            this.ImageBox.Height = image.Height;

            this.Width = this.ImageBox.Width + 2*padding;
            this.Height = this.ImageBox.Height + OKButton.Height +
                ErrorLabel.Height;

            int labelx0 = (int)(.5 * (this.Width - ErrorLabel.Width)) - 2*padding;
            int labely0 = ImageBox.Height - 10*padding;
            this.ErrorLabel.Location = new Point(labelx0, labely0);

            int buttonx0 = (int)(.5 * (this.Width - OKButton.Width)) - 2*padding;
            int buttony0 = labely0 + ErrorLabel.Height + 2*padding;
            this.OKButton.Location = new Point(buttonx0, buttony0);
        }

        /// <summary>
        /// Closes the form on OKButton clicked or enter key pressed. The enter
        /// key functionality is enabled in the Form's properties by setting 
        /// AcceptButton to OKButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
