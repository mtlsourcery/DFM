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

        // This is capitalized to stick with convention for public propertiers
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
        /// Returns a string of lines of whitespace-delimited cells from a 2D 
        /// cell matrix cellMat2D. 
        /// </summary>
        /// <param name="cellMat2D"></param>
        /// <returns>String of lines of white space delimited cells from cellMat2D
        /// </returns>
        private string StringFromMatrixLines(List<List<string>> cellMat2D)
        {
            string cells = cellMat2D[0].ToArray().Count().ToString();
            if (DEBUG) { Console.WriteLine("cells/line: " + cells); }
            StringBuilder lines = new StringBuilder();
            foreach (List<string> line in cellMat2D)
            {
                // FIX: there are no cells in each line!!!
                foreach (string cell in line)
                { lines.Append(cell + " ");
                    if (DEBUG) { Console.WriteLine("Wtf bro"); }
                }
                lines.Append("\n");
            }
            string output = lines.ToString();
            if (DEBUG) { Console.WriteLine("Lines: " + output); }
            return output;
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

            // cellMatrix[i][j][k] specifies a cell k in line j in group i
            List<List<List<string>>> cellMatrix3D =
                new List<List<List<string>>>();
            List<List<string>> cellMatrix2D = new List<List<string>>();
            string line;

            StreamReader streamer = new StreamReader(stream);
            
            int lineIter = 0;

            // Build cellMatrix3D
            while ((line = streamer.ReadLine()) != null)
            {
                List<string> cellRow = new List<string>();
                int charIter = 1;// so substring length is never 0
                int lastIndex = 0;

                // Get cells in line; Note: misses last cell if last char is
                // not the specified delimiter
                foreach (char c in line)
                {
                    try
                    {
                        // Store each substring between delimiter pairs
                        if (c == delimiter)
                        {
                            string cell = line.Substring(lastIndex,
                                charIter - lastIndex - 1);
                            //if (DEBUG) { Console.WriteLine("Cell: "+cell); }
                            cellRow.Add(cell);
                            lastIndex = charIter;
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
                    string cell = line.Substring(lastIndex,
                                charIter - lastIndex - 1);
                    //if (DEBUG) { Console.WriteLine("Cell: "+cell); }
                    cellRow.Add(cell);
                }

                // Add the line of cells to the 2D matrix, reset cellRow
                cellMatrix2D.Add(cellRow);

                //cellRow.Clear();
                if (DEBUG)
                {
                    string cellCnt = cellMatrix2D[lineIter].Count.ToString();
                    Console.WriteLine(cellCnt);
                    foreach(var cell in cellMatrix2D[lineIter])
                    { Console.WriteLine("Cell: " + cell); }
                    //string dims = cellMatrix2D[lineIter].ToArray().Count().ToString();
                    //Console.WriteLine("Cells/line: " + dims);
                }
                lineIter++;
            }
            // Add the group of lines to the 3D matrix, reset cellMatrix2D
            cellMatrix3D.Add(cellMatrix2D);
            //cellMatrix2D.Clear();
            
            if (DEBUG)
            {
                string lines = (cellMatrix2D.ToArray()).Count().ToString();
                Console.WriteLine("Lines in output: " + lines);
            }

            return cellMatrix3D;
        }

        /// <summary>
        /// Converts 3D data matrix dataMat3D into a multi-line string. 
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
                    foreach (List<List<string>> lines in dataMat3D)
                    {
                        string layer = StringFromMatrixLines(lines);
                        outputStrBldr.Append(layer);
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
