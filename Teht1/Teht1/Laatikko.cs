//Matias Puputti 15/09/2019 22:36
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olio_ohjelmoinnin_kertaus
{
    class Laatikko : INimi
    {
        //Ohjeen vaatima laatikko luokka INimi rajapinnalla.
        public string Nimi { get; set; }
        public List<Esine> Esineet = new List<Esine>();
        public int MAxPai;

        public Laatikko(int _Maxpai = 100)
        {
            MAxPai = _Maxpai;
            Esineet = new List<Esine>();
        }
        public decimal Kokonaispaino
        {
            get
            {
                decimal Paino = 0;
                for (int i = 0; i < Esineet.Count; i++)
                {
                    Paino += Esineet[i].Paino;
                }
                return Paino;
            }

        }
        public Esine Painavin
        {
            get
            {

                Esine Painavin = new Esine();
                Painavin.Paino = 0m;

                for (int e = 0; e < Esineet.Count; e++)
                {
                    if (Painavin.Paino < Esineet[e].Paino)
                    {
                        Painavin.Nimi = Esineet[e].Nimi;
                        Painavin.Paino = Esineet[e].Paino;

                    }
                }
                return Painavin;
            }
        }
        public int LisaaEsine(Esine Lisataan, int Maara)
        {
            Maara = 1;
            if (Kokonaispaino + Lisataan.Paino <= MAxPai)
            {
                Esineet.Add(Lisataan);
            }
            else
            {
                throw new Exception($"Virhe: Laatikkoon {Nimi} ei voitu lisätä, koska maksimipaino olisi ylittynyt.");
            }
            return Maara;
        }
        public override string ToString()
        {
            return "Laatikko " + Nimi + " " + Kokonaispaino + " kg";
        }

    }
}

