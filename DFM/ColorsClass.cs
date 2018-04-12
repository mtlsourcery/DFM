using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFM
{
    class ColorsClass
    {
        public int R = 0;
        int G;
        int B;
        int a;

        /// <summary>
        /// The constructor for ColorsClass
        /// </summary>
        public ColorsClass(int red, int green, int blue, int saturation)
        {
            R = red;
            G = green;
            B = blue;
            a = saturation;
        }

        public void AddHues(int hue)
        {

        }

        public static List<string> GetMaxRGB()
        {
            List<string> rgbList = new List<string>();
            return rgbList;
        }

        void Brightness()
        {

        }
    }
}
