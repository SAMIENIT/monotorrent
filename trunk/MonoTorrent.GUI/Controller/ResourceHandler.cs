using System;
using System.Text;
using System.Resources;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace Utilities
{
    /// <summary>
    /// Get resource objects from the project's resource file
    /// </summary>
    static class ResourceHandler
    {
        private static ResourceManager rm = new ResourceManager("MonoTorrent.GUI.Properties.Resources"
                , System.Reflection.Assembly.GetExecutingAssembly());

        /// <summary>
        /// Gets an image or an icon from the resource file
        /// </summary>
        /// <param name="name">Resource file name of the image or icon</param>
        /// <returns>Image</returns>
        public static Image GetImage(string name)
        {
            Image img;
            object resObj = rm.GetObject(name);
            switch (resObj.GetType().Name.ToLower())
            {
                case "icon":
                    Icon ico = (Icon)resObj;
                    img = (Image)ico.ToBitmap();
                    break;
                default:
                    img = (Image)rm.GetObject(name);
                    break;

            }
            return img;
        }

        /// <summary>
        /// Gets an image or an icon from the resource file
        /// </summary>
        /// <param name="name">Resource file name of the image or icon</param>
        /// <param name="width">Width of the image to return</param>
        /// <param name="height">Height of the image to return</param>
        /// <returns>Image</returns>
        public static Image GetImage(string name, int width, int height)
        {
            Bitmap bmp;
            object resObj = rm.GetObject(name);
            if (resObj.GetType().Name.ToLower() == "icon")
                bmp = GetIcon(name, width, height).ToBitmap();
            else
                bmp = (Bitmap)GetImage(name);

            // Image is resized to specified width and height
            Bitmap retBmp = new Bitmap(width, height);
            Graphics grs = Graphics.FromImage((Image)retBmp);
            grs.DrawImage(bmp, 0, 0, width, height);
            return (Image)retBmp;
        }

        /// <summary>
        /// Gets an image or an icon from the resource file
        /// </summary>
        /// <param name="name">Resource file name of the image or icon</param>
        /// <returns>Icon</returns>
        public static Icon GetIcon(string name)
        {
            Icon ico;
            object resObj = rm.GetObject(name);
            switch (resObj.GetType().Name.ToLower())
            {
                case "bitmap":
                    Bitmap bmp = (Bitmap)resObj;
                    ico = Icon.FromHandle(bmp.GetHicon());
                    break;
                default:
                    // By default, VS shows only the 32 x 32 version
                    // Use overloaded GetIcon with width and height to get a specific icon
                    ico = (Icon)rm.GetObject(name);
                    break;

            }
            return ico;

        }

        /// <summary>
        /// Gets an image or an icon from the resource file
        /// </summary>
        /// <param name="name">Resource file name of the image or icon</param>
        /// <param name="width">Width of the icon to return</param>
        /// <param name="height">Height of the icon to return</param>
        /// <returns>Icon</returns>
        public static Icon GetIcon(string name, int width, int height)
        {
            Icon ico = new Icon(GetIcon(name), width, height);
            return ico;
        }

        /// <summary>
        /// Gets a string from the resource file
        /// </summary>
        /// <param name="name">Resource file name of the string</param>
        /// <returns>String</returns>
        public static string GetString(string name)
        {
            return rm.GetString(name);
        }

        /// <summary>
        /// Gets a string from the resource file and returns an image
        /// </summary>
        /// <param name="name">Resource file name of the string</param>
        /// <param name="font">Font</param>
        /// <param name="brush">Brush</param>
        /// <returns>Image</returns>
        public static Image GetString(string name, Font font, Brush brush, bool antiAlias)
        {
            string str = (string)rm.GetObject(name);

            // Create temporary bitmap to get string size
            Bitmap tmpBmp = new Bitmap(10, 10);
            Graphics tmpGrs = Graphics.FromImage(tmpBmp);
            SizeF sizeF = tmpGrs.MeasureString(str, font);
            
            // Create the bitmap
            Bitmap bmp = new Bitmap((int)sizeF.Width, (int)sizeF.Height);
            PointF pointF = new PointF(0, 0);
            Graphics grs = Graphics.FromImage(bmp);

            // Antialias when needed
            if (antiAlias)
            {
                grs.TextRenderingHint = TextRenderingHint.AntiAlias;
                grs.SmoothingMode = SmoothingMode.AntiAlias;
            }

            // Draw the string
            grs.DrawString(str, font, brush, pointF);

            // Return the image
            return (Image)bmp;
        }

        /// <summary>
        /// Gets an object from the resource file
        /// </summary>
        /// <param name="name">Resource file name of the object</param>
        /// <returns>Object</returns>
        public static object GetObject(string name)
        {
            return rm.GetObject(name);
        }
    }
}
