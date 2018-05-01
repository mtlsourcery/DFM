using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace DFM
{
    /// <summary>
    /// The main application Window 
    /// </summary>
    public partial class MainForm : Form
    {
        /* Class Constants */
        const bool DEBUG = true;
        const string DEFAULT_BROWSE_DIR = @"C:\";
        const string DEFAULT_SAVE_DIR = @"C:\";

        /* Class Variables - Private */

        bool allColumns; // true (false): retrieve all (only the largest group by
                         // row count) of data columns in a file

        // The default browsing  and save directories saved in settings
        string initialDir = Properties.Settings.Default.BrowseDirectory;
        string saveDir = Properties.Settings.Default.SaveDirectory;

        // The message handler
        MessageHandler msgHandler = new MessageHandler();

        /* Class Methods */

        /* Class Methods - Miscellaneous */ 
        
        /// <summary>
        /// The constructor for MainForm.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.FilenameBox.Text = "MTLX_LabFile" +
                DateTime.Now.ToString().Replace('/', '_').Replace(' ', '_');
            this.SaveDirTextBox.Text = saveDir;
            this.Icon = Icon.FromHandle(Properties.Resources.mtlapplogo.GetHicon());
        }

        // REMOVE LATER; PEDANTIC ONLY
        ColorsClass newColor = new ColorsClass(0, 255, 0, 100);
        List<string> rgbVals = ColorsClass.GetMaxRGB();

        /// <summary>
        /// Prints the keys in myFiles to the Output Console. Used for debugging
        /// purposes only.
        /// </summary>
        private void PrintDictionary()
        {
            StringBuilder str = new StringBuilder();
            str.Append("(");

            foreach (var file in DataObject.ObjectList)
            { str.Append(" " + file.Key); }
            str.Append(" )");
            Console.WriteLine(str.ToString());
        }

        /// <summary>
        /// Returns the text contained in a Stream stream. TODO: amend this to 
        /// handle RTF, CSV, XLSX, etc Streams.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private string StringFromStream(Stream stream)
        {
            StreamReader streamReader = new StreamReader(stream);
            string text = streamReader.ReadToEnd();
            return text;
        }

        /// <summary>
        /// For debugging
        /// </summary>
        /// <param name="list"></param>
        void PrintList(List<string> list)
        {
            foreach (string s in list)
            {
                Console.Write(s + ",");
            }
            Console.Write(Environment.NewLine);
        }

        /// <summary>
        /// Write a new Excel (.xlsx) file from dataObjects. 
        /// </summary>
        /// <param name="dataObjects"></param>
        private void WriteNewExcelFile(Dictionary<string, DataObject>
            dataObjects)
        {
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                msgHandler.ShowMessage("MS Excel installation not found."
                    + Environment.NewLine + "Can not write spreadsheet.", 0);
                return;
            }

            // Set the save directory and output filename
            string saveStr = SaveDirTextBox.Text + FilenameBox.Text + ".xlsx";

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            var format = Excel.XlFileFormat.xlOpenXMLWorkbook;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            // Populate the worksheet with data from the files
            int lastCol = 0;
            foreach (var entry in dataObjects)
            {
                var dataObject = entry.Value;
                try
                {
                    if (dataObject.HasData)
                    {
                        for (int j = 0; j < dataObject.DataColumns.Count; j++)
                        {
                            for (int i = 0; i < dataObject.DataColumns[j].Count; i++)
                            {
                                // Note that Excel cells use 1-based indexing
                                xlWorkSheet.Cells[i + 1, j + 1 + lastCol] =
                                    dataObject.DataColumns[j][i].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    msgHandler.ShowException(ex);
                }
                lastCol += dataObject.DataColumns.Count;
            }
            try
            {
                xlWorkBook.SaveAs(saveStr, format, misValue, misValue, misValue,
               misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue,
               misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }
            catch (Exception ex)
            {
                msgHandler.ShowException(ex);
            }

            // Release these objects from memory 
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }

        /// <summary>
        /// Writes a new CSV (.csv) file from dataObjects.
        /// </summary>
        /// <param name="dataObjects"></param>
        private void WriteNewCSVFile(Dictionary<string, DataObject>
            dataObjects)
        {
            // Set the save directory and output filename
            string saveStr = SaveDirTextBox.Text + FilenameBox.Text + ".csv";
            StreamWriter csvWriter = new StreamWriter(saveStr); //-- Do we need a StreamWriter?

            // Populate the worksheet with data from the files
            int tab = 0;
            foreach (var entry in dataObjects)
            {
                var dataObject = entry.Value;
                try
                {
                    if (dataObject.HasData)
                    {
                        int maxColNum = entry.Value.MaxColumnCount;
                        List<List<string>> dataRows = entry.Value.DataRows;
                        for (int i = 0; i < maxColNum; i++)
                        {
                            List<string> dataRow = dataRows[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Code to go here
                }
            }
            try
            {
                //code here
            }
            catch (Exception ex)
            {
                msgHandler.ShowException(ex);
            }
        }

        /* Class Event Handlers */

        /// <summary>
        /// Handles AddFileButton click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFileButton_Click(object sender, EventArgs e)
        {
            // Initialize a Stream to read in data from files
            Stream fileStream;
            string filename;

            // Displays the file selection window and stores the result
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                // The @'s force the compiler to ignore escape sequences, e.g. 
                // '\' does not have to be typed '\\'

                //InitialDirectory = @"C:\Users\Preston Huft\Documents\Visual " +
                //@"Studio 2017\Projects\DFM\DFM",
                InitialDirectory = initialDir,
                Filter = "txt files (*.txt)|*.txt|csv files " +
                "(*.csv)|*.csv|xlsx files (*.xlsx)|.xlsx|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            // Try to open the file selection dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Check if the selected file is null
                    if ((fileStream = openFileDialog.OpenFile()) != null)
                    {
                        // Get the filename
                        filename = openFileDialog.SafeFileName;

                        // Create new dataObject. Notice that we don't have to
                        // assign new objects to a variables. We can access this
                        // by its filename: DataObject.ObjectList[filename]
                        new DataObject(filename, fileStream, allColumns);

                        // List the file's data in DataListBox
                        var dataObj = DataObject.ObjectList[filename];
                        string item = filename + " (" +
                            dataObj.DataColumns.Count.ToString() +
                            " Columns)";
                        DataListBox.Items.Add(item);

                        // Add filename to FileListBox
                        FileListBox.Items.Add(filename);

                        if (DEBUG) { PrintDictionary(); }
                    }
                }
                catch (Exception ex)
                {
                    msgHandler.ShowException(ex);
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
                    var selectedDir = folderBrowserDialog.SelectedPath;
                    if (selectedDir != null)
                    {
                        // Display the name of the selected directory
                        SaveDirTextBox.Text = selectedDir;

                        string msg = "Set " + selectedDir +
                            Environment.NewLine +
                            " as the default save directory?";
                        //if(msgHandler.ShowBinaryOptions(msg) == DialogResult.Yes)
                        //{
                        //    // Update the save directory string and Settings.settings
                        //    saveDir = selectedDir.ToString();
                        //    Properties.Settings.Default.SaveDirectory = saveDir;
                        //    Properties.Settings.Default.Save();
                        //}
                    }
                }
                catch (Exception ex)
                {
                    msgHandler.ShowException(ex);
                }
            }
        }

        /// <summary>
        /// Handles RemoveFileButton click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFileButton_Click(object sender, EventArgs e)
        {
            var selection = FileListBox.SelectedItems;
            if (selection.Count > 0)
            {
                try
                {
                    int count = FileListBox.Items.Count;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        // True if ith item in FileListBox is selected
                        if (FileListBox.GetSelected(i))
                        {
                            // The selection indices are not the same as the
                            // ListBox indices; just pop off the first item
                            DataObject.ObjectList.Remove(
                                selection[0].ToString());
                            FileListBox.Items.RemoveAt(i);
                            DataListBox.Items.RemoveAt(i);
                        }
                    }
                    if (DEBUG) { PrintDictionary(); }
                }
                catch (Exception ex)
                {
                    msgHandler.ShowException(ex);
                }
            }
            else { msgHandler.ShowMessage("Please select a file.", 0); }
        }

        /// <summary>
        /// Handles PreviewFileButton click event. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreviewFileButton_Click(object sender, EventArgs e)
        {
            var selection = this.FileListBox.SelectedItems;
            if (selection.Count != 0)
            {
                try
                {
                    // Remove the selection from myFiles
                    foreach (var item in selection)
                    {
                        // Get the file content associated with item.ToString()

                        string contentString = 
                          DataObject.ObjectList[item.ToString()].FileString;
                        // Instantiate a FilePreviewForm
                        FilePreviewForm filePreviewForm = new FilePreviewForm(
                            contentString)
                        {
                            // Set the form's upper-lefthand corner text
                            Text = "Preview - " + item.ToString(),
                        };
                        // Show the form
                        filePreviewForm.Show();
                    }
                    if (DEBUG) { Console.WriteLine("FilePreviewForm opened"); }
                }
                catch (Exception ex)
                {
                    msgHandler.ShowException(ex);
                }
            }
            else
            {
                msgHandler.ShowMessage("Please select at least one file.", 0);
            }
        }

        /// <summary>
        /// Handles ViewDataButton click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataObject.ObjectList.Count > 0)
                {
                    ViewDataForm viewDataForm = new ViewDataForm(DataObject.ObjectList);
                    viewDataForm.Show();
                }
                else
                { msgHandler.ShowMessage("No data to view. Add files.", 0); }
            }
            catch (Exception ex)
            {
                msgHandler.ShowException(ex);
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
            // and putting into a "nicer" file; e.g. populating a lab analysis
            // certificate, plotting stuff, putting all rows into a spreadsheet
            // etc. then save the output to the specified directory. 

            /* Psuedo code blueprint for the intended functionality
             * 
             * foreach (var checkBox in checkBoxContainer)
             * {
             *     if (checkBox.checked)
             *     {
             *         // run the specified task with each file we have,
             *         // e.g. merge each file's columns into a csv file
             *         string outputName = FilenameBox.text;
             *         checkBox.associatedMethod(DataOjbects.ObjectList,
             *                                   outputName)
             *     }
             * }
             * 
             */

            if (DataObject.ObjectList.Count > 0)
            {
                if (Excel_ChBox.Checked)
                { WriteNewExcelFile(DataObject.ObjectList); }
                if (CSV_ChBox.Checked)
                { WriteNewCSVFile(DataObject.ObjectList); }
                //if (otherChBox.Checked)...
            }
            else
            {
                msgHandler.ShowMessage("No files to process." +
                    Environment.NewLine + "Please add files.", 0);
            }

            //// Test the DataObject class - DEBUGGING PURPOSES ONLY
            //var selection = FileListBox.SelectedItems;
            //if (selection.Count == 1)// later: if(Count > 0){foreach(item in selection)...
            //{
            //    try
            //    {
            //        if (DEBUG)
            //        {
            //            string dataStr = 
            //                DataObject.ObjectList[selection[0].ToString()].FileString;

            //            FilePreviewForm dataForm = new FilePreviewForm(dataStr);
            //            Console.WriteLine("Test data output string:" +
            //                Environment.NewLine + dataStr);
            //            dataForm.Show();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        msgHandler.ShowException(ex);
            //    }
            //}
        }

        /// <summary>
        /// The click handler for ClearFilesButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearAllFilesButton_Click(object sender, EventArgs e)
        {
            // Clear all of the items in the file list box and the objects they
            // Represent in DataObjects.ObjectList

            var items = FileListBox.Items;
            if (items.Count > 0)
            {
                try
                {
                    int count = items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        DataObject.ObjectList.Remove(items[0].ToString());
                        items.RemoveAt(0);
                        DataListBox.Items.RemoveAt(0);
                    }
                    if (DEBUG) { PrintDictionary(); }
                }
                catch (Exception ex)
                {
                    msgHandler.ShowException(ex);
                }
            }
        }

        /// <summary>
        /// The click handler for the Settings Menu Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuSettings_Click(object sender, EventArgs e)
        {
            // Do something here, e.g. open a settings Form that allows the user
            // to change things like default save directory or background color.
            // These settings are then saved to the Settings.settings file.
        }

        /// <summary>
        /// The click handler for the Help Menu Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuHelp_Click(object sender, EventArgs e)
        {
            // Do something here, e.g. open a help file (in a Form functionally
            // identical to FilePreviewForm?)

            // Stand-in code (can edit later):
            Stream fStream =
                Assembly.GetExecutingAssembly().GetManifestResourceStream(
                   "DFM.Text.HelpFile.txt");
            if (fStream != null)
            {
                string fString = DataObject.GetFileString(fStream);
                FilePreviewForm helpForm = new FilePreviewForm(fString);
                helpForm.Show();
            }
            else
                Console.WriteLine("Why is the file null?");
        }
    }
}
    
