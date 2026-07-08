using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace P01ORMWstep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zawodnik z0 = new Zawodnik();

            // ORM - Object - Relation - Mapping 

            ModelBazyDataContext db = new ModelBazyDataContext();

            // select * from zawodnicy
            Zawodnik[] zawodnicy = db.Zawodnik.ToArray();

            foreach (var z in zawodnicy)
            {
                Console.WriteLine(z.Imie + " " + z.Nazwisko);
            }

             

            // select * from zawodnicy where kraj = "pol"
             // to polecenie wykonało się na bazie danych 
            Zawodnik[] wyn1 = db.Zawodnik.Where(x => x.Kraj == "pol").ToArray();
            Zawodnik[] wyn1b = db.Zawodnik.Where(CzyPolak).ToArray();

               //to się wykonało loklanie (wielkośc liter ma znazenie)
            Zawodnik[] wyn2 = zawodnicy.Where(x => x.Kraj == "POL").ToArray();

            // LINQ loklanie 
            string[] napisy = { "BACHLEDA", "MATEJA", "HERR" }; 
            string[] wynik = napisy.Where(napis=> napis.Length > 4).ToArray();

            int[] liczby = { 4, 6, 33, 2, 30, 20, 22 };
            int[] wynik2 =liczby.Where(x=>x>20).OrderByDescending(x=>x).ToArray();

            var wyn3 = db.Zawodnik
                .Where(x => x.Kraj == "pol" || x.Kraj.Equals("ger"))
                .OrderByDescending(x => x.Kraj)
                .ThenBy(x => x.Wzrost)
                .ToArray();



            // znajdz zawodników, których nazwisko konczy się na litere a 
            // oraz wzrost jest ponad 2 razy wiekszy niz waga
            // urodzonych w II polowie roku, i posortouj po dlugosci imienia 


            //  select* from zawodnicy
            //where right(nazwisko, 1) = 'a'
            //  and wzrost > waga * 2 and month(data_ur) > 6
            //  order by len(imie)

            //składnia używająca operatora lambda (składnia skrócona) zalecana 
            var wyn7 = db.Zawodnik
                .Where(x => x.Nazwisko.EndsWith("a") && x.Wzrost > x.Waga * 2 && x.Data_ur.Month > 6)
                .OrderBy(x => x.Imie.Length)
                .ToArray();

            var wyn7b = db.Zawodnik
               .Where(x => x.Nazwisko.Last()=='a' && x.Wzrost > x.Waga * 2 && x.Data_ur.Month > 6)
               .OrderBy(x => x.Imie.Length)
               .ToArray();


            // składnia opodobna do SQL 
            var wyn8 = (from x in db.Zawodnik
                        where x.Nazwisko.EndsWith("a")
                        && x.Wzrost > x.Waga * 2
                        && x.Data_ur.Month > 6
                        orderby x.Imie.Length
                        select x).ToArray();



        }

        static bool CzyPolak(Zawodnik x)
        {
            return x.Kraj == "pol";
        }
    }
}
