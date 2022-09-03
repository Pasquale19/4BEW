using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PdfMerge
{
    public class LevelListe
    {
        public static Dictionary<int,string> GetAlreadyExistingLevel(Dictionary<int, string> dict,string path="Level", bool ClearDict=true)
        {
            if (ClearDict) { dict.Clear(); }
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (var file in di.GetFiles("*Lvl*",SearchOption.TopDirectoryOnly))
            {
                string fileName = file.Name;
                string[] Split = file.Name.Split(new char[] { '_' ,'.'});
                int level = new int();
                level=level.GetLevel(Split[0]);
                string LSG = Split[1];
                bool ignoreDoppelteLevel = true;
                if (ignoreDoppelteLevel)
                {
                    if (!dict.ContainsKey(level)) { dict.Add(level, LSG); }
                }
                else
                {
                    if (!dict.ContainsKey(level) & !dict.ContainsValue(LSG)) { dict.Add(level, LSG); }
                }
            }
            return dict;
        }


        public static Boolean checkIfLSGAlreadyExist(Dictionary<int, string> dict, int level, string LSG)
        {
            if (dict.ContainsValue(LSG))
            {
                DialogResult dr = MessageBox.Show("Ein Level mit der Lösung: " + LSG + "existiert bereits" + "\n" + "Es wurde kein Level erstellt." + "\n Soll das Level trotzdem erstellt werden?", "Achtung", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        return false;
                    case DialogResult.No:
                        return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        }
    }
    public static class Ext
    {
        public static int GetLevel(this int level, string LVL)
        {
            string number = "";
            for (int i = 3; i < LVL.Length; i++)
            {
                number = number + LVL[i];
            }
            
            if (Int32.TryParse(number, out level)) { return level; }
            else { return level; }
            
        }
        public static void Export<T,Z>(this Dictionary <T,Z> dict, string path="Lösungen/Liste_LSG.txt")
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch { }
            var file = File.Create(path);
            file.Close();
            var items = from pair in dict
                        orderby pair.Key ascending
                        select pair;
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (KeyValuePair<T, Z> entry in items)
                {
                    string line = entry.Key.ToString() + "\t" + entry.Value.ToString();
                    sw.WriteLine(line);
                }
            }
        }
    }
    
}
