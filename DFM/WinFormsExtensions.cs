using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFM
{
    /// <summary>
    /// A class for methods that can extend the capabilities of Windows Forms
    /// Views. Note that this class is not to be instantiated; it is static.
    /// </summary>
    public static class WinFormsExtensions
    {
        public static void AppendLine(this TextBox source, string str)
        {
            // If the TextBox is empty, add str
            if (source.Text.Length == 0)
                source.Text = str;
            // If the TextBox is not empty, insert a carriage return before str
            else
                source.AppendText(Environment.NewLine + str);
        }
    }
}
