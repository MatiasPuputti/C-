//Matias Puputti 17.10.2019
using System;
using System.Threading;
using System.Collections.Generic;
using static System.Console;
using System.Threading.Tasks;

namespace Teht4
{
    static class Application
    {
        static public int LastOperationId = 0;
        static public List<Operation> Operations = new List<Operation>();
        static public Random r = new Random();
        static public int MaxBreaks = 10;
        static public int MinTimeInSeconds = 5;
        static public int MaxTimeInSeconds = 10;

        static public void PrintOperations(List<Operation> Lista)
        {
            foreach (var item in Lista)
            {
                item.PrintEnded();
            }
        }

        public static async Task KaynnistaOperaatioAsync(Operation Operaatio)
        {
            await Task.Run(() =>
            {
                for (int i = 1; i <= Operaatio.Breaks; i++)
                {
                    Thread.Sleep((int)((Operaatio.TotalTimeInSeconds  / (double)Operaatio.Breaks) * 1000));                   
                    Operaatio.SpendTimeInSeconds = (int)(Operaatio.TotalTimeInSeconds * i  / (double)Operaatio.Breaks);
                    Operaatio.Print();
                }
            });
            Operaatio.Ended = DateTime.Now;

        }

        public static void Run()
        {
            bool Suoritetaan = true;
            string kaynnista = "Käynnistä uusi operaatio = K, Lopeta = L: ";

            for (int i = 0; i < 59; i++)
            {
                Write(" ");
            }

            CursorLeft = 0;
            Write(kaynnista);

            string syote = ReadLine();

            while (Suoritetaan)
            {
                if (syote == "L" || syote == "l")
                {
                    Suoritetaan = false;
                    CursorTop = 0;
                    CursorLeft = 0;

                    for (int i = 0; i < 59; i++)
                    {
                        Write(" ");
                    }

                    CursorTop = 0;
                    CursorLeft = 0;
                    WriteLine("Paina enter, kun kaikki operaatiot on suoritettu");
                    PrintOperations(Operations);
                    CursorVisible = false;
                }

                else if (syote == "K" || syote == "k")
                {

                    CursorTop = 0;
                    for (int i = 0; i < 59; i++)
                    {
                        Write(" ");
                    }
                    CursorLeft = 0;

                    Write(kaynnista);
                    LastOperationId += 1;
                    Operation Operaatio = new Operation() {Id = LastOperationId, Breaks = r.Next(1, MaxBreaks), TotalTimeInSeconds = r.Next(MinTimeInSeconds, MaxTimeInSeconds) };
                    Operations.Add(Operaatio);

                    KaynnistaOperaatioAsync(Operaatio);
                }

                else
                {
                    CursorTop = 0;
                    for (int i = 0; i < 59; i++)
                    {
                        Write(" ");
                    }
                    CursorLeft = 0;
                    Write(kaynnista);
                }
                syote = ReadLine();
            }
        }
    }
}
