//Matias Puputti 15/09/2019 22:36
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olio_ohjelmoinnin_kertaus
{
    class Esine : INimi, IComparable
    {
        //Ohjeen vaatima Esine luokka.
        public string Nimi { get; set; }
        private decimal _Paino;
        public decimal Paino
        {
            get { return _Paino; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Syötetty paino ei voi olla negatiivinen");
                }

                else
                {
                    _Paino = Math.Round(value, 3);
                }

            }
        }
        public int PainoG
        {
            get
            {
                return Decimal.ToInt32(Paino * 1000);
            }

        }

        public int CompareTo(object obj)
        {
            return Paino.CompareTo(obj);
        }

        public override string ToString()
        {
            return Nimi + " " + Paino + " kg";
        }
    }
}
