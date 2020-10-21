using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    class Auto
    {
        public string Indulas { get; private set; }
        public string Cel { get; private set; }
        public string Rendszam { get; private set; }
        public string Telefon { get; private set; }
        public int Ferohely { get; private set; }

        public string Utvonal { get; private set; }

        public Auto(string szoveg)
        {
            string[] adat = szoveg.Split(';');
            Indulas = adat[0];
            Cel = adat[1];
            Rendszam = adat[2];
            Telefon = adat[3];
            Ferohely = int.Parse(adat[4]);
            Utvonal = Indulas + "-" + Cel;
        }
    }
}
