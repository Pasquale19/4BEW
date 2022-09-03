using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfMerge
{
    public class BrowserDialog
    {
        public static string FolderBrowser(string startpath = "", bool ShowNewFolderBtn = false)
        {
            string path = "";
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowNewFolderButton = ShowNewFolderBtn;
                if (startpath == "")
                {
                    folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                }
                else
                {
                    try
                    {
                        folderBrowserDialog.SelectedPath = startpath;
                    }
                    catch
                    {
                        folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                    }

                }
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path = folderBrowserDialog.SelectedPath;
                }
            }


            return path;
        }

        public static string openFileBrowser(string InitialDirectory, string Filter= "PdfDateien *.pdf|*.pdf ; *.pdf|All files (*.*)|*.*| Bilder| *.jpg;*.bmp;*.png;*.gif ", bool Multiselect=false)
        {
            string FilePath=InitialDirectory;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                try { openFileDialog.InitialDirectory = InitialDirectory; }
                catch { openFileDialog.InitialDirectory = "C:/"; }
                openFileDialog.Filter = Filter;     //Beschreibung| Filter Muster
                openFileDialog.FilterIndex = 2;     //setzt den standardmaäßig angezeigten Filter auf den zweiten Eintrag
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = Multiselect;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (String fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            FilePath = fileName;
                        }
                        catch { }

                    }

                }
            }
            return FilePath;
        }
        
    }
}
