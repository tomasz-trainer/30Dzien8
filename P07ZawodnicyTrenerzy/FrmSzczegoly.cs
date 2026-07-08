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

    public enum TrybOkna
    {
        Dodawanie,
        Edycja
    }

    public partial class FrmSzczegoly : Form
    {
        IManagerZawodnikow mz;
        TrybOkna trybOkna;
        Zawodnik zawodnik;
        FrmStartowy frmStartowy;

        /// <summary>
        /// Tworzę formularz szczegółów zawodnika w trybie dodawania
        /// </summary>
        /// <param name="trybOkna">Określa tryb okna</param>
        /// <param name="mz">Manager do zarządzania bazą</param>
        /// <param name="frmStartowy">Referencja do formularza bazowego</param>
        public FrmSzczegoly(TrybOkna trybOkna, IManagerZawodnikow mz, FrmStartowy frmStartowy) 
        {
            InitializeComponent();
            this.trybOkna = trybOkna;
            this.frmStartowy = frmStartowy;
            this.mz = mz;

            btnUsun.Visible = false; // ukrywam przycisk usuwania w trybie dodawania

        }

        /// <summary>
        /// Tworzę formularz szczegółów zawodnika w trybie edycji
        /// </summary>
        /// <param name="trybOkna">Określa tryb okna</param>
        /// <param name="mz">Manager do zarządzania bazą</param>
        /// <param name="frmStartowy">Referencja do formularza bazowego</param>
        /// <param name="zawodnik">Zawodnik do edycji</param>
        public FrmSzczegoly(TrybOkna trybOkna, IManagerZawodnikow mz, FrmStartowy frmStartowy, Zawodnik zawodnik) : this(trybOkna, mz, frmStartowy)
        {
            //this.trybOkna = trybOkna;
            //this.frmStartowy = frmStartowy;
            //this.mz = mz;
            //InitializeComponent();


            this.zawodnik = zawodnik;
            txtImie.Text = zawodnik.Imie;
            txtNazwisko.Text = zawodnik.Nazwisko;
            txtKraj.Text = zawodnik.Kraj;
            dtpDataUr.Value = zawodnik.DataUrodzenia;
            numWzrost.Value = zawodnik.Wzrost;
            numWaga.Value = zawodnik.Waga;

            btnUsun.Visible = true; // pokazuję przycisk usuwania w trybie edycji
        }
        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (trybOkna == TrybOkna.Dodawanie)
            {
                DodajZawodnika();
            }
            else if (trybOkna == TrybOkna.Edycja)
            {
                EdytujZawodnika();
            }

            // wywolaj metode odświeżającą dane w głównym formularzu
            frmStartowy.OdswiezDane(zawodnik.Kraj);
            this.Close();

        }

        private void zczytajDaneZFormularza(Zawodnik zawodnik)
        {
            zawodnik.Imie = txtImie.Text;
            zawodnik.Nazwisko = txtNazwisko.Text;
            zawodnik.Kraj = txtKraj.Text;
            zawodnik.DataUrodzenia = dtpDataUr.Value;
            zawodnik.Wzrost = (int)numWzrost.Value;
            zawodnik.Waga = (int)numWaga.Value;
        }

        private void EdytujZawodnika()
        {
            zczytajDaneZFormularza(zawodnik);
            mz.Edytuj(zawodnik);
        }

        private void DodajZawodnika()
        {
            zawodnik = new Zawodnik();
            zczytajDaneZFormularza(zawodnik);
            mz.Dodaj(zawodnik);
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            string kraj = zawodnik.Kraj;
            mz.Usun(zawodnik);
            frmStartowy.OdswiezDane(kraj);
            this.Close();
        }
    }
}
