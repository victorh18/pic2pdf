using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace pic2pdf
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument pdfDoc = new PdfDocument();
            string fileName = args[1];
            pdfDoc.Info.Title = fileName;

            //Getting files from directory
            string dir = args[0];
            foreach (string i in Directory.GetFiles(dir, "*.jpg"))
            {
                pdfDoc.AddImagePage(i);
            }

            fileName = @"D:\" + fileName;
            pdfDoc.Save(fileName);

            Process.Start(fileName);

        }

 
    }

    public static class MyExtensionMethods
    {
        public static void AddImagePage(this PdfDocument doc, string imageFile)
        {
            PdfPage pdfPage = doc.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(pdfPage);
            gfx.DrawImage(XImage.FromFile(imageFile), 0, 0, pdfPage.Width, pdfPage.Height);
        }
    }

}
