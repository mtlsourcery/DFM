﻿using System;
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

            //DataGrid.AutoGenerateColumns = true;

            // This will store our data we want to display
            //BindingSource bindSource = new BindingSource
            //{   
            //    // Set the type of data
            //    DataSource = typeof(List<string>)
            //};

            //Console.WriteLine(dataMatrix3D.Count.ToString());

            //foreach (List<List<string>> dataMatrix2D in dataMatrix3D)
            //{
            //    Console.WriteLine("2D level");
            //    foreach(List<string> row in dataMatrix2D)
            //    {
            //        Console.WriteLine("1D level");
            //        DataGrid.Rows.Add(row);
            //    }
            //}

            //DataGrid.DataSource = bindSource;
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
                int maxColNum = entry.Value.MaxColumnsCount;
                for (int i = 0; i < maxColNum; i++)
                {
                    dataGridView.Columns.Add("Column" + i.ToString(), 
                        i.ToString());
                }

                var dataRows = new List<string>()
                {
                    "W",
                    "T",
                    "F"
                }; //entry.Value.DataRows;
                BindingSource dataBindSrc = new BindingSource()
                { DataSource = dataRows };

                dataGridView.DataSource = dataBindSrc;

                //foreach (List<List<string>> layer in dataMatrix)
                //{
                //    foreach (List<string> line in layer)
                //    {

                //        //dataGridView.Rows.Add("M","T","L");
                //        //dataGridView.Rows.Add(ListToDelimitedString(line));
                //        dataGridView.Cell
                //    }
                //}

                DataTabs.TabPages.Add(new TabPage(entry.Key));
                DataTabs.TabPages[tab].Controls.Add(dataGridView);
                tab++;
            }
            
            //string ListToDelimitedString(List<string> wordList)
            //{
            //    StringBuilder strB = new StringBuilder();
            //    foreach (var word in wordList)
            //    {
            //        strB.Append(word.ToString() + ',');
            //    }
            //    string str = strB.ToString();
            //    return str.Substring(0, str.Length - 1); // omit the last comma
            //}
            //this.Size = this.DataTabs.Size;
        }
    }
}
