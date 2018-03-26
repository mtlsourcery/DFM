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
        /* Class Variables */

        string fnameStr;
        Stream fStream;
        List<char> delimiters = new List<char> { ',', ' ', '\t' };
        const bool DEBUG = true;

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
                delimiters[0]),0);
        }

        /// <summary>
        /// Returns a string of lines of whitespace-delimited cells from cellMat
        /// </summary>
        /// <param name="cellMat"></param>
        /// <returns>String of lines of white space delimited cells from cellMat
        /// </returns>
        private string StringFromMatrixLines(List<List<string>> cellMat)
        {
            StringBuilder lines = new StringBuilder();
            foreach (List<string> line in cellMat)
            {
                foreach (string cell in line)
                { lines.Append(cell + " "); }
                lines.Append("\n");
            }
            return lines.ToString();
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
            // cellMatrix[i][j][k] specifies a cell k in line j in group i
            List<List<List<string>>> cellMatrix3D =
                new List<List<List<string>>>();
            List<List<string>> cellMatrix2D = new List<List<string>>();
            List<string> cellRow = new List<string>();
            string line;

            using (StreamReader streamer = new StreamReader(stream))
            {
                // Build cellMatrix3D
                int charIter = 1;// so substring length is never 0
                int lastIndex = 0;

                while ((line = streamer.ReadLine()) != null)
                {
                    foreach (char c in line)
                    {
                        try
                        {
                            // Store each substring between delimiter pairs
                            if (c == delimiter || c == '\n')
                            {
                                cellRow.Add(line.Substring(lastIndex,
                                    charIter - lastIndex));
                                lastIndex = charIter;
                            }
                            charIter++;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Woah, error: " + ex);
                        }
                    }
                    // Add the line of cells to the 2D matrix, reset cellRow
                    cellMatrix2D.Add(cellRow);
                    cellRow.Clear();
                }
                // Add the layer of rows to the 3D matrix, reset cellMatrix2D
                cellMatrix3D.Add(cellMatrix2D);
                //cellMatrix2D.Clear();
            }
            if (DEBUG)
            {
                string lines = (cellMatrix2D.ToArray()).Count().ToString();
                Console.WriteLine("Lines in output: " + lines);
            }

            return cellMatrix3D;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataMatrix"></param>
        /// <param name="returnOption"></param>
        /// <returns></returns>
        private string GetDataString(List<List<List<string>>> dataMatrix,
            int returnOption)
        {
            StringBuilder outputStrBldr = new StringBuilder();
            // join groups i w/ lines separated by '\n' ...
            switch (returnOption)
            {
                case 0: // ... for all groups i
                    foreach (List<List<string>> lines in dataMatrix)
                    { outputStrBldr.Append(StringFromMatrixLines(lines)); }
                    break;
                case 1: // ... for only the largest group i
                    // TODO: later replace '0' w/ largest index i
                    outputStrBldr.Append(StringFromMatrixLines(
                        dataMatrix[0]));
                    break;
            }
            return outputStrBldr.ToString();
        }
        
        private List<List<string>> GetDataColumns(List<List<List<string>>> cellMatrix)
        {
            List<List<string>> dataColumns = new List<List<string>>();
            // code to populate dataColumns here

            return dataColumns;
        }
    }
}
