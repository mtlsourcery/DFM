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
    public partial class ViewDataForm : Form
    {
        /* Class Constants */

        const bool DEBUG = true;
        const string FLAG = DataObject.HEADER_FLAG;

        /* Class Methods */

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="objectList"></param>
        //public TableForm(List<List<List<string>>> dataMatrix3D)
        public ViewDataForm(Dictionary<string,DataObject> objectList)
        {
            InitializeComponent();
            GridTabsInit(objectList);
        }

        /// <summary>
        /// Adds data rows to a DataGridView in a new TabPage for each file.
        /// </summary>
        /// <param name="objectDict"></param>
        void GridTabsInit(Dictionary<string,DataObject> objectDict)
        {
            int tab = 0;
            foreach (var entry in objectDict)
            {
                //int row = 0;
                //int col = 0;
                DataGridView dataGridView = new DataGridView()
                {
                    AutoGenerateColumns = true,
                    Dock = DockStyle.Fill
                };
                var columns = entry.Value.DataColumns;
                int maxColNum = entry.Value.MaxColumnCount;
                List<List<string>> dataRows = entry.Value.DataRows;
                int rowStart = 0; // Where to start the iteration over rows

                for (int i = 0; i < maxColNum; i++)
                {
                    string header = i.ToString();
                    if (columns[i][0].Contains(FLAG))
                    {
                        // Get the header text
                        header = columns[i][0].Remove(0, FLAG.Length);
                        rowStart = 1;
                    }
                    dataGridView.Columns.Add("col" + i.ToString(),
                        header);
                    Console.WriteLine("Column number: " + i.ToString());
                }

                // Add the data rows to the DataGridView. if we added column 
                // headers above, then start at the 1st row, not 0th row.
                for(int i = rowStart; i < dataRows.Count; i++)
                {
                    dataGridView.Rows.Add(dataRows[i].ToArray());
                }

                //// Add the data rows to the DataGridView 
                //foreach (var row in dataRows)
                //{
                //    dataGridView.Rows.Add(row.ToArray());
                //}

                DataTabs.TabPages.Add(new TabPage(entry.Key));
                DataTabs.TabPages[tab].Controls.Add(dataGridView);
                tab++;
            }
        }
    }
}
