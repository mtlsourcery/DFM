/*
 * Data File Manager (DFM)
 * 
 * Written by Preston Huft and Drew Schwarz for MTL-X for internal use only.
 * 
 * Spring/Summer 2018.
 * 
 * /////////////////////////////////////////////////////////////////////////////
 * 
 *                ||\    //||  ||||||||||  ||            \\   //
 *                ||\\  // ||      ||      ||             \\ //
 *                || \\//  ||      ||      ||        ==    |||
 *                ||       ||      ||      ||             // \\
 *                ||       ||      ||      |||||||||     //   \\ 
 *                
 *                         DOING WELL BY DOING GOOD. X.
 * 
 * /////////////////////////////////////////////////////////////////////////////
 * 
 */

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
    public partial class TwoButtonForm : Form
    {
        /* Class Variables */

        const int padding = 5;
        const bool DEBUG = true;

        /* Class Methods */

        /// <summary>
        /// The constructor.
        /// </summary>
        public TwoButtonForm(string message, Image image)
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
            this.Height = this.ImageBox.Height + YesButton.Height +
                ErrorLabel.Height;

            int labelx0 = (int)(.5 * (this.Width - ErrorLabel.Width)) - 2*padding;
            int labely0 = ImageBox.Height - 15*padding;
            this.ErrorLabel.Location = new Point(labelx0, labely0);

            int yesButtonx0 = (int)(.5*this.Width - YesButton.Width
                - padding) - 2*padding;
            int yesButtony0 = labely0 + ErrorLabel.Height + 2*padding;
            this.YesButton.Location = new Point(yesButtonx0, yesButtony0);

            int noButtonx0 = yesButtonx0 + NoButton.Width + padding;
            int noButtony0 = yesButtony0;
            this.NoButton.Location = new Point(noButtonx0, noButtony0);
        }

        /// <summary>
        /// Closes the form on OKButton clicked or enter key pressed. The enter
        /// key functionality is enabled in the Form's properties by setting 
        /// AcceptButton to OKButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YesButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Natural rounding to whole number. 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Nint(double n)
        {
            return (int)(n + .5);
        }
    }
}
