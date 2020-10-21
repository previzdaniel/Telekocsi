using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    class Igeny
    {
        public string Azonosito { get; private set; }
        public string Indulas { get; private set; }
        public string Cel { get; private set; }
        public int Szemelyek { get; private set; }

        public Igeny(string szoveg)
        {
            string[] adat = szoveg.Split(';');
            Azonosito = adat[0];
            Indulas = adat[1];
            Cel = adat[2];
            Szemelyek = int.Parse(adat[3]);
        }
    }
}
