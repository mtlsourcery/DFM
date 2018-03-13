using System;
using System.IO;
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
    /// <summary>
    /// The main application Window 
    /// </summary>
    public partial class MainForm : Form
    {
        // Class variables
        

        /// <summary>
        /// The constructor for MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles FileOpenButton click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            // Initialize a Stream to read in data from files
            Stream myStream = null;

            // Displays the file selection window and stores the result
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set initial parameters for our OpenFileDialog
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|csv files " +
                "(*.csv)|*.csv|xlsx files (*.xlsx)|.xlsx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true; 

            // Try to open the file selection dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Check if the selected is null
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Display the name of the selected file
                            FilenameTBox.Text = openFileDialog.SafeFileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. " +
                        "Original error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Handles SaveDirButton click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDirButton_Click(object sender, EventArgs e)
        {
            // Displays directory selection window and stores the result
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            // Set the help text description for folderBrowserDialog
            folderBrowserDialog.Description = "Select the save directory for " +
                "the output file(s).";

            // Set default directory
            //folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyDocuments;

            // Try to open the folder selection dialog
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (folderBrowserDialog.SelectedPath != null)
                    {
                        // Display the name of the selected directory
                        SaveDirTBox.Text = folderBrowserDialog.SelectedPath;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. " +
                        "Original error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Handles ProcessButton click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessButton_Click(object sender, EventArgs e)
        {
            // Do the processing of selected file (extracting csv rows, cols,
            // and putting into a "nicer" file; populating a lab analysis 
            // certificate; plotting stuff; etc. then save the output to 
            // the specified directory. 

            //TODO: put check boxes in MainForm to select what processing tasks
            // to perform
        }
    }
}
