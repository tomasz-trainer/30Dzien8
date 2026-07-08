using P06Zawodnicy.Shared.Data;
using P06Zawodnicy.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06Zawodnicy.Shared.Services
{
    internal class ManagerZawodnikowLINQ : IManagerZawodnikow
    {
          private void mapujNaZawodnikaDb(Zawodnik z, ZawodnikDb zdb)
          {
            zdb.Id_zawodnika = z.Id_zawodnika;
            zdb.Imie = z.Imie;
            zdb.Nazwisko = z.Nazwisko;
            zdb.Kraj = z.Kraj;
            zdb.Data_ur = z.DataUrodzenia;
            zdb.Wzrost = z.Wzrost;
            zdb.Waga = z.Waga;
            zdb.Id_trenera = z.Id_trenera;
          }
        public void Dodaj(Zawodnik z) // zawodnik domain uzyawny na UI
        {
            var zdb = new ZawodnikDb(); // tworzymy nowego zawodnika bazodanowego 
            mapujNaZawodnikaDb(z, zdb);
            ModelBazyDataContext db = new ModelBazyDataContext();
            db.ZawodnikDb.InsertOnSubmit(zdb); //zapisujemy w bazie danych
            db.SubmitChanges();
        }



        public void Edytuj(Zawodnik edytowany)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();
            ZawodnikDb zd = db.ZawodnikDb.FirstOrDefault(x => x.Id_zawodnika == edytowany.Id_zawodnika);
            mapujNaZawodnikaDb(edytowany, zd);
            db.SubmitChanges();
        }

        public string[] PodajKraje()
        {
            return new ModelBazyDataContext()
             .ZawodnikDb
             .GroupBy(x => x.Kraj)
             .Select(x => x.Key)
             .ToArray();
        }

        public int PodajSredniWiekZawodnikow(string kraj)
        {
            ModelBazyDataContext db = new ModelBazyDataContext();

            double sredniWiek = db.ZawodnikDb
                .Where(x => x.Kraj.Equals(kraj))
                .Select(x => DateTime.Now.Year - x.Data_ur.Year)
                .Average();

            return sredniWiek;
        }

        public double PodajSredniWzrost(string kraj)
        {
            throw new NotImplementedException();
        }

        public Zawodnik[] PodajZawodnikow(string kraj)
        {
            throw new NotImplementedException();
        }

        public void Usun(Zawodnik zawodnik)
        {
            throw new NotImplementedException();
        }

        public Zawodnik[] WczytajZawodnikow()
        {
            throw new NotImplementedException();
        }
    }
}
