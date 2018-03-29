using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DFM
{
    /// <summary>
    /// Class for handling data files of several different formats as a
    /// general data object that can be handled in a way mostly independent
    /// of the file extension of the input file. 
    /// </summary>
    class DataObject // Should this extend the Stream abstract class?
    {
        /* Class Variables - Private */

        string fnameStr;
        Stream fStream;
        const int dataSelection = 0; // 0 (1) for all (largest) groups of data
                                     
        List<char> delimiters = new List<char> { ',', ' ', '\t' };
        const bool DEBUG = true;

        /* Class Variables - Public */

        // These capitalized to stick with convention for public propertiers
        public List<List<string>> Columns = new List<List<string>>();
        public string DataString;

        /* Class Methods */

        /// <summary>
        /// The constructor. Initializes object attributes when a DataObject
        /// is instantiated. 
        /// </summary>
        /// <param name="extensionStr"> The input file's extenstion.</param>
        /// <param name="fileStream"> The stream representing the input
        /// file's content. </param>
        public DataObject(string filename, Stream fileStream)
        {
            // Initialize the class variables
            fnameStr = filename;
            fStream = fileStream;
            DataString = GetDataString(GetDataMatrix(fStream,
                delimiters[0]),dataSelection);
        }

        /// <summary>
        /// Converts file stream into a 3D matrix of cells, grouped by file line
        /// and number of delimiters per line. E.g. layer i of the matrix 
        /// might contain rows j holding cells from file lines which had 5 
        /// delimiters, so each row j in layer i has 6 cells. 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private List<List<List<string>>> GetDataMatrix(Stream stream,
            char delimiter)
        {
            /* TODO EVENTUALLY: keep track of delimiters per line. If a line
             * has a different number of delimiters than the previous line, 
             * create a new group (a new layer i in the cellMatrix3D). Also
             * keep track of the largest group (number of lines j in in 
             * layer i). This is the group that is most likely to be the 
             * data we want. 
             */

            // cellMatrix3D[i][j][k] specifies a cell k in line j in group i
            List<List<List<string>>> cellMatrix3D =
                new List<List<List<string>>>();
            // cellMatrix2D is a layer or group i in cellMatrix3D
            List<List<string>> cellMatrix2D = new List<List<string>>();
            List<string> cellRow = new List<string>();
            StreamReader streamer = new StreamReader(stream);
            string line;
            int lineIter = 0;
            int charIter = 1;// So that substring length is never 0
            int lastCharIndex = 0; // 
            int previousDelimiters = 0; // Current delimiter/line for group
            int delimiters = 0; // Counts delimiters in a line

            // Build cellMatrix3D
            while ((line = streamer.ReadLine()) != null)
            {
                // Reinitialize these each iteration of while((line...
                cellRow = new List<string>();
                charIter = 1;// So that substring length is never 0
                lastCharIndex = 0; // 
                delimiters = 0; // Counts delimiters in a line
                
                // Get cells in line; Note: misses last cell if last char is
                // not the specified delimiter
                foreach (char c in line)
                {
                    try
                    {
                        // Store each substring between delimiter pairs
                        if (c == delimiter)
                        {
                            delimiters++;
                            string cell = line.Substring(lastCharIndex,
                                charIter - lastCharIndex - 1);
                            //if (DEBUG) { Console.WriteLine("Cell: "+cell); }
                            cellRow.Add(cell);
                            lastCharIndex = charIter;
                        }
                        charIter++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Woah, error: " + ex);
                    }
                }
                // Get the last cell if we didn't get it above
                if (!line.EndsWith(delimiter.ToString()))
                {
                    string cell = line.Substring(lastCharIndex,
                                charIter - lastCharIndex - 1);
                    cellRow.Add(cell);
                    //if (DEBUG) { Console.WriteLine("Cell: "+cell); }
                }

                // Create new layer in the 3D matrix if delimiters/line changed
                if (delimiters != previousDelimiters)
                {
                    // Create a new layer, except on first iteration
                    if (previousDelimiters > 0)
                    {
                        cellMatrix3D.Add(new List<List<string>>(cellMatrix2D));
                        cellMatrix2D = new List<List<string>>();
                        cellMatrix2D.Add(cellRow);
                    }
                    else { cellMatrix2D.Add(cellRow);  }
                    previousDelimiters = delimiters;
                }
                else
                {
                    // Add the line of cells to the 2D matrix, reset cellRow
                    cellMatrix2D.Add(cellRow);
                }
                lineIter++;
            }
            // The last 2D matrix has to be added to the 3D matrix here:
            cellMatrix3D.Add(new List<List<string>>(cellMatrix2D));
            cellMatrix2D.Clear();

            if (DEBUG)
            {
                string lines = (cellMatrix2D.ToArray()).Count().ToString();
                Console.WriteLine("Lines in output: " + lines);
            }

            return cellMatrix3D;
        }

        /// <summary>
        /// Returns a string of lines of whitespace-delimited cells from a 2D 
        /// cell matrix cellMat2D. Primarily used for debugging purposes. 
        /// </summary>
        /// <param name="cellMat2D"></param>
        /// <returns>String of lines of white space delimited cells from cellMat2D
        /// </returns>
        private string StringFromMatrixLines(List<List<string>> cellMat2D)
        {
            if (DEBUG)
            {
                string cells = cellMat2D[0].ToArray().Count().ToString();
                Console.WriteLine("cells/line: " + cells);
            }
            StringBuilder lines = new StringBuilder();
            try
            {
                foreach (List<string> line in cellMat2D)
                {

                    foreach (string cell in line)
                    {
                        lines.Append(cell + " ");
                    }
                    lines.Append(Environment.NewLine);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("StringFromMatrixLines: " + ex.Message);
            }
            string output = lines.ToString();
            //if (DEBUG) { Console.WriteLine("Lines: " + output); }
            return output;
        }

        /// <summary>
        /// Converts 3D data matrix dataMat3D into a multi-line string.
        /// Primarily used for debugging. 
        /// </summary>
        /// <param name="dataMat3D"></param>
        /// <param name="returnOption"></param>
        /// <returns></returns>
        private string GetDataString(List<List<List<string>>> dataMat3D,
            int returnOption)
        {
            StringBuilder outputStrBldr = new StringBuilder();
            // join groups i w/ lines separated by '\n' ...
            switch (returnOption)
            {
                case 0: // ... for all groups i
                    //string dims = dataMat3D[0].ToArray().Count().ToString();
                    //Console.WriteLine("2D matrix dims: "+dims);
                    foreach (List<List<string>> dataMat2D in dataMat3D)
                    {
                        string layer = StringFromMatrixLines(dataMat2D);
                        outputStrBldr.Append(layer + Environment.NewLine);
                        if (DEBUG) { Console.WriteLine("Layer: "+layer); }
                    }
                    break;
                case 1: // ... for only the largest group i
                    // TODO: later replace '0' w/ largest index i
                    outputStrBldr.Append(StringFromMatrixLines(
                        dataMat3D[0]));
                    break;
            }
            return outputStrBldr.ToString();
        }
        
        private List<List<string>> GetDataColumns(List<List<List<string>>> 
            cellMatrix)
        {
            List<List<string>> dataColumns = new List<List<string>>();
            // code to populate dataColumns here

            return dataColumns;
        }
    }
}
