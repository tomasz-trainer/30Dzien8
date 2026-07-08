using P06Zawodnicy.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P07ZawodnicyTrenerzy
{
    internal class ObjectContainer
    {
        static public IManagerZawodnikow ManagerZawodnikow { get; set; }
        static public ManagerTrenerow ManagerTrenerow { get; set; }
        static public Wyszukiwarka Wyszukiwarka { get; set; }
        public ObjectContainer()
        {
            ManagerZawodnikow = new ManagerZawodnikowLINQ();
            ManagerTrenerow = new ManagerTrenerow();
            Wyszukiwarka = new Wyszukiwarka(ManagerZawodnikow, ManagerTrenerow);
        }
    }
}
