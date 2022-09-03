using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace PdfMerge
{
    public class LevelDesigner
    { private static Point pt0 = new Point(0, 0);
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
    
        /// <summary>
        /// fügt das Level mit Logo in die angegebene Vorlage ein
        /// </summary>
        public static Bitmap insertLevel(int level, Bitmap bmpLevel, string PathLevelBmp = @"resources/LevelSign.bmp", bool ohneHintergrundBild=true)
        {
            Bitmap bmpL = new Bitmap(PathLevelBmp);
            int ptX = bmpLevel.Width / 2 - bmpL.Width / 2;
            Point insertPoint = new Point(ptX, 14);
            using (Graphics g = Graphics.FromImage(bmpLevel))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PageUnit = GraphicsUnit.Pixel;    //standardmäßig ist Display eingesteltl das Pixel entspricht
                g.DrawImage(bmpLevel, new Rectangle(pt0, bmpLevel.Size), new Rectangle(pt0, bmpLevel.Size), GraphicsUnit.Pixel);
                //einfügen der Vorlage des LevelSymbols und des Levels

                Size sizeDest = new Size(338 - insertPoint.X, 77 - insertPoint.Y);
                RectangleF destRect = new RectangleF(insertPoint, sizeDest); //Bereich in den das Bild eingefügt wird

                Rectangle srcRect = new Rectangle(pt0, bmpL.Size);  //zu zeichnender Teil des Quellbildes
                if (!ohneHintergrundBild) { g.DrawImage(bmpL, destRect, srcRect, GraphicsUnit.Pixel); }

                Font font = new Font("LevelFont", 12, FontStyle.Bold);//Font besitzt keine Farbe (Schriftart)
                SolidBrush shadowBrush = new SolidBrush(Color.White);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                g.DrawString(level.ToString(), font, shadowBrush, destRect, sf);
            }
            //bmpLevel.Save("Test/LevelAdded2.bmp");
            return bmpLevel;

        }

        public static Image Resize(Image img, int newHeight, int newWidth=0)
        {
            Size orgSize = img.Size;
            if (newWidth==0)
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

        /// <summary>
        /// färbt den Hintergrund der schwarzen Boxen
        /// </summary>
        public static void ReColor(string path,int[] Startpoint, int[] Endpoint)
        {
            
             Bitmap bmp = new Bitmap(path);
             Size BmpSize = bmp.Size;
             int i = 0;
             int j = 0;
             bool gefunden = false;

                 for (i=Startpoint[0];i<Endpoint[0]&&i<bmp.Width;i++)
                 {
                     for (j=Startpoint[1];j<Endpoint[1]&&j<bmp.Height;j++)
                     {
                        Color pixelcolor = bmp.GetPixel(i, j);
                         if (pixelcolor==Color.Transparent)
                        {
                            bmp.SetPixel(i,j, bmp.GetPixel(i, j-1));
                        }
                         else
                        {
                            bmp.SetPixel(i, j, bmp.GetPixel(i, j-1));
                        }
                            
                     }
                 }
             
                bmp.Save("Vorlagen/4BDEWVorlage2_Bearbeitet.bmp");

        }
       
        /// <summary>
        /// fügt die 4 Bilder in die Vorlage ein
        /// </summary>
        public static Bitmap insert4Pict(string[] DateiPfad, Bitmap bmp=null)
        {
            if (bmp == null) { bmp = new Bitmap(@"resources/4BDEWVorlage2.bmp"); }
            
            Bitmap[] pics = new Bitmap[4];
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Point pt0 = new Point(0, 0);
                Point[] pt = new Point[4]; //Einfügepunkte
                pt[0] = new Point(30, 144); //die Reihenfolge gehet von links nach rechts, oben nach unten
                pt[1] = new Point(bmp.Width - pt[0].X - konst.PicsWidth,pt[0].Y);
                pt[2] = new Point(pt[0].X, 446);
                pt[3] = new Point(pt[1].X, pt[2].Y);
                g.DrawImage(bmp, new Rectangle(new Point(0,0), bmp.Size));
                for (int i=0;i<4;i++)
                {
                    pics[i] = new Bitmap(DateiPfad[i]);
                    Size destPicSize = new Size(konst.PicsWidth, konst.PicsHeight);
                    float destPicRatio = destPicSize.Width/(destPicSize.Height);
                    Rectangle destPic = new Rectangle(pt[i],destPicSize);

                    //Rectangle srcRect = new Rectangle(pt0, pics[i].Size);
                    RectangleF srcRect = cuttingWindow(pics[i].Size, destPicRatio);
                    g.DrawImage(pics[i], destPic, srcRect, GraphicsUnit.Pixel);
                }
            }
            //bmp.Save("Test/picAdded.bmp");
            return bmp;
        }
        private static RectangleF cuttingWindow(Size oldSize,float newSizeRatio)
        {
            float picRatio = oldSize.Width / oldSize.Height;
            float newWidth = oldSize.Width;
            float newHeight = oldSize.Height;
            if (picRatio>newSizeRatio)
            {
                newWidth = newSizeRatio * oldSize.Height;
            }
            if (picRatio<newSizeRatio)
            {
                newHeight = oldSize.Width / newSizeRatio;
            }
            float UpperLeftX=(oldSize.Width-newWidth)/ 2;
            float UpperLefY = (oldSize.Height - newHeight) / 2;
            return new RectangleF(UpperLeftX, UpperLefY, newWidth, newHeight);
        }
       

        /// <summary>
        /// fügt die schwarzen Boxen in die Vorlage ein, maximale Anzahl sind  7
        /// </summary>
        public static Bitmap InsertBlackBox(string PathVorlage, int anz, Boolean Kontrollspeicherung = false)
        {
            Bitmap bmp = new Bitmap(PathVorlage);
            Bitmap blackBox = new Bitmap(@"resources/BlackBox.bmp");
            Size SizeBlackBox = new Size(65, 65);
            int space = 3; //Platz zwischen den Boxen in Pixel
            int XStart = (bmp.Width-(anz * SizeBlackBox.Width + (anz - 1) * space))/2;
            Point pt = new Point(XStart,807);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Point pt0 = new Point(0, 0);

                for (int i = 0; i < anz; i++)
                {
                    Rectangle destRect = new Rectangle(pt, SizeBlackBox);
                    g.DrawImage(blackBox, destRect, new Rectangle(pt0, blackBox.Size), GraphicsUnit.Pixel);
                    pt = pt + new Size(SizeBlackBox.Width + space,0);
                }

            }
            if (Kontrollspeicherung)
            { try { bmp.Save("Test/AddBlackBox.bmp"); } catch { }
            
            
            }
            return bmp;
        }
        /// <summary>
        /// fügt die Lösung ein
        /// </summary>
        public static Bitmap InsertLSG(Bitmap bmp, string LSG,int level, Boolean Kontrollspeicherung = false,string PathLösung="Lösungen/")
        {

            Size SizeBlackBox = new Size(65, 65);
            int space = 3; //Platz zwischen den Boxen in Pixel
            int XStart = (bmp.Width - (LSG.Length * SizeBlackBox.Width + (LSG.Length - 1) * space)) / 2;
            Point pt = new Point(XStart, 807);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                Point pt0 = new Point(0, 0);
                Bitmap bmpBox = new Bitmap(@"resources/BuchstBoxEmpty.bmp");
                for (int i = 0; i < LSG.Length; i++)
                {
                    Rectangle destRect = new Rectangle(pt, SizeBlackBox);
                    g.DrawImage(bmpBox, destRect, new Rectangle(pt0,bmpBox.Size), GraphicsUnit.Pixel);

                    Font font = new Font("LsgBuchst", 26, FontStyle.Bold);
                    SolidBrush shadowBrush = new SolidBrush(Color.Black);
                    StringFormat sfCenter = new StringFormat();
                    sfCenter.LineAlignment = StringAlignment.Center;
                    sfCenter.Alignment = StringAlignment.Center;
                    
                    g.DrawString(LSG[i].ToString().ToUpper(), font, Brushes.Black, destRect, sfCenter);


                    pt = pt + new Size(SizeBlackBox.Width + space, 0);
                }
                if (Kontrollspeicherung) { bmp.Save(PathLösung + "Lvl" +level.ToString()+ "Lsg" + "_"+LSG + ".bmp"); }
            }
            
            return bmp;
        }
        /// <summary>
        /// fürgt in das Bild in der Mitte den gewünschten Buchstaben/Wort mit Kasten
        /// </summary>
        public static Bitmap InsertCharInBox(Bitmap img, string ShuffleString)
        {
            Point pt0 = new Point(0, 0);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.DrawImage(img, new Rectangle(pt0, img.Size));
                Bitmap bmpBox = new Bitmap(@"resources/BuchstBoxEmpty.bmp");
                int linkerRand = 33;
                int YfirstLine = 960;
                int YsecondLine = 1042;
                Point pt = new Point(linkerRand, YfirstLine);//Startpunkt
                
                for (int i=0; i<ShuffleString.Length;i++)
                {
                    int space = 6; //Platz zwischen den Boxen
                    Rectangle destRectF = new Rectangle(pt,new Size(konst.BuchstBoxWidth,konst.BuchstBoxHeight));
                    //einfügen der Box
                    //g.DrawImage(bmpBox, destRectF, new Rectangle(pt0, bmpBox.Size),GraphicsUnit.Pixel);
                    
                    //formatieren und einfügen des Buchstaben
                    Font font = new Font("LsgBuchst", 26, FontStyle.Bold);
                    SolidBrush shadowBrush = new SolidBrush(Color.Black);
                    StringFormat sfCenter = new StringFormat();
                    sfCenter.LineAlignment = StringAlignment.Center;
                    sfCenter.Alignment = StringAlignment.Center;
                    g.DrawImage(bmpBox, destRectF, new Rectangle(pt0, bmpBox.Size), GraphicsUnit.Pixel);
                    g.DrawString(ShuffleString[i].ToString(), font, Brushes.Black, destRectF, sfCenter);
                    pt =pt+ new Size(konst.BuchstBoxWidth + space, 0);
                    if (i==ShuffleString.Length/2-1)
                    {
                        pt = new Point(linkerRand, YsecondLine);
                    }
                }
               

                
            }
            img.Save(@"TestBitmap", ImageFormat.Bmp);
            return img;
        }
    }
    
    public static class PictureExtensions
    {

    }
}
