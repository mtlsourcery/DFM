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
 *                || \\//  ||      ||      ||        ==    | |
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
            int rowStart;
            int colNum;
            string header; 
            List<List<string>> columns = new List<List<string>>();
            List<List<string>> rows = new List<List<string>>();

            foreach (var entry in objectDict)
            {
                DataGridView dataGridView = new DataGridView()
                {
                    AutoGenerateColumns = true,
                    Dock = DockStyle.Fill
                };
                columns = entry.Value.DataColumns;
                colNum = columns.Count;
                rows = entry.Value.DataRows;
                rowStart = 0; // Where to start the iteration over rows

                //Console.WriteLine("DataColumns.Count: " +
                //            entry.Value.DataColumns.Count +
                //            Environment.NewLine + "colNum: " +
                //            colNum);

                for (int i = 0; i < colNum; i++)
                {
                    if (entry.Value.HasHeader)
                    {
                        // Get the header text
                        //header = columns[i][0].Remove(0, FLAG.Length);
                        header = columns[i][0];
                        rowStart = 1;
                    }
                    else
                        header = i.ToString();
                    dataGridView.Columns.Add("col" + i.ToString(),
                        header);
                    Console.WriteLine("Column number: " + i.ToString());
                }

                // Add the data rows to the DataGridView. If we added column 
                // headers above, then start at the 1st row, not 0th row.
                for (int i = rowStart; i < rows.Count; i++)
                {
                    dataGridView.Rows.Add(rows[i].ToArray());
                }
                DataTabs.TabPages.Add(new TabPage(entry.Key));
                DataTabs.TabPages[tab].Controls.Add(dataGridView);
                tab++;
            }
        }
    }
}
