//Matias Puputti 10.11.2019
using System;
using static System.Console;

namespace Tehtävä3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Application.Run();
            }
            catch (Exception Error)
            {
                Clear();
                WriteLine(Error.Message);
                WriteLine("Paina enter lopettaaksesi");
                ReadLine();
            }
        }
    }
}
