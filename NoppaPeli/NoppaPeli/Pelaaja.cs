using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoppaPeli
{

    class Pelaaja : INimi
    {
        public string Nimi{ get; set;}
        public int Pisteet { get; set;}

        public Pelaaja(string PelaajanNimi)
        {
            Nimi = PelaajanNimi;
            Pisteet = 0;
        }
    }
}
