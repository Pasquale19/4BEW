using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using iTextSharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace PdfMerge
{
    /*class PdfFunctions
    {
        PdfDocument[] PdfCollection = new PdfDocument[tblFile.Rows.Count - 1];
            for (int i =0; i<PdfCollection.Length;i++)
            {
                //PdfCollection[i]=PdfReader.Open(tblFile.Rows[i]["DateiName"], PdfDocumentOpenMode.Import)
            }
            string targetPdf = textBox1.Text;

            using (FileStream stream = new FileStream(targetPdf, FileMode.Create))
            {
                Document document = new Document();
    PdfCopy pdf = new PdfCopy(document, stream);
    PdfReader reader = null;
                try
                {
                    document.Open();
                    for (int i = 0; i<tblFile.Rows.Count; i++)
                    {
                        reader = new PdfReader(tblFile.Rows[i]["DateiName"].ToString());

}
                }
                catch (Exception)
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    if (document != null)
                    {
                        document.Close();
                    }
                }
    }*/
}
