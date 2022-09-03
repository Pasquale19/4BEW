using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data;

namespace PdfMerge
{
    public class Bildzuschnitt
    {
        public Bildzuschnitt(DataTable tbl, string destPath, int Width, int Height, bool Resize = true)
        {

        }
        public Bildzuschnitt(DataTable tbl, string destPath) : this(tbl, destPath, 0, 0, false)
        {

        }
        public Image ToSquareSize(Image img)
        {
            Size orgSize = img.Size;
            int width = orgSize.Width;
            int height = orgSize.Height;
            if (width > height)
            {
                width = height;
            }
            else
            {
                height = width;
            }
            img = Resize(img, height, width);
            return img;
        }



        public static Image Resize(Image img, int newHeight, int newWidth = 0)
        {
            Size orgSize = img.Size;
            if (newWidth == 0)
            {
                newWidth = img.Width;
            }
            var destRect = new Rectangle(0, 0, newWidth, newHeight);
            var destImage = new Bitmap(newWidth, newHeight);
            destImage.SetResolution(img.HorizontalResolution, img.VerticalResolution);
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
                    graphics.DrawImage(img, destRect, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }


            return img;
        }
        /// <summary>
        /// schneidet und skaliert das Bild auf die gewünschte Größe
        /// </summary>

        private static Color TranspColor = Color.White;
        public static Image resizeImage(int newWidth, int newHeight, Image imgPhoto)
        {
            //Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float ScaleFactor = 0, ScaleW = 0, ScaleH = 0;

            ScaleW = ((float)newWidth / (float)sourceWidth); // Skalierung des Bildes in der Breite
            ScaleH = ((float)newHeight / (float)sourceHeight);
            if (ScaleH < ScaleW)
            {
                ScaleFactor = ScaleH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * ScaleFactor)) / 2);
            }
            else
            {
                ScaleFactor = ScaleW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * ScaleFactor)) / 2);
            }

            int destWidth = (int)(sourceWidth * ScaleFactor);
            int destHeight = (int)(sourceHeight * ScaleFactor);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight,
                          PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }

        private static Point pt0 = new Point(0, 0);



        public static class PictureExtensions
        {

        }
    }
}
