/*
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
using System.Drawing;

namespace DFM
{
    /// <summary>
    /// Provides a set of themes which can be apply via MainForms.LoadTheme
    /// to change color and/or style of Form Controls. 
    /// </summary>
    public class FormThemes
    {
        //// Create the themes here. Wow such recursive. Much self-referential. 
        //// Very meta. #Doge # Hofstadter #GEB
        //public FormThemes StealthMint = new FormThemes();
        //public FormThemes Chipotle = new FormThemes();
        //public FormThemes LinuxMintCinnamon = new FormThemes();
        //public FormThemes ClassicHacker = new FormThemes();
        //public FormThemes TronLegacy = new FormThemes();

        /* Instance Properties */
        public Color FormFillColor = new Color();
        public Color FormBorderColor = new Color();
        public Color ReadOnlyTextColor = new Color();
        public Color EditableTextColor = new Color();
        public Color ButtonFillColor = new Color();
        public Color ButtonBorderColor = new Color();

        /// <summary>
        /// The constructor.
        /// </summary>
        public FormThemes(Color formFillColor, Color formBorderColor, 
            Color rTextColor, Color rwTextColor, Color buttonFillColor,
            Color buttonBorderColor)
        {
            FormFillColor = formFillColor;
            FormBorderColor = formBorderColor;
            ReadOnlyTextColor = rTextColor;
            EditableTextColor = rwTextColor;
            ButtonFillColor = buttonFillColor;
            ButtonBorderColor = buttonBorderColor;
        }
    }
}
