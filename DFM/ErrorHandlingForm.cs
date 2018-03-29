using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace DFM
{
    public partial class ErrorHandlingForm : Form
    {
        /* Class Variables */

        const string URL_STRING =
            "http://thecatapi.com/api/images/get?format=xml&results_per_page=20";
        List<string> imageURLs = new List<string>();

        /* Class Methods */

        /// <summary>
        /// The constructor.
        /// </summary>
        public ErrorHandlingForm()
        {
            InitializeComponent();
            imageURLs = GetImageURLS(URL_STRING);
        }

        private List<string> GetImageURLS(string url_string)
        {
            List<string> urlList = new List<string>();
            bool isURL = false;
            XmlTextReader reader = new XmlTextReader(url_string);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "url")
                        { isURL = true; }
                        break;
                    case XmlNodeType.Text:
                        if (isURL)
                        {
                            Console.WriteLine(reader.Value);
                            urlList.Add(reader.Value);
                            isURL = false;
                        }
                        break;
                }
            }
            return urlList;
        }

        private void ShowMessage(string msg, Exception exception)
        {
            ErrorHandlingForm errForm = new ErrorHandlingForm();
            string labelStr = "Oops! Something went wrong...";
            var label = errForm.ErrorLabel;
            
            if (msg != null)
            { label.Text = msg; }
            else { label.Text = labelStr;  }
            //label.Image = // read an image from a url
            
        }
    }
}
