using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PdfMerge
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            void createFolder(string subPath = @"Level")
            {
                bool exists = System.IO.Directory.Exists(subPath);
                if (!exists)
                    System.IO.Directory.CreateDirectory(subPath);
            }
            createFolder(@"Level");
            //createFolder(@"Lösungen");
            createFolder(@"tmp");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
    public class konst
    {
        public const int PicsWidth = 289 - 31 + 13;
        public const int PicsHeight = 396 - 137 + 10;
        public const int BuchstBoxWidth = 105 - 29;
        public const int BuchstBoxHeight = 992 - 918;
    }

}
