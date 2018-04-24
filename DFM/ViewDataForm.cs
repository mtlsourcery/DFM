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
                int maxColNum = entry.Value.MaxColumnCount;
                for (int i = 0; i < maxColNum; i++)
                {
                    dataGridView.Columns.Add("Col" + i.ToString(),
                        i.ToString());
                    Console.WriteLine("Column number: " + i.ToString());
                }

                List<List<string>> dataRows = entry.Value.DataRows;

                /* Bind the dataRows to dataGridView */

                foreach (var row in dataRows)
                {
                    dataGridView.Rows.Add(row.ToArray());
                }

                DataTabs.TabPages.Add(new TabPage(entry.Key));
                DataTabs.TabPages[tab].Controls.Add(dataGridView);
                tab++;
            }
        }

        
        
    }
}
