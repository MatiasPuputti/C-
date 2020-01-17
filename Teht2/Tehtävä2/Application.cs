// Matias Puputti 3.10.2019
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Tehtävä2
{
    //Luokka Aplication joka toimii ohjelman ytimenä.
    static class Application
    {
        //ConsoleControl muuttujat.
        private static ConsoleControl JobMenu;
        private static ConsoleControl JobDetails;
        private static ConsoleControl JobEmployees;

        //Ohjeen määrittelemä metodi BindMenuData jossa populoidaan muuttujan JobMenu ominaisuus Items.
        private static void BindMenuData(List<Job> Titles)
        {
            //Jos JobMenu.Items on null luodaan sille arvoksi merkkijonolista.
            if (JobMenu.Items == null)
            {
                JobMenu.Items = new List<string>();
            }

            //Lisätään edellä tehtyyn listaan töiden id ja title muodossa ("1 Siiven C luokkien ylläpito").
            for (int i = 0; i < Titles.Count; i++)
            {
                JobMenu.Items.Add($"{Titles[i].Id} {Titles[i].Title}");
            }
        }

        //Ohjeen määrittelemä metodi BindDetailsData .
        private static void BindDetailsData(Job JTitle)
        {
            //Jos JobDetails.Items on null luodaan sille arvoksi merkkijonolista.
            if (JobDetails.Items == null)
            {
                JobDetails.Items = new List<string>();
            }
            //Jos lista on olemassa, se pyyhitään jotta se saadaan päivitettyä uusilla arvoilla.  
            else
            {
                JobDetails.Items.Clear();
            }
            //Lisätään listaan uudet arvot.
            JobDetails.Items.Add("TYÖN TIEDOT");
            JobDetails.Items.Add($"Id: {JTitle.Id}");
            JobDetails.Items.Add($"Nimi: {JTitle.Title}");
            JobDetails.Items.Add($"Alkaa: {JTitle.StartDate.ToShortDateString()}");
            JobDetails.Items.Add($"Loppuu: {JTitle.EndDate.ToShortDateString()}");
        }
        //Ohjeen määrittelemä metodi BindEmployeesData
        private static void BindEmployeesData(Job JTitle)
        {
            //Jos JobEmployees.Items listaa ei ole olemassa luodaan se.
            if (JobEmployees.Items == null)
            {
                JobEmployees.Items = new List<string>();
            }
            //Jos se on olemassa pyyhitään se jotta sille saadaan annettua uudet arvot.
            else
            {
                JobEmployees.Items.Clear();
            }

            //Lisätään listalle "Otsikko".
            JobEmployees.Items.Add("TYÖN TEKIJÄT");

            //Lisään listalle työntekijät jotka ovat mukana parametrina annetussa työssä.
            for (int e = 0; e < Data.employees.Count; e++)
            {
                for (int o = 0; o < Data.employees[e].Jobs.Count; o++)
                {
                    if (Data.employees[e].Jobs[o].Id == JTitle.Id)
                    {
                        JobEmployees.Items.Add(Data.employees[e].Name);
                    }
                }
            }
        }

        //Ohjeen määrittelemä Initialize metodi.
        private static void Initialize()
        {
            //Consolecontrol olioiden ominaisuuksien määrittely.
            JobMenu = new ConsoleControl(1, 2, WindowWidth / 2 - 1, Data.jobs.Count());
            JobDetails = new ConsoleControl(WindowWidth / 2 + 1, 2, WindowWidth / 2 - 1, 5);
            JobEmployees = new ConsoleControl(WindowWidth / 2 + 1, JobDetails.Height + 3, WindowWidth / 2 - 1, WindowHeight - JobDetails.Height - 1);

            //Olioden tekstivärin asettaminen.
            JobMenu.TextColor = ConsoleColor.DarkBlue;
            JobDetails.TextColor = ConsoleColor.DarkGreen;
            JobEmployees.TextColor = ConsoleColor.DarkRed;

            //Menuvalikon muuttujien asetus/mahdollinen päivitys.
            BindMenuData(Data.jobs);

            //Mediaattorille asetettu tapahtumanseuranta.
            Mediator.Instance.JobChanged += InsJobChanged;
        }

        //Mediator oliolle asetteu tapahtumanhallinta, jossa päivitetään työn tiedot ja osallistujat, kun annetaan uusi arvo.
        private static void InsJobChanged(object sender, JobChangedEventArgs e)
        {
            BindDetailsData(e.Job);
            BindEmployeesData(e.Job);
        }

        //Uuden arvon saatuaan päivitetään käyttäjälle näytettävät arvot.
        private static void MenuSelectionChanged(int Compare)
        {
            for (int u = 0; u < Data.jobs.Count; u++)
            {
                if (Data.jobs[u].Id == Compare)
                {
                    Mediator.Instance.OnJobChanged(JobMenu, Data.jobs[u]);
                }

            }
            //Työntietojen päivitys.
            for (int i = 0; i < JobDetails.Items.Count; i++)
            {
                JobDetails.Draw();
            }
            //Työntekijöiden päivitys.
            for (int i = 0; i < 1; i++)
            {
                JobEmployees.Draw();
            }
        }
        //Julkinen ohjelman ajo metodi.
        public static void Run()
        {
            //Aloitetaan ohjelma määrittelemällä muuttjat ja piirtämällä valikko.
            bool NotEnd = true;
            int OldValue = 7;
            Initialize();
            JobMenu.Draw();
            //Suoritetaan while looppia kunnes käyttäjä haluaa lopettaa ohjelman (syöttää nollan).
            while (NotEnd)
            {
                Write("Valitse työn id (nolla lopettaa):");
                int Value = InputInspector(ReadLine());
                Console.SetCursorPosition(0, 0);

                //Annettessa uusi arvo päivitetään tiedot. Tarkistetaan myös että annettu arvo on uusi, ettei tietoja ja ohjelmaa ajeta "turhaan".
                if (Value != 0 && Value != OldValue)
                {
                    MenuSelectionChanged(Value);
                    OldValue = Value;
                }
                //Jos annettu syöte on 0 ohjelman suoritus loop päättyy.
                else if (Value == 0)
                {
                    NotEnd = false;
                }
            }
            Write("Ohjelma suljetaan, paina Enter.");
            ReadLine();
        }

        //Metodi jossa syöte tarkistetaan ja kehotteen ensimmäinen rivi päivitetään.
        private static int InputInspector(string Input)
        {
            //Muuttujien määrittely ja sallitut merkit.
            List<string> Accepted = new List<string>() { "0", "1", "2", "3", "4" };
            bool UnAccepted = true;
            int Inspected = 100500;

            //Loop jossa tarkistetaan syöte pakottaen.
            while (UnAccepted)
            {
                //Syötteen tarkistus aloitetaan tarkistamalla sen pituus.
                if (Input.Length == 1)
                {
                    //Jos syötteen pituus sallittu, tarkistetaan onko se joku sallituista "merkkijonoista".
                    for (int i = 0; i < Accepted.Count; i++)
                    {
                        //Jos syöte on joku sallituista "merkkijonoista" päästetään käyttäjä pois loopista muuttamalla UnAccepted boolean.
                        if (Input == Accepted[i])
                        {
                            Inspected = Int32.Parse(Input);
                            UnAccepted = false;
                        }
                    }
                }

                //Jos annettu syöte taas ei ollut ehtojen mukainen, pyydetään sitä uudestaan kunnes saadaan hyväksyttävä syöte.
                if (UnAccepted)
                {
                    //Asetetaan kursori vasempaan ylänurkkaan.
                    SetCursorPosition(0, 0);

                    //writeline jolla pyyhitään annettu ehtojen vastainen syöte.
                    Write("                                                                           ");

                    //Asetetaan kursori takaisin nurkkaan viestin tulostamiseksi.
                    SetCursorPosition(0, 0);
                    Write("Virheellinen syöte. Anna luku väliltä 0 - 4 ja paina Enter:");

                    //Syötteen uudelleen asetus.
                    Input = ReadLine();
                }
            }
            //Jos annettu syöte hyväksyttiin pyyhitään virheteksti, jotta voidaan tulostaa seuraava viesti;
            SetCursorPosition(0, 0);
            Write("                                                                                     ");

            //Palautetaan hyväksytty syöte.
            return Inspected;
        }
    }
}


