using System;
using System.Collections.Generic;
using static System.Console;

namespace AsiakasRekisteri
{
    class Program
    {
        static Random rnd = new Random();
        public enum AsiakasTila
        {   Aktiivinen = 1,
            Prospekti = 2,
            Poistunut = 3
        };
        static void Main(string[] args)
        {
            try
            {
                var Asiakkaat = new List<Asiakas>();
                int HenkiloAs, YritysAs;
                HenkiloAs = YritysAs = 0;
                string syote;
                syote = "Placeholder";

                foreach (Henkilo i in GeneroiHenkiloita(30))
                {
                    Asiakkaat.Add(i);
                }

                foreach (Yritys i in GeneroiYrityksia(10))
                {
                    Asiakkaat.Add(i);
                }

                for (int i = 0; i < Asiakkaat.Count; i++)
                {
                    if (Asiakkaat[i].Tila == (AsiakasTila)1 && Asiakkaat[i] is Henkilo)
                    {
                        HenkiloAs += 1;
                    }

                    if (Asiakkaat[i].Tila == (AsiakasTila)1 && Asiakkaat[i] is Yritys)
                    {
                        YritysAs += 1;
                    }
                }
                WriteLine($"Aktiivisia henkilöasiakkaita on {HenkiloAs} ja yritysasiakkaita {YritysAs}.");
                WriteLine();
                while (syote != "")
                {
                    Write("Anna nimen osa (tyhjä lopettaa):");
                    syote = ReadLine();
                    if (syote != "")
                    {
                        for (int e = 0; e < Asiakkaat.Count; e++)
                        {
                            if (Asiakkaat[e].Nimi.Contains(syote) && Asiakkaat[e] is Henkilo)
                            {
                                WriteLine($"Henkilö: {Asiakkaat[e]}, tila: {Asiakkaat[e].Tila}");
                            }

                            if (Asiakkaat[e].Nimi.Contains(syote) && Asiakkaat[e] is Yritys)
                            {
                                WriteLine($"Yritys: {Asiakkaat[e]}, tila: {Asiakkaat[e].Tila}");
                            }
                        }
                    }
                }
            }
            catch (Exception i)
            {
                WriteLine("Ohjelman suoritus päättyi virheeseen");
                WriteLine($"Virhe:{i.Message}");
            }
        }
        static List<Henkilo> GeneroiHenkiloita(int lkm)
            {
                List<Henkilo> paluu = new List<Henkilo>();
                string[] etunimet = { "Mikko", "Maija", "Timo", "Siiri", "Matti", "Aino", "Aleksi", "Liisa" };
                string[] sukunimet = { "Aaltonen", "Mäkinen", "Virtanen", "Jokinen" };
                DateTime pvm = new DateTime(1940, 1, 1);
                int nro, etunimi_indeksi;
                string hetu, etunimi, sukunimi, merkit = "0123456789ABCDEFHJKLMNPRSTUVWXY";

                for (int i = 0; i < lkm; i++)
                {
                    pvm = pvm.AddDays(rnd.Next(1, 365 * 60));
                    etunimi_indeksi = rnd.Next(0, etunimet.Length);
                    etunimi = etunimet[etunimi_indeksi];
                    sukunimi = sukunimet[rnd.Next(0, sukunimet.Length)];
                    nro = rnd.Next(100, 999);
                    if (etunimi_indeksi % 2 == 0 && nro % 2 == 0)
                    {
                        nro++;
                    }
                    if (etunimi_indeksi % 2 == 1 && nro % 2 == 1)
                    {
                        nro++;
                    }
                    hetu = string.Format("{0:ddMMyy}", pvm) + "-" + nro +
                        merkit[int.Parse(string.Format("{0:ddMMyy}", pvm) + nro.ToString()) % 31];
                    paluu.Add(new Henkilo(hetu, sukunimi, etunimi) { Tila = (AsiakasTila)rnd.Next(1, 4) });
                }

                return paluu;
            }
            static List<Yritys> GeneroiYrityksia(int lkm)
            {
                List<Yritys> paluu = new List<Yritys>();
                string[] nimet = { "Siivous", "Rakennus", "Varastointi", "Kirjanpito", "Kuljetus" };
                string[] nimet2 = { "Aaltonen", "Mäkinen", "Virtanen", "Jokinen" };
                string nimi, ytunnus;
                for (int i = 0; i < lkm; i++)
                {
                    int nro = rnd.Next(1000000, 9999999);
                    int tarkiste = (nro.ToString()[0] * 7 + nro.ToString()[1] * 9 + nro.ToString()[2] * 10 +
                                    nro.ToString()[3] * 5 + nro.ToString()[4] * 8 + nro.ToString()[5] * 4 +
                                    nro.ToString()[6] * 2) % 11;
                    if (tarkiste == 1)
                    {
                        nro++;
                        tarkiste = (nro.ToString()[0] * 7 + nro.ToString()[1] * 9 + nro.ToString()[2] * 10 +
                                    nro.ToString()[3] * 5 + nro.ToString()[4] * 8 + nro.ToString()[5] * 4 +
                                    nro.ToString()[6] * 2) % 11;
                    }
                    if (tarkiste >= 2 && tarkiste <= 10)
                    {
                        tarkiste = 11 - tarkiste;
                    }
                    nimi = nimet[rnd.Next(0, nimet.Length)] + " " + nimet2[rnd.Next(0, nimet2.Length)];
                    ytunnus = nro.ToString() + "-" + tarkiste.ToString();
                    paluu.Add(new Yritys(ytunnus, nimi) { Tila = (AsiakasTila)rnd.Next(1, 4) });
                }

                return paluu;
            }
        
    }
}
