﻿/*
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
 *                || \\//  ||      ||      ||        ==    |||
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
    public class DataObject
    {
        /* Class Constants */

        const bool DEBUG = true;
        public const string HEADER_FLAG = "^.^";

        /* Class Variables - Private */

        // Use one-hump camelFont by convention for private variables
        string fnameStr;
        Stream fStream;
        List<char> delimiters = new List<char> { ',', ' ','\t' };
        bool dataOption;
        bool ignoreWhiteSpace = true; // if we want to omit lines w/ empty cells
        int omittedRows = 0;

        /* Class Variables - Public */

        // Use two-hump CamelFont by convention for public variables

        /// <summary>
        /// True if data columns were found.
        /// </summary>
        public bool HasData = false;

        /// <summary>
        /// True if a header was found.
        /// </summary>
        public bool HasHeader = false;

        /// <summary>
        /// The verbatim contents of the file.
        /// </summary>
        public string FileString;

        /// <summary>
        /// The extracted data in string format.
        /// </summary>
        public string DataString;

        /// <summary>
        /// The largest number of columns/group where groups are sorted by row
        /// count. Note that MaxColumnCount and MaxRowCount refer to different
        /// groups, in general.
        /// </summary>
        public int MaxColumnCount;

        /// <summary>
        /// The largest number of rows/group where groups are sorted by row
        /// count. Note that MaxRowCount and MaxColumnCount refer to different
        /// groups, in general.
        /// </summary>
        public int MaxRowCount;

        /// <summary>
        /// Largest group of data columns by row count, unless dataOption=true.
        /// </summary>
        public List<List<string>> DataColumns = new List<List<string>>();

        /// <summary>
        ///  Largest group of data rows by row count, unless dataOption=true.
        /// </summary>
        public List<List<string>> DataRows = new List<List<string>>();

        /// <summary>
        /// Rows of data grouped by number of columns per row.
        /// </summary>
        public List<List<List<string>>> CellMatrix = new List<List<List<string>>>();

        /// <summary>
        /// Static list of all objects belonging to the class.
        /// </summary>
        public static Dictionary<string, DataObject> ObjectList = 
            new Dictionary<string, DataObject>();

        /* Class Methods */

        /// <summary>
        /// The constructor. Initializes object attributes when a DataObject
        /// is instantiated. 
        /// </summary>
        /// <param name="filename"> The input file's name.</param>
        /// <param name="fileStream"> The stream representing the input
        /// file's content. </param>
        /// <param name="allColumns">True: store all data columns. False:
        /// store only group of data columns with most rows. </param>
        public DataObject(string filename, Stream fileStream, bool allColumns)
        {
            /* Initialize the internal variables */
            fnameStr = filename;
            fStream = fileStream;
            dataOption = allColumns;

            /* Initialize the externally accessible properties */
            CellMatrix = GetDataMatrix(fStream, delimiters[0],ignoreWhiteSpace);
            FileString = GetFileString(fStream);
            DataString = GetDataString(CellMatrix, dataOption);

            // Also sets MaxColumnCount and MaxRowCount
            var rowsNcols = GetRowsAndColumns(CellMatrix,dataOption);
            DataRows = rowsNcols[0];
            DataColumns = rowsNcols[1];
            HasData = (DataColumns.Count > 0);
            HasHeader = CheckForHeader(DataRows);

            // Add this instance to our running list
            ObjectList.Add(fnameStr, this);
            if (DEBUG)
            {
                Console.WriteLine("Object count: " + ObjectList.Count);
            }
        }

        /// <summary>
        /// Returns the contents of the original file as a string assembled from
        /// the file's stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string GetFileString(Stream stream)
        {
            // The stream is kind of like a VHS. You have to rewind it in
            // order to read it from the beginning. 
            stream.Position = 0; 
            StreamReader reader = new StreamReader(stream);
            StringBuilder str = new StringBuilder();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (DEBUG) { Console.WriteLine("Line: " + line); }
                str.Append(line + Environment.NewLine);
            }
            if (DEBUG) { Console.WriteLine("FileString: " + str.ToString()); }
            return str.ToString();
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
            char delimiter,bool removeVacancies)
        {
            /* Could modify this method to:
             * - search for other delimiters; pass in the whole delimiter array?
             * - add overload method for .xlsx files; this will only work w/ .txt
             *      .csv,.rtf and other files which can be read in as text.
             */

            // CellMatrix3D[i][j][k] specifies a cell k in line j in group i
            List<List<List<string>>> CellMatrix3D =
                new List<List<List<string>>>();
            // CellMatrix2D is a layer or group i in CellMatrix3D
            List<List<string>> CellMatrix2D = new List<List<string>>();
            List<string> cellRow = new List<string>();
            // The stream is kind of like a VHS. You have to rewind it in
            // order to read it from the beginning. 
            stream.Position = 0;
            StreamReader streamer = new StreamReader(stream);
            string line;
            int lineIter = 0;
            int charIter = 1;// So that substring length is never 0
            int lastCharIndex = 0; // 
            int previousDelimiters = 0; // Current delimiter/line for group
            int delimiters = 0; // Counts delimiters in a line
            int maxColumns = 0; // Stores the maximum columns/row
            bool skipLine; // determines whether we add a line to the group

            // Build the 3D matrix from lines in the file
            while ((line = streamer.ReadLine()) != null)
            {
                // Reinitialize these each iteration of while((line...
                cellRow = new List<string>();
                charIter = 1;// So that substring length is never 0
                lastCharIndex = 0; // 
                delimiters = 0; // Counts delimiters in a line
                skipLine = false;
                
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
                            if (String.IsNullOrWhiteSpace(cell))
                            { skipLine = true; }
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
                // Increment the omitted rows count if any cells vacant
                if (skipLine)
                    omittedRows++;

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
                        if (!skipLine) // add row if no cells were whitespace
                        {
                            //// Flag the header row, if its a header
                            //CellMatrix2D[0] = GetHeader(CellMatrix2D[0]);
                            // Add the 2D mat to the 3D mat
                            CellMatrix3D.Add(new List<List<string>>(CellMatrix2D));
                            CellMatrix2D = new List<List<string>>();
                            CellMatrix2D.Add(cellRow);
                        }
                    }
                    else
                    {
                        if (!skipLine) // add row if no cells were whitespace
                            CellMatrix2D.Add(cellRow);
                    }
                    previousDelimiters = delimiters;
                }
                else // Add the line of cells to the 2D matrix, reset cellRow
                {   if (!skipLine)
                    {   // add row if no cells were whitespace
                        CellMatrix2D.Add(cellRow); 
                    }
                }
                if (cellRow.Count > maxColumns)
                { maxColumns = cellRow.Count; }
                lineIter++;
            }
            // The last 2D matrix has to be added to the 3D matrix here:
            //CellMatrix2D[0] = GetHeader(CellMatrix2D[0]);
            CellMatrix3D.Add(new List<List<string>>(CellMatrix2D));
            CellMatrix2D.Clear();
            if (DEBUG)
            {
                string lines = (CellMatrix3D.ToArray()).Count().ToString();
                Console.WriteLine("Lines in output: " + lines);
                Console.WriteLine("Omitted lines: " + omittedRows);
            }
            MaxColumnCount = maxColumns;
            return CellMatrix3D;
        }

        /// <summary>
        /// Returns a string of lines of whitespace-delimited cells from a 2D 
        /// cell matrix cellMat2D. Primarily used in WriteNewCSVFile. 
        /// </summary>
        /// <param name="cellMat2D"></param>
        /// <returns>String of lines of white space delimited cells from cellMat2D
        /// </returns>
        private string StringFrom2DMatrix(List<List<string>> cellMat2D)
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
                        lines.Append(cell + ",");
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
        /// Returns the 2D matrix from the input 3D which contains lines of data
        /// with the most lines. E.g., if layer 0 has 3 lines of 5 cells each, 
        /// and layer 1 has 2 lines of 7 cells each, this would return layer 0.
        /// </summary>
        /// <param name="dataMat3D"></param>
        /// <returns></returns>
        private List<List<string>> GetDesired2DMatrix(List<List<List<string>>> 
            dataMat3D)
        {
            // Assume that the group with the most lines is the data
            // we're looking for #TheseAreTheDataYou'reLookingFor
            int iMax = 0;
            int lastMax = 0;
            for (int i = 0; i < dataMat3D.Count(); i++)
            {   // Count the lines in line 0 of group i
                if (dataMat3D[i].Count() > lastMax)
                { lastMax = dataMat3D[i].Count(); iMax = i; }
            }
            return dataMat3D[iMax];
        }

        /// <summary>
        /// Converts 3D data matrix dataMat3D into a multi-line string. The
        /// cells in 3D matrix are white space delimited, and newlines are
        /// inserted between string lists. Primarily used for debugging. 
        /// </summary>
        /// <param name="cellMat3D"></param>
        /// <param name="returnOption"></param>
        /// <returns></returns>
        private string GetDataString(List<List<List<string>>> cellMat3D,
            bool returnOption)
        {
            StringBuilder outputStrBldr = new StringBuilder();
            switch (returnOption)
            {
                case false: // return only the largest group
                    outputStrBldr.Append(StringFrom2DMatrix(
                        GetDesired2DMatrix(cellMat3D)));
                    break;
                case true: // return all groups i separated by '\n'
                    foreach (List<List<string>> dataMat2D in cellMat3D)
                    {
                        string layer = StringFrom2DMatrix(dataMat2D);
                        outputStrBldr.Append(layer + Environment.NewLine);
                        if (DEBUG) { Console.WriteLine("Layer: " + layer); }
                    }
                    break;
            }
            if (DEBUG) { Console.WriteLine("DataString: " + 
                outputStrBldr.ToString()); }
            return outputStrBldr.ToString();
        }
        
        /// <summary>
        /// Generates a list of the columns of data, each of which is a list of
        /// strings, from the 2D layer(s) in CellMatrix. Note that this function
        /// can be thought of as transposing the layers of the input matrix: the 
        /// input string lists are rows, the output string lists are columns. 
        /// </summary>
        /// <param name="cellMat3D"></param>
        /// <param name="returnOption"></param>
        /// <returns></returns>
        private List<List<string>>[] GetRowsAndColumns(List<List<List<string>>> 
            cellMat3D, bool returnOption)
        {
            List<List<string>> dataColumns = new List<List<string>>();
            List<List<string>> dataRows = new List<List<string>>();
            List<string> dataColumn = new List<string>();
            int count = cellMat3D.Count;
            int cellCount;      // Cells/line
            int lineCount;      // Lines/layer
            int iMax = 0;       // Index of largest layer of CellMatrix
            int maxCount = 0;   // Number of rows in iMax layer

            for (int i = 0; i < count; i++)
            {
                if (cellMat3D[i].Count > maxCount)
                { iMax = i; maxCount = cellMat3D[i].Count; }

                if (DEBUG)
                {
                    Console.WriteLine("layer count " +
                        cellMat3D[i].Count);
                    Console.WriteLine("Max: " + iMax.ToString());
                }
            }

            // Get the row and column count for the largest group (by rows
            MaxRowCount = maxCount; 

            switch (returnOption)
            {
                case false: // Return only the largest group of columns

                    var cellLayer = cellMat3D[iMax];
                    lineCount = cellLayer.Count; // Lines in max layer
                    cellCount = cellLayer[0].Count; // Cells/line

                    // Rows of CellMatrix[iMax] => columns of dataColumns
                    for (int j = 0; j < cellCount; j++)
                    {
                        for (int i = 0; i < lineCount; i++)
                        {
                            dataColumn.Add(cellLayer[i][j]);
                            if (DEBUG) { Console.WriteLine("i,j= " + i + "," + j); }
                        }
                        // Note: a new List is added, because Add() creates
                        // a pointer to the dataColumn, which overwrite later
                        dataColumns.Add(new List<string>(dataColumn));
                        dataColumn.Clear();
                    }

                    // The rows of the largest group
                    dataRows = cellMat3D[iMax];

                    break;
                case true: // Return all groups of columns as a single layer
                    foreach (var layer in cellMat3D)
                    {
                        lineCount = layer.Count; // lines in this layer
                        cellCount = layer[0].Count; // cells/line in this layer
                        if (DEBUG) { Console.WriteLine("lines,cells: " + 
                            lineCount + "," + cellCount); }

                        for (int j = 0; j < cellCount; j++)
                        {
                            for (int i = 0; i < lineCount; i++)
                            {
                                dataColumn.Add(layer[i][j]);
                                if (DEBUG) { Console.WriteLine("i,j= " + i + 
                                    "," + j); }
                            }
                            dataColumns.Add(new List<string>(dataColumn));
                            dataColumn.Clear();
                        }
                    }
                    // Concatenate all of the groups of rows into a single layer
                    foreach (List<List<string>> cellMat2D in cellMat3D)
                    {
                        dataRows.AddRange(cellMat2D);
                    }
                    break;
            }
            // An array of type List<List<string>> containing the rows and cols
            return new List<List<string>>[] { dataRows, dataColumns };
        }

        /// <summary>
        /// Checks the zeroth row of dataRow for non-numeric values, which would 
        /// indicate a header in a set of numeric data. Note that this may return
        /// false when dataRows is a concatenation of all row groups (i.e. when
        /// dataOption=true), as it only checks the zeroth row.
        /// </summary>
        /// <param name="dataRows"></param>
        /// <returns></returns>
        private bool CheckForHeader(List<List<string>> dataRows)
        {
            bool hasHeader = false;
            // Try to parse the (0,0)th cell as a double
            if (!double.TryParse(dataRows[0][0], out double number))
                hasHeader = true;
            return hasHeader;
        }
    }
}
