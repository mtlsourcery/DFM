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

        /// <summary>
        /// The constructor. Initializes object attributes when a DataObject
        /// is instantiated. 
        /// </summary>
        /// <param name="extensionStr"> The input file's extenstion.</param>
        /// <param name="fileStream"> The stream representing the input
        /// file's content. </param>
        public DataObject(Stream fileStream, string filename)
        {
            // Initialize the class variables
            fnameStr = filename;
            fStream = fileStream;
        }
    }
}
