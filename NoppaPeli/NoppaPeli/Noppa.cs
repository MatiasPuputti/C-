using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoppaPeli
{
    //Noppa class
    class Noppa
    {
        static Random NoppaRandom = new Random();
        public int Lukema { get; set; }
        public int HeittoLkm { get; set; }

        public Noppa()
        {
            HeittoLkm = 0;
        }

        public int  Heita ()
            {
            Lukema = NoppaRandom.Next(1,7);
            HeittoLkm++;
            return Lukema;
            }
    }
}
