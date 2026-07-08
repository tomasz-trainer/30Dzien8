//https://alx.zoom.us/j/87892536293?pwd=LrS4FbqaHwzwnbl5CLG52oQgV9xvNm.1
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

            var wyn7b = db.Zawodnik.ToArray()
               .Where(x => x.Nazwisko.Last() == 'a' && x.Wzrost > x.Waga * 2 && x.Data_ur.Month > 6)
               .OrderBy(x => x.Imie.Length)
               .ToArray();


            // składnia opodobna do SQL 
            var wyn8 = (from x in db.Zawodnik
                        where x.Nazwisko.EndsWith("a")
                        && x.Wzrost > x.Waga * 2
                        && x.Data_ur.Month > 6
                        orderby x.Imie.Length
                        select x).ToArray();

            //select * from zawodnicy 
            Zawodnik[] wyn9 = db.Zawodnik.ToArray();

            string[] wyn10 = db.Zawodnik.Select(x => x.Imie).ToArray();

            //select imie + ' ' + nazwisko from zawodnicy 
            string[] wyn11 = db.Zawodnik.Select(x => x.Imie + " " + x.Nazwisko).ToArray();

            //select imie, nazwisko from zawodnicy 


            ZawodnikMini[] wynik12 = db.Zawodnik.Select(x=> new ZawodnikMini()
            {
                MojeImie = x.Imie,
                MojeNazwisko = x.Nazwisko.ToLower(),
            }).ToArray();

            // jesli nie chce nam sie tworzyc nowych obiektów 
            var wyn13 = db.Zawodnik.Select(x => new
            {
                MojeImie = x.Imie,
                MojaWaga = x.Waga,
                x.Kraj
            });

            foreach (var k in wyn13)
            {
                Console.WriteLine(k.MojeImie + " " + k.MojaWaga + " " + k.Kraj);
            }

            // nie musimy podawac nazw kolun 
            var wyn14 = db.Zawodnik.Select(x => new { x.Imie, x.Waga, x.Kraj });

            //wypisanie danych 
            foreach (var z in wyn14)
                Console.WriteLine(z.Imie + " " + z.Waga + " " + z.Kraj);

            // wypisz listę zawodnikow (imie nazwisko i BMI) 
            // i posortuj wyniki po BMI malejąco 
            //bmi = waga[kg]/wzrost[m]^2
            // wynik bmi podaj do dwóch miejsc po przecinku 

            var wyn15 = db.Zawodnik.ToArray()
                .Select(x => new
                {
                    x.Imie,
                    x.Nazwisko,
                    BMI = Math.Round((double)x.Waga / Math.Pow((double)x.Wzrost / 100, 2), 2)
                }).OrderByDescending(x => x.BMI).ToArray();

            var wyn15b =
                (from x in db.Zawodnik.ToArray()
                 select new
                 {
                     Imie = x.Imie,
                     Nazwisko = x.Nazwisko,
                     BMI = Math.Round((double)x.Waga / Math.Pow((double)x.Wzrost / 100, 2), 2)
                 }
                 ).OrderBy(x => x.BMI).ToList();


             IQueryable<Zawodnik> wynik16 =db.Zawodnik.Where(x => x.Kraj == "pol"); // to jeszcze nie zostało wysłane do bazy 
             var wynik17 = wynik16.Where(x => x.Wzrost > 170).ToArray(); // dopiero teraz zapytanie poszło do bazy 

            // poznaliśmy: select, from, where, order by , group by 

            // grupowanie 

            //select kraj, avg(convert(decimal, wzrost))
            //from Zawodnicy
            //group by kraj


            var wyn18 = db.Zawodnik
               .GroupBy(x => x.Kraj)
                .Select(x => new
                {
                    Kraj = x.Key,
                    SredniWzrost = x.Average(y => y.Wzrost)
                }).ToArray();


            var wyn19 = db.Zawodnik.GroupBy(x => x.Kraj).ToArray(); // to zwraca nam grupy 


            // wypisz wszystkie wartości długości nazwisk, wraz z informacją ile osób posiada
            // nazwisko o podanej długości 
            //np:
            // nazwisko o długości 5 ma 4 osoby
            // nazwisko o długości 7 ma 6 osoby
            // nazwisko o długości 6 ma 6 osoby
            //.... itd..
            // wyniki posortuj po liczbie osób w grupie rosnąco
            // , a jeżeli liczba osób jest taka sama to po długości nazwiska malejąco

            // * uwzgędnij tylko zawodników, których nazwisko nie zaczyna się na "a"
            // i wypisz tylko te grupy, które zawierają co najmniej 2 osoby


            var wyn20 = db.Zawodnik
               .Where(x => !x.Nazwisko.StartsWith("a"))
               .GroupBy(x => x.Nazwisko.Length)
               .Select(x => new
               {
                   DlugoscNazwiska = x.Key,
                   LiczbaOsob = x.Count(),
                   Srednia = x.Average(y => y.Wzrost),
                   Max = x.Max(y => y.Wzrost)
               })
                 .Where(x => x.LiczbaOsob > 1)
                 .OrderBy(x => x.LiczbaOsob)
                 .ThenByDescending(x => x.DlugoscNazwiska)
                 .ToArray();

            foreach (var g in wyn20)
                Console.WriteLine($"Nazwisko o dlugości {g.DlugoscNazwiska} ma {g.LiczbaOsob} osoby");

            // Dla kazdego kraju, wypisz po przecinku liste nazwisk zawodników z danego kraju 

            var wyn21 = db.Zawodnik
                .GroupBy(x => x.Kraj)
                .Select(x => new
                {
                    Kraj = x.Key,
                    Nazwiska = x.Select(y => y.Nazwisko).OrderBy(y => y)
                }).ToArray();

            foreach (var g in wyn21)
            {
                Console.WriteLine("Kraj: " + g.Kraj);
                Console.WriteLine(string.Join(" ,", g.Nazwiska));
            }

            // do tej pory zawsze wybieralismy zbiór elementów 

            // chcemy znaleź jeden wybrany rekord 


            Zawodnik wyn22 = db.Zawodnik.Where(x => x.Nazwisko == "małysz").ToArray()[0];
            Zawodnik wyn23 = db.Zawodnik.Where(x => x.Nazwisko == "małysz").FirstOrDefault();

            Zawodnik wyn24 = db.Zawodnik.FirstOrDefault(x => x.Nazwisko == "małysz");

            Zawodnik wyn25 = db.Zawodnik.FirstOrDefault(x => x.Id_zawodnika == 7);

            // znajdz zawodnikow których waga jest o dokładnie 1 kilogram mniejsza od wagi najwyższego zawodnika

            var najwyższy = db.Zawodnik.OrderByDescending(x => x.Wzrost).FirstOrDefault();

            var wyn26 = db.Zawodnik.Where(x => x.Waga == najwyższy.Waga - 1).ToArray();

            // inne rozwiazanie 

            var wyn27 = db.Zawodnik.Where(x => x.Waga == db.Zawodnik.OrderByDescending(y => y.Wzrost).FirstOrDefault().Waga - 1).ToArray();

            // jeszcze inne 

            var najwyzszyWzrost = zawodnicy.Select(x => x.Wzrost).Max();
            var wyn28 = zawodnicy.Where(x => x.Waga == db.Zawodnik.FirstOrDefault(y => y.Wzrost == najwyzszyWzrost).Waga - 1).ToArray();

            // jeszce inne 

            var wyn29 = zawodnicy.Where(x => x.Waga == db.Zawodnik.FirstOrDefault(y => y.Wzrost == zawodnicy.Select(z => z.Wzrost).Max()).Waga - 1).ToArray();


            // dla każdego kraju wypisz imie i nazwisko najwyzszego zawodnika z tego kraju 

        }

        static bool CzyPolak(Zawodnik x)
        {
            return x.Kraj == "pol";
        }
    }
}
