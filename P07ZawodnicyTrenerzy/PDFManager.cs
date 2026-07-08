using P06Zawodnicy.Shared.Domain;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07ZawodnicyTrenerzy
{
    internal class PDFManager
    {
        private readonly string sciezka;
        public PDFManager(string sciezka)
        {
            this.sciezka = sciezka;
        }
        public void WygenerujPDF(Zawodnik[] zawodnicy)
        {
            GlobalFontSettings.FontResolver = new PdfSharp.Snippets.Font.FailsafeFontResolver();
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Raport zawodnicy";
            //... tutaj dodajemy kod generujący zawartość PDF na podstawie danych zawodników
            // Create an empty page
            PdfPage page = document.AddPage();

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont font = new XFont("Verdana", 20, XFontStyleEx.BoldItalic);


            for (int i = 0; i < zawodnicy.Length; i++)
            {
                gfx.DrawString(zawodnicy[i].ImieNazwisko, font, XBrushes.Aqua, 20, 50 + 25 * i);
            }
            document.Save(sciezka);
        
        }
    }
}
