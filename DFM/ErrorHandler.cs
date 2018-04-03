using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace DFM
{
    class ErrorHandler
    {
        /* Class Variables */

        const string URL_STRING =
            "http://thecatapi.com/api/images/get?format=xml&results_per_page=";
        List<string> imageURLs = new List<string>();
        const string DEFAULT_IMAGE_FILE = @"C:\Users\Preston Huft\Documents\" +
            @"Visual Studio 2017\Projects\DFM\DFM\grumpycat.jpg";
        const bool DEBUG = true;
        const int side = 200;
        Image defaultImage = ResizeImage(Image.FromFile(DEFAULT_IMAGE_FILE),
            side, side);
         

        /* Class Methods */

        /// <summary>
        /// The constructor.
        /// </summary>
        public ErrorHandler()
        {
            //imageURLs = GetImageURLs(URL_STRING,20);
        }

        /// <summary>
        /// Extracts urls with image data from the xml data at the specified url. 
        /// </summary>
        /// <param name="url_string">The url string, minus the number of images</param>
        /// <param name="number">Specifies desired number of image urls.</param>
        /// <returns></returns>
        private List<string> GetImageURLs(string url_string, int number)
        {
            List<string> urlList = new List<string>();
            bool isURL = false;
            XmlTextReader reader = new XmlTextReader(url_string+number.ToString());
            while (reader.Read())
            {
                // Read through the accessed xml and find the image data
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if (reader.Name == "url")
                        { isURL = true; }
                        break;
                    case XmlNodeType.Text:
                        if (isURL)
                        {
                            if (DEBUG)
                            {
                                Console.WriteLine("url:" +
                       reader.Value);
                            }
                            urlList.Add(reader.Value);
                            isURL = false;
                        }
                        break;
                }
            }
            return urlList;
        }

        /// <summary>
        /// Gets an image from the specified url. This should be called within
        /// a try/catch block to handle failures. 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private Image GetImageFromURL(string url)
        {
            // Request the data from url and create an image from the stream
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            Image image = Image.FromStream(stream);
            stream.Close();
            return image;
        }

        /// <summary>
        /// Resizes the image to the specified width and height. This method 
        /// copy/pasted from 
        /// https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, 
                image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, 
                        image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }

        /// <summary>
        /// Displays a MessageBox with the specified msg and/or exception. The
        /// label.Image property is assigned a random cat image. 
        /// </summary>
        /// <param name="msg">The message to be displayed.</param>
        /// <param name="option">Default image (0) or random image (1).</param>
        public void ShowMessage(string msg, int option)
        {
            //string labelStr = "Oops! Something went wrong...";
            Image image = defaultImage;
            if (DEBUG)
            {
                Console.WriteLine("h=" + image.Height.ToString() +
                    ",w=" + image.Width.ToString());
            }
            if (!(option == 0))
            {
                try // Create/show an ErrorHandlingForm
                {
                    Random rand = new Random();
                    int rInt = rand.Next(0, 19);
                    //Image randImage = GetImageFromURL(imageURLs[rInt]);
                    Image newImage = GetImageFromURL(GetImageURLs(URL_STRING, 
                        1)[0]);
                    image = ResizeImage(newImage,side,side);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ErrorHandler: " + ex.Message);
                }
            }
            ErrorHandlingForm form = new ErrorHandlingForm(msg, image);
            form.Show();
        }

        /// <summary>
        /// Calls ShowMessage with a string formed from the exception details. A
        /// random image is specified rather the default one. Simplifies showing
        /// exception messages.
        /// </summary>
        /// <param name="exception">The exception thrown.</param>
        public void ShowException(Exception exception)
        {
            string errorStr = "Error: " + exception.Message + Environment.NewLine
                + "from " + exception.Source;
            ShowMessage(errorStr, 1); 
        }
    }
}
