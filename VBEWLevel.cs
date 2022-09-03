using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PdfMerge
{
    public class VBEWLevel
    {
        private string ShuffleString;
        private  string LSG;
        private int Level;
        private string PathLevel;

        public VBEWLevel(string[] PathPics, string LSGWort,int level, string PathVorlage = @"Vorlagen/4BDEWVorlage4.bmp") : this(PathPics,LSGWort,level,"Level",PathVorlage:PathVorlage) 
        {
        }
        public VBEWLevel(string[] PathPics, string LSGWort, int level, string PathAusgabeVz ,string PathVorlage = @"Vorlagen/4BDEWVorlage4.bmp")
        {
            //Lösungswort einlesen
            LSG = LSGWort;
            ShuffleString = StringRandomizer.RandomString(12);
            ShuffleString = StringRandomizer.ShuffleStringInString(ShuffleString, LSG);
            //LevelDesigner.ReColor("Vorlagen/4BDEWVorlage_Bearbeitet.bmp",new int[] { 45,774}, new int[] { 590, 900 });
            Bitmap bmpLevel;
            try
            {
                bmpLevel = LevelDesigner.InsertBlackBox(PathVorlage, LSGWort.Length, true);
            }
            catch
            {
                bmpLevel = LevelDesigner.InsertBlackBox(@"resources/4BDEWVorlage_20200619.bmp", LSGWort.Length, true);
            }

            bmpLevel = LevelDesigner.InsertCharInBox(bmpLevel, ShuffleString);
            bmpLevel = LevelDesigner.insertLevel(level, bmpLevel);
            bmpLevel = LevelDesigner.insert4Pict(PathPics, bmpLevel);
            PathLevel = PathAusgabeVz + "/" + "Lvl" + level.ToString() + "_" + LSG + ".bmp";
            bmpLevel.Save(PathLevel);
            string PathLösung = PathAusgabeVz + "/";
            Bitmap bmpLSG = LevelDesigner.InsertLSG(bmpLevel, LSG, level, true, PathLösung);
        }
    }

}
