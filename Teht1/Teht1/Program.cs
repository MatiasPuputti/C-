//Matias Puputti 15/09/2019 22:36
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Olio_ohjelmoinnin_kertaus
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main metodi, loin ohjelmaan monia metodeja joilla yritin hajauttaa ja selkeyttää ohjelman toimintaa. 
            try
            {
                Ohjelma();
            }
            catch (Exception)
            {
                WriteLine("Ohjelman suoritus päättyi virheeseen");
            }
            WriteLine("Paina Enter lopettaaksesi...");
            ReadLine();
        }
        public static void Ohjelma()
        {
            // Ohjelman suoritus metodi.

            //Luodaan lista laatikoista.
            WriteLine("Tehdään laatikot");
            List<Laatikko> Laatikot = new List<Laatikko>() { };

            //Luodaan lista laatikon sisällä olevista esineistä.
            Laatikko Laatikko = _Laatikko();

            //If lause jolla tarkistetaan ettei nimi ole tyhjä, jos on skipataan. 
            if (Laatikko.Nimi.Length != 0)
            {
                WriteLine("Lisätään laatikkoon esineitä");
            }

            //while loop jota suoritetaan kunnes laatikon nimi on tyhjä.
            while (Laatikko.Nimi.Length > 0)
            {
                Esine _Esine = LuoEsine();

                //whileloop jolla lisätään oliota laatikkoon kunnes nimi tulee tyhjänä.
                while (_Esine.Nimi != "Tyhjä")
                {
                    if (_Esine.Nimi.Length != 0)
                    {
                        Lisäys(Laatikko, _Esine);
                    }
                    _Esine = LuoEsine();
                }
                //Lisätään valmis laatikko laatikot listaan.
                Laatikot.Add(Laatikko);

                //Tyhä rivi jolla selkeytetään lukemista.
                WriteLine();

                //Uuden laatikon luonti.
                Laatikko = _Laatikko();
            }

            //for loop jolla kirjoitetaan tuotetut laatikot ja halutut arvot.
            for (int i = 0; i < Laatikot.Count; i++)
            {
                WriteLine();
                WriteLine(Laatikot[i]);
                WriteLine($"Esineitä {Laatikot[i].Esineet.Count} kpl.");
                WriteLine($"Painavin esine {Laatikot[i].Painavin.Nimi} {Laatikot[i].Painavin.Paino} kg.");
                WriteLine();
            }
        }
        public static Esine LuoEsine()
        {
            //Esineen luonti metodi

            string Nimi;
            Esine _Esine = new Esine();
            Write("Anna esineen nimi (tyhjä lopettaa): ");

            Nimi = TarSan(ReadLine());

            //Esine nimetään ja kysytään paino jollei syötetty nimi ollut tyhjä.
            if (Nimi.Length != 0)
            {
                _Esine.Nimi = Nimi;
                Write("Anna esineen paino (kg): ");
                _Esine.Paino = TarDes(ReadLine());
            }

            //Jos syötetty nimi oli tyhjä esineen nimeksi annetaan tyhjä, jollain palautetaan "tyhjä" joka ohittaa esineen lisäyksen laatikkoon. 
            if (Nimi.Length == 0)
            {
                _Esine.Nimi = "Tyhjä";
            }

            return _Esine;
        }
        public static Laatikko _Laatikko()
        {
            //Laatikko olion luonti metodi.

            Laatikko Laatikko = new Laatikko();
            Write("Anna laatikon nimi (tyhjä lopettaa): ");
            Laatikko.Nimi = TarSan(ReadLine());

            //Palautetaan luotu olio (tyhjä nimi aiheuttaa while loopista poistumisen ja ohjelman päättymisen).
            return Laatikko;
        }
        public static void Lisäys(Laatikko Laatikko, Esine Esine)
        {
            //Metodi jossa hoidetaan esineen lisäys laatikkoon.
            int Maara = 0;
            int Lisatyt = 0;
            Write("Lisättävä määrä: ");
            Maara = TarInt(ReadLine());

            //For loopilla lisätään niin monta esine oliota kuin laatikkoon mahtuu ennen painorajaa.
            try
            {
                for (int i = 0; i < Maara; i++)
                {
                    //Laatikkoon lisäys hoidettu ohjeessa vaaditulla LisaaEsine metodilla.
                    Lisatyt += Laatikko.LisaaEsine(Esine, Maara);
                }
            }

            //Mahdollisen virheen nappaus ja virheviestin kirjoitus.
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

            //Lisättyjen esineiden nimen ja lisätyn määrän tulostus.
            WriteLine($"Esinettä {Esine.Nimi} lisättiin {Lisatyt} kpl.");

        }
        public static string TarSan(string Tarkiste)
        {
            //Metodi jolla tarkistin Laatikon nimen 

            int Tarkistus = 0;
            List<char> Sallitut = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö',
                                                   'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Å', 'Ä', 'Ö',
                                                   '0','1','2','3','4','5','6','7','8','9', ' '};
            while (true)
            {


                for (int i = 0; i < Tarkiste.Count(); i++)
                {
                    for (int e = 0; e < Sallitut.Count; e++)
                    {
                        if (Tarkiste[i] == Sallitut[e])
                        {
                            Tarkistus++;
                        }
                    }
                }
                if (Tarkiste.Length == Tarkistus)
                {
                    break;
                }
                //Jos ei niin pyydetään nimeä uudestaan kunnes kunnes saadaan kelvollinen nimi.
                else
                {
                    Write("Anna kelvollinen laatikon-nimi: ");
                    Tarkiste = ReadLine();
                    Tarkistus = 0;
                }
            }
            return Tarkiste;
        }
        public static decimal TarDes(string Tarkiste)
        {
            //Metodi jolla tarkistin Desimaaliluvun ja muutin pilkun pisteeksi virheen ehkäisemiseksi.
            int Tarkistus = 0;
            List<char> Sallitut = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',' };
            while (true)
            {
                Tarkiste = Tarkiste.Replace(',', '.');

                for (int i = 0; i < Tarkiste.Count(); i++)
                {
                    for (int e = 0; e < Sallitut.Count; e++)
                    {
                        if (Tarkiste[i] == Sallitut[e])
                        {
                            Tarkistus++;
                        }
                    }
                }
                if (Tarkiste.Length == Tarkistus && Tarkiste.Length != 0)
                {
                    break;
                }
                //Jos ei niin pyydetään nimeä uudestaan kunnes kunnes saadaan kelvollinen nimi.
                else
                {
                    Write("Anna kelvollinen Paino: ");
                    Tarkiste = ReadLine();
                    Tarkistus = 0;
                }
            }
            return Convert.ToDecimal(Tarkiste); ;
        }
        public static int TarInt(string Tarkiste)
        {
            //Laatikkoon lisättävän syötteen tarkistus.
            int Tarkistus = 0;
            List<char> Sallitut = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            while (true)
            {
                for (int i = 0; i < Tarkiste.Count(); i++)
                {
                    for (int e = 0; e < Sallitut.Count; e++)
                    {
                        if (Tarkiste[i] == Sallitut[e])
                        {
                            Tarkistus++;
                        }
                    }
                }
                if (Tarkiste.Length != 0)
                {
                    if (Tarkiste.Length == Tarkistus && Convert.ToInt64(Tarkiste) <= 2147483647)
                    {
                        break;
                    }
                }
                //Jos ei niin pyydetään nimeä uudestaan kunnes kunnes saadaan kelvollinen nimi.
                if (Tarkiste.Length == 0)
                {
                    Write("Anna kelvollinen määrä: ");
                    Tarkiste = ReadLine();
                    Tarkistus = 0;
                }
                else
                {
                    if (Tarkiste.Length != Tarkistus)
                    {
                        Write("Anna kelvollinen määrä: ");
                        Tarkiste = ReadLine();
                        Tarkistus = 0;
                    }
                    if (Tarkiste.Length != 0)
                    {
                        if (Tarkiste.Length == Tarkistus && Convert.ToInt64(Tarkiste) > 2147483647)
                        {
                            WriteLine("Anna realistinen lisättävä määrä: ");
                            Tarkiste = ReadLine();
                            Tarkistus = 0;
                        }
                    }
                }
            }
            return Convert.ToInt32(Tarkiste); ;
        }
    }
}
