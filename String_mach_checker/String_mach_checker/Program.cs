using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace String_mach_checker
{
    class Program
    {
        static void Main(string[] args)
        {
            Checker();
        }
        static void Checker()
        {
            bool Run = true;
            while (Run)
            {
                Write("Anna ensimmäinen syöte: ");
                string eka = ReadLine();
                Write("Anna toinen syöte: ");
                string toinen = ReadLine();

                if (eka.Length > 0)
                {
                    if (eka.Length == toinen.Length)
                    {
                        int Correct = 0;
                        for (int i = 0; i < eka.Length; i++)
                        {
                            if (eka[i] == toinen[i])
                            {
                                Correct += 1;
                            }
                        }
                        if (eka.Length == Correct)
                        {
                            WriteLine("Syötteet vastaavat toisiaan!");
                        }

                        else
                        {
                            WriteLine("syötteet eivät vastaa toisiaan!");
                        }
                    }
                    else
                    {
                        WriteLine("syötteet eivät vastaa toisiaan!");
                    }
                }
                else
                {
                    Run = false;
                }
            }
        }
    }
}
