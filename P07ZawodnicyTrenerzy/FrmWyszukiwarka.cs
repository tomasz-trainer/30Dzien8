using P06Zawodnicy.Shared.Domain;
using P06Zawodnicy.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P07ZawodnicyTrenerzy
{
    public partial class FrmWyszukiwarka : Form
    {
        //Wyszukiwarka wyszukiwarka = new Wyszukiwarka();
        Wyszukiwarka wyszukiwarka = ObjectContainer.Wyszukiwarka;
        public FrmWyszukiwarka()
        {
            InitializeComponent();
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            List<Osoba> osoby = wyszukiwarka.WyszukajOsoby(txtSzukaj.Text);

            wyrendujWynik(osoby);
        }

        private void wyrendujWynik(List<Osoba> osoby)
        {
            pnlWyniki.Controls.Clear();
            int yOffset = 0;

            foreach (Osoba osoba in osoby)
            {
                Label lblImie = new Label()
                {
                    Text = $"Imie: {osoba.Imie}",
                    Location = new Point(10, yOffset),
                    Width = 200,
                    ForeColor = osoba is Zawodnik ? Color.Blue : Color.Green
                };
                pnlWyniki.Controls.Add(lblImie);
                Label lblNazwisko = new Label()
                {
                    Text = $"Nazwisko: {osoba.Nazwisko}",
                    Location = new Point(10, yOffset + 20),
                      Width = 200,
                    ForeColor = osoba is Zawodnik ? Color.Blue : Color.Green
                };
                pnlWyniki.Controls.Add(lblNazwisko);

                yOffset += 70;
            }
        }
    }
}
