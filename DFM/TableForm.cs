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
    public partial class TableForm : Form
    {
        /* Class Constants */

        const bool DEBUG = true;

        /* Class Methods */

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="dataMatrix3D"></param>
        public TableForm(List<List<List<string>>> dataMatrix3D)
        {
            InitializeComponent();

            // This will store our data we want to display
            BindingSource bindSource = new BindingSource
            {   
                // Set the type of data
                DataSource = typeof(List<string>)
            };

            Console.WriteLine(dataMatrix3D.Count.ToString());

            foreach (List<List<string>> dataMatrix2D in dataMatrix3D)
            {
                Console.WriteLine("2D level");
                foreach(List<string> row in dataMatrix2D)
                {
                    Console.WriteLine("1D level");
                    bindSource.Add(row);
                }
            }

            DataGrid.DataSource = bindSource;
            DataGrid.AutoGenerateColumns = true;
        }
    }
}
