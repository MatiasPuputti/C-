using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NoppaPeli
{
    //Staattinen sovellus class
    static class Sovellus
    {
        static int VOITONPISTERAJA = 3;

        public static void Aja()
        {
            //Riveillä 20-40 luodaan ohjelmassa käytettävät oliot.

            //Käytetään pelin voittajan tulostukseen.
            bool Pelaaja1Voitti = false;

            WriteLine("Noppa-peli");

            Write("Pelaajan 1 nimi: ");
            Pelaaja Pelaaja1 = new Pelaaja(Vainkirjaimia(ReadLine()));

            Write("Pelaajan 2 nimi: ");
            Pelaaja Pelaaja2 = new Pelaaja(Vainkirjaimia(ReadLine()));

            //Jos pelaajalle2 annetaan sama nimi kuin pelaajalle nimeä pyydetään uudelleen.
            while (Pelaaja1.Nimi == Pelaaja2.Nimi)
            {
                Write($"Et voi valita samaa nimeä kuin pelaaja1({Pelaaja1.Nimi}), valitse uudestaan: ");
                Pelaaja2 = new Pelaaja (Vainkirjaimia(ReadLine()));
            }

            Noppa Noppa1 = new Noppa();
            Noppa Noppa2 = new Noppa();
            Noppa Noppa3 = new Noppa();
            Noppa Noppa4 = new Noppa();

            //Suoritetaan looppia kunnes toinen pelaaja saa pisteet voittoon.
            while (Pelaaja1.Pisteet != VOITONPISTERAJA && Pelaaja2.Pisteet != VOITONPISTERAJA)
            {
                //Pelaajan1 nopat per pelivuoro.
                Noppa1.Heita();
                Noppa2.Heita();

                //Pelaajan2 nopat per pelivuoro.
                Noppa3.Heita();
                Noppa4.Heita();

                //Tulostaa heittokierroksen lukumäärän, noppa olion1 perusteella (olisi voinut käyttää mitä noppa oliota tahansa).
                WriteLine($"Heittokierros {Noppa2.HeittoLkm}");

                //Tulostaa pelaajille riveillä 50 ja 51 arvotut noppaluvut ja niiden summan.
                WriteLine($"{Pelaaja1.Nimi}: {Noppa1.Lukema} + {Noppa2.Lukema} = {Noppa1.Lukema + Noppa2.Lukema}");
                WriteLine($"{Pelaaja2.Nimi}: {Noppa3.Lukema} + {Noppa4.Lukema} = {Noppa3.Lukema + Noppa4.Lukema}");

                //Riveillä 62-73 annetaan pisteet sille kummalla on suurempi noppasumma,
                //nollataan kierroksen häviäjän pisteet ja asetetaan pelaaja1 joko kierroksen voittajaksi tai ei voittajaksi.(Kun while loop päättyy tarkistan tällä kumpi voitti pelin)
                if (Noppa1.Lukema + Noppa2.Lukema > Noppa3.Lukema + Noppa4.Lukema)
                {
                    Pelaaja1.Pisteet++;
                    Pelaaja2.Pisteet = 0;
                    Pelaaja1Voitti = true;
                }
                if (Noppa3.Lukema + Noppa4.Lukema > Noppa1.Lukema + Noppa2.Lukema)
                {
                    Pelaaja2.Pisteet++;
                    Pelaaja1.Pisteet = 0;
                    Pelaaja1Voitti = false;
                }
            }

            //Jos pelaaja1 voitti tulostetaan hänet voittajaksi.
            if (Pelaaja1Voitti)
            {
                WriteLine($"Pelin voittaja on {Pelaaja1.Nimi} ja noppia heitettiin {Noppa1.HeittoLkm} kertaa!");
            }
            //Jos pelaaja2 voitti tulostetaan hänet voittajaksi.
            else
            {
                WriteLine($"Pelin voittaja on {Pelaaja2.Nimi} ja noppia heitettiin {Noppa1.HeittoLkm} kertaa!");
            }
                
        }

        // Kirjoitin oman metodin pelaajaolioihin sijoitettavan nimen tarkistukseen riveillä 25 ja 28, koska Syöte.All(Char.IsLetter) käytöstä tuli keppiä.
        public static string Vainkirjaimia(string Syote)
        {
            //Riveilä 93 ja 94 luodaan merkit jotka ovat kelvollisia nimessä, ja rivillä 95 muuttuja jonka pitää vastata pituudeltaan string Syötteen pituutta.  
            List<char> PienetKirjaimet = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'å', 'ä', 'ö' };
            List<char> IsotKirjaimet = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Å', 'Ä', 'Ö' };
            int Tarkistus= 0;


                //Ajaa looppia kunnes annetaan kelvollinen nimi.
                while (true)
                {
                    //Tarkistetaan että syöte ei ole tyhjä.
                    if (Syote != "")
                    {
                            //for loop jolla käydää syötteen kirjaimet läpi.
                            for (int i = 0; i < Syote.Length; i++)
                            {
                                //Syötteen ensimmäinen char:in tarkistus.
                                if (i == 0)
                                {  
                                    //Jos se on Isokirjain listassa tarkistukseen lisätään 1.
                                    for (int e = 0; e < IsotKirjaimet.Count; e++)
                                    {
                                        if (Syote[i] == IsotKirjaimet[e])
                                        {
                                            Tarkistus++;
                                        }
                                    }
                                }

                                //Tarkistetaan loput char:it.
                                if (i >= 1)
                                {
                                    //Jos syötteen char on pienetkirjaimet listassa tarkistukseen lisätään 1.
                                    for (int o = 0; o < PienetKirjaimet.Count; o++)
                                    {
                                        if (Syote[i] == PienetKirjaimet[o])
                                        {
                                            Tarkistus++;
                                        }
                                    }
                                }
                            }
                            //Jos riveillä 105-132 saatiin tarkistussummaksi yhtä paljon kuin syötteen pituus while loop lopetetaan.
                            if (Syote.Length == Tarkistus)
                            {
                                break;
                            }
                            //Jos ei niin pyydetään nimeä uudestaan kunnes kunnes saadaan kelvollinen nimi.
                            else
                            {
                                Write("Anna kelvollinen nimi: ");
                                Syote = ReadLine();
                                Tarkistus = 0;
                            }
                    }
                    //Jos syöte oli tyhjä while loop ei pääty.
                    else
                    {
                        Write("Nimi ei voi olla tyhjä, yritä uudestaan: ");
                        Syote = ReadLine();
                        Tarkistus = 0;
                    }
                }
                //Kun on onnistuttu karkaamaan while loopista palautetaan arvo joka oli kelvollinen.
                return Syote;
        }
    }
}
