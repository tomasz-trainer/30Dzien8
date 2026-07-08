using P06Zawodnicy.Shared.Domain;
using P06Zawodnicy.Shared.Services;
using PdfSharp.Pdf.IO;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace P07ZawodnicyTrenerzy
{
    public partial class FrmStartowy : Form
    {
        IManagerZawodnikow mz;
        public FrmStartowy()
        {

            InitializeComponent();

            mz = ObjectContainer.ManagerZawodnikow;
            
            lbDane.DataSource = 
                mz.WczytajZawodnikow();
           
            string[] kraje = mz.PodajKraje();
            cbKraje.DataSource = kraje;

            generujObrazkiKrajow(kraje);
        }

        private void generujObrazkiKrajow(string[] kraje)
        {
            string folderFlagi = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "flagi");

            for (int i = 0; i < kraje.Length; i++)
            {
                string sciezka = Path.Combine(folderFlagi, kraje[i] + ".png");
                if (File.Exists(sciezka))
                {
                    PictureBox pc = new PictureBox()
                    {
                        Name = "pb" + kraje[i],
                        Size = new System.Drawing.Size(50, 30),
                        Location = new System.Drawing.Point(10 + i * 60, 10),
                        ImageLocation = sciezka,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Cursor = Cursors.Hand,
                        Tag = kraje[i]

                    };
                    pc.Click += flaga_Click;

                    pnlFlagi.Controls.Add(pc);
                }
            }

        }

        private void flaga_Click(object sender, EventArgs e)
        {
            // musimy odczytać która flaga została kliknieta 
            PictureBox kliknietyObrazek = (PictureBox)sender;

            cbKraje.SelectedItem = kliknietyObrazek.Tag;
        }

        private void btnSzczegoly_Click(object sender, EventArgs e)
        {
            Zawodnik zawodnik = (Zawodnik)lbDane.SelectedItem;
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(TrybOkna.Edycja,mz,this, zawodnik);
            frmSzczegoly.Show();
        }



        private void cbKraje_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zaznaczonyKraj = (string)cbKraje.SelectedItem;

            lbDane.DataSource = mz.PodajZawodnikow(zaznaczonyKraj);
            lbDane.DisplayMember = "ImieNazwisko";
            przygotujWykres();
        }

        private void btnNowy_Click(object sender, EventArgs e)
        {
            FrmSzczegoly frmSzczegoly = new FrmSzczegoly(TrybOkna.Dodawanie, mz,this);
            frmSzczegoly.Show();
        }

        private void btnOdswiez_Click(object sender, EventArgs e)
        {
            OdswiezDane("AUT");
        }

        public void OdswiezDane(string kraj)
        {
            lbDane.DataSource = null;
            lbDane.DataSource = mz.PodajZawodnikow(kraj);
            lbDane.DisplayMember = "ImieNazwisko";

            przygotujWykres();

             
        }

        private void przygotujWykres()
        {
            chWykres.Series.Clear();
            Series seriaDanych = new Series("Wzrosty");
            seriaDanych.ChartType = SeriesChartType.Column;

            GrupaKraju[] gk = mz.PodajSredniWzrostDlaKazdegoKraju();

            //string[] osX = new string[gk.Length];
            //double[] osY = new double[gk.Length];

            //for (int i = 0; i < gk.Length; i++)
            //{
            //    osX[i] = gk[i].Kraj;
            //    osY[i] = gk[i].SredniWzrost;
            //}
            //inny sposb 
            string[] osX = gk.Select(x => x.Kraj).ToArray();
            double[] osY = gk.Select(x => x.SredniWzrost).ToArray();

            seriaDanych.Points.DataBindXY(osX, osY);
            chWykres.Series.Add(seriaDanych);
        }

        private void btnGenerujPDF_Click(object sender, EventArgs e)
        {
            Zawodnik[] zawodnicy = (Zawodnik[])lbDane.DataSource;

            if (zawodnicy == null || zawodnicy.Length == 0)
            {
                MessageBox.Show("Pusty zbiór danych", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pliki pdf (*.pdf)|*.pdf";
            sfd.Title = "Wskaż miejsce zapisu raportu PDF";
            sfd.InitialDirectory = "C:\\dane";
            sfd.FileName = cbKraje.Text + "_" + DateTime.Now.ToString("ssmmhhddMMyy");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                PDFManager pm = new PDFManager(sfd.FileName);
                pm.WygenerujPDF(zawodnicy);
            }
        }

        private void btnSredniWiek_Click(object sender, EventArgs e)
        {
            string wybranyKraj = cbKraje.SelectedItem.ToString();
            int sredniWiek = mz.PodajSredniWiekZawodnikow(wybranyKraj);
            MessageBox.Show($"Średni wiek zawodnikow z kraju {wybranyKraj}: {sredniWiek}");
        }

        FrmWyszukiwarka frmWyszukiwarka;
        private void btnWyszukiwarka_Click(object sender, EventArgs e)
        {
            if (frmWyszukiwarka != null)
            {
                frmWyszukiwarka.BringToFront();
            }
            else
            {
                frmWyszukiwarka = new FrmWyszukiwarka();
                frmWyszukiwarka.Show();
            }
           // FrmWyszukiwarka frmWyszukiwarka = new FrmWyszukiwarka();
           // frmWyszukiwarka.Show();
        }
    }
}
