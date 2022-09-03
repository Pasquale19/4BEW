using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace PdfMerge
{
    public partial class Form1 : Form
    {
        private DataTable tblFile;
        private bool Modus1;
        private Dictionary<int, string> dictLevel = new Dictionary<int, string>();
        private List<string> ListAktion = new List<string>() { "", "kopieren", "umbennen", "Verschieben" };
        int anzErstellterLevel;
        string picture_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        public Form1()
        {
            InitializeComponent();

            this.tblFile = new DataTable("PdfTabelle");
            try
            {
                this.txtBox_Zwischenspeicher.Text = picture_path;
            }
            catch { }

            this.anzErstellterLevel = 0;
            this.Modus1 = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //txtBox_Vorlage.Text = @"Vorlagen/4BDEWVorlage_20200619.bmp";
            txtBox_Vorlage.Text = @"resources/4BDEWVorlage_20200619.bmp";
            //txtBox_Zwischenspeicher.Text = "D:/programmieren/PdfMerge/PdfMerge/bin/Debug/VierBilder";
            txtBox_Zwischenspeicher.Text = @"tmp";
           txtBox_Ausgabeverzeichnis.Text = @"Level";
            dgv.DataSource = tblFile;
            tblFile.Columns.Add("DateiName", typeof(string));
            tblFile.Columns.Add("DateiPfad", typeof(string));
            tblFile.Columns.Add("DateiTyp", typeof(string));
            tblFile.Columns.Add("Lösung", typeof(string));
            //tblFile.Columns.Add("Ausgabeverzeichnis", typeof(string));
            tblFile.Columns.Add("vollstDateiPfad", typeof(string));// enthält den kompletten Dateipfad mit Dateiname.DateiTyp
            dgv.Columns["vollstDateiPfad"].Visible = false;
            tblFile.Columns.Add("Breite", typeof(int));
            tblFile.Columns.Add("Hoehe", typeof(int));

            DataGridViewComboBoxColumn columnAktion = new DataGridViewComboBoxColumn();
            columnAktion.DataSource = new List<string>() { "", "kopieren", "umbennen", "Verschieben" };
            columnAktion.Name = "Aktion";
            dgv.Columns.Add(columnAktion);
            columnAktion.Visible = false;
        }


        private void btnAddPdf_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                try { openFileDialog.InitialDirectory = "@Samples"; }
                catch
                {
                    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                }

                openFileDialog.Filter = "PdfDateien *.pdf|*.pdf ; *.pdf|All files (*.*)|*.*| Bilder| *.jpg;*.bmp;*.png;*.gif;*.jfif ";     //Beschreibung| Filter Muster
                openFileDialog.FilterIndex = 3;     //setzt den standardmaäßig angezeigten Filter auf den zweiten Eintrag
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (String fileName in openFileDialog.FileNames)
                    {
                        try
                        {
                            addRow(EventArgs.Empty, fileName);
                            //Read the contents of the file into a stream
                            var fileStream = openFileDialog.OpenFile();
                        }
                        catch { }

                    }

                }
            }
        }
        private void addRow(EventArgs e, string dateiPfad)
        {

            DataRow row = tblFile.NewRow();
            row["vollstDateiPfad"] = dateiPfad;
            row["DateiPfad"] = Path.GetDirectoryName(dateiPfad);
            //row["DateiPfad"] = Path.GetPathRoot(dateiPfad);
            row["DateiTyp"] = Path.GetExtension(dateiPfad);
            row["DateiName"] = Path.GetFileNameWithoutExtension(dateiPfad);

            GetThumbnail(EventArgs.Empty, Image.FromFile(dateiPfad));
            tblFile.Rows.Add(row);

        }
        /// <summary>
        /// blendet das aktuell eingefügte Bild in der PictureBox ein
        /// </summary>
        /// <param name="e"></param>
        private void GetThumbnail(EventArgs e, Image img)
        {
            int maxWidth = 2000;
            int maxHeight = 2000;

            int width = pictBox.Size.Width;
            int height = pictBox.Size.Height;

            Image myThumbnail = img.GetThumbnailImage(width, height, null, IntPtr.Zero);
            pictBox.Image = myThumbnail;

        }

        /// <summary>
        /// schneidet die Bilder zu und speichert sie im Ausgabeverzeichnis
        /// </summary>
        private void btnMergePdf_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in tblFile.Rows)
            {
                if (row["DateiTyp"].ToString() == ".jpg" || row["DateiTyp"].ToString() == ".bmp" || row["DateiTyp"].ToString() == ".png")
                {
                    Image newImage = Image.FromFile(row["vollstDateiPfad"].ToString());
                    newImage = LevelDesigner.Resize(newImage, newImage.Size.Height);
                    //string Zielpfad = Path.Combine(row["Ausgabeverzeichnis"].ToString(), row["DateiName"].ToString(), row["DateiTyp"].ToString());
                    string Zielpfad = row["Ausgabeverzeichnis"].ToString() + "/" + row["DateiName"].ToString() + row["DateiTyp"].ToString();
                    newImage.Save(Zielpfad);

                }
                string ZielPfad = Path.Combine(row["Ausgabeverzeichnis"].ToString(), row["DateiName"].ToString());
            }
        }

        private void btn_changeAusgVerz_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (txtBox_Ausgabeverzeichnis.Text != "")
                {
                    folderBrowserDialog.SelectedPath = txtBox_Ausgabeverzeichnis.Text;
                }
                else
                {
                    folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                }
                folderBrowserDialog.Description = "Wählen Sie ein AusgabeVerzeichnis aus";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBox_Ausgabeverzeichnis.Text = folderBrowserDialog.SelectedPath;

                }
            }

        }

        private void btn_AusgVerzAnw_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in tblFile.Rows)
            {
                row["Ausgabeverzeichnis"] = txtBox_Ausgabeverzeichnis.Text;
            }
        }

        /// <summary>
        /// erstellt aus den angegebenen Daten die Rätsel
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Modus1)
            {
                btnCreateLsg.PerformClick();
                this.dictLevel = LevelListe.GetAlreadyExistingLevel(dictLevel, txtBox_Ausgabeverzeichnis.Text);
                anzErstellterLevel = dictLevel.Count;
                this.erstelleLsg(anzErstellterLevel);
            }
            else
            {
                int newWidth = 0, newHeight = 0;
                if (!Int32.TryParse(txtBox_Breite.Text, out newWidth) && !Int32.TryParse(txtBox_Hoehe.Text, out newHeight))
                {
                    Bildzuschnitt ohneZuschnitt = new Bildzuschnitt(tblFile, txtBox_Ausgabeverzeichnis.Text);
                }
                else
                {
                    Bildzuschnitt Zuschnitt = new Bildzuschnitt(tblFile, txtBox_Ausgabeverzeichnis.Text, newWidth, newHeight);
                }


            }


        }
        private void erstelleLsg(int startlevel = 0)
        {
            dgv.Sort(this.dgv.Columns["Lösung"], ListSortDirection.Ascending);
            DataView dv = tblFile.DefaultView;
            dv.Sort = "Lösung DESC";

            int level = startlevel;
            using (DataTable tblCopy = dv.ToTable("Kopie"))
            {
                string tempLSG = ""; // dient zum überprüfen ob in vorherigen Vorgang 
                while (tblCopy.Rows.Count > 0)
                {
                    //Zeige.Table(tblCopy);
                    string LSG = tblCopy.Rows[0]["Lösung"].ToString();
                    if (LSG == tempLSG) { tblCopy.Rows[0].Delete(); }
                    string filter = "Lösung='" + LSG + "'";
                    DataRow[] rows = tblCopy.Select(filter);
                    if (rows.Length == 4)
                    {
                        VBEWLevel Level = new VBEWLevel(rows.TakeColumn("vollstDateiPfad"), LSG, level, txtBox_Ausgabeverzeichnis.Text, txtBox_Vorlage.Text);
                        level++;
                        for (int i = 0; i < 4; i++)
                        {
                            tempLSG = LSG;
                            string filterExpr = "vollstDateiPfad='" + rows[i]["vollstDateiPfad"].ToString() + "'";
                            DataRow[] rowsToDelete = tblFile.Select(filterExpr);
                            rowsToDelete[0].Delete();
                            rows[i].Delete();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Für das Lösungswort " + LSG + " wurden nicht genügend Bilder eingegeben." + "\n" + "Das erstellen des Levels ist fehlgeschlagen.", "Fehler");
                        int c = 0;

                        for (int i = 0; i <= rows.Length - 1; i++)
                        {
                            c++;
                            rows[i].Delete();
                            //Export.DataTableToTxt(tblCopy, "Test/rows"+c+".txt");
                        }

                    }
                }
            }
        }
        /// <summary>
        /// erstellt aus den DateiNamen die Lösungswörter, die Indexe werden abgeschnitten
        /// </summary>
        private void btnCreateLsg_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in tblFile.Rows)
            {
                //aus den DateiNamen werden die Lösungswörter erstellt
                if (row["Lösung"].ToString() == "")
                {
                    string[] SplitString = row["DateiName"].ToString().Split(new char[] { ' ', '_', '-', '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
                    row["Lösung"] = SplitString[0];
                }
            }

        }

        private void btn_showLV_Level_Click(object sender, EventArgs e)
        {
            this.dictLevel = LevelListe.GetAlreadyExistingLevel(dictLevel, txtBox_Ausgabeverzeichnis.Text);
            Form frmListViewLevel = new Listview_Level(dictLevel);
            frmListViewLevel.ShowDialog();
        }


        /// <summary>
        /// ändern des ZwischenSpeichers der Bilder
        /// </summary>
        private void label2_Click(object sender, EventArgs e)
        {
            txtBox_Zwischenspeicher.Text = BrowserDialog.FolderBrowser(txtBox_Zwischenspeicher.Text);
        }
        /// <summary>
        /// ändern der Vorlagedatei
        /// </summary>
        private void label2_Click_1(object sender, EventArgs e)
        {
            txtBox_Vorlage.Text = BrowserDialog.openFileBrowser(txtBox_Vorlage.Text, "All files (*.*)|*.*| Bilder| *.jpg;*.bmp;*.png;*.gif ", false);
        }

        /// <summary>
        /// umschalten auf den Modus Bildzuschnitt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Modus1 = !Modus1;
            txtBox_Breite.Visible = !Modus1;
            txtBox_Hoehe.Visible = !Modus1;
            lbl_Breite.Visible = !Modus1;
            lbl_Hoehe.Visible = !Modus1;

            txtBox_Zwischenspeicher.Visible = Modus1;
            txtBox_Vorlage.Visible = Modus1;
            label2.Visible = Modus1;
            btn_showLV_Level.Visible = Modus1;
            btnCreateLsg.Visible = Modus1;
            lbl_Zwischenspeicher.Visible = Modus1;
            dgv.Columns["Lösung"].Visible = Modus1;

        }
    }
    public static class Extensions
    {
        /// <summary>
        /// gibt alle EInträge in der angegebenen Spalte als string Array aus
        /// </summary>
        public static string[] TakeColumn(this DataRow[] rows, string columnName)
        {
            string[] colArray = new string[rows.Length];
            for (int i = 0; i < rows.Length; i++)
            {
                colArray[i] = rows[i][columnName].ToString();
            }
            return colArray;
        }
    }
}
