using System;

namespace AsiakasRekisteri
{
    class Henkilo : Asiakas
    {
        public string Henkilotunnus { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public override string Nimi
        {
            get
                {
                    return $"{Sukunimi} {Etunimi}";
                }
            set
            {
                string[] Nimi_Taulukko =  value.Split();

                    if (Nimi_Taulukko.Length == 2)
                        {
                            Sukunimi = Nimi_Taulukko[0];
                            Etunimi = Nimi_Taulukko[1];
                        }
                    else
                    {
                        throw new Exception("Henkilön nimessä tulee olla kaksi osaa:sukunimi ja etunimi.");
                    }
            }
        }
        public override string AsiakasId
        {
            get
            {
                return Henkilotunnus;
            }
            set
            {
                if (value.Length == 11)
                {
                    Henkilotunnus = value;
                }
                else
                {
                    throw new Exception("Henkilötunnuksen pituus pitää olla 11 merkkiä.");
                }
            }

        }

        public Henkilo(string hetu, string sukunimi, string etunimi) 
            : base($"{sukunimi} {etunimi}")
        {
            Henkilotunnus = hetu;
            
        }
    }
}
