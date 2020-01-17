//Matias Puputti 3.10.2019
using System;
using static System.Console;

namespace Tehtävä2
{
    //Ohjeen määrittelemä program luokka.
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Application.Run();
            }
            catch (Exception FreakOfNatureOrNaturalDisaster)
            {
                WriteLine($"Ohjelman suoritus päättyi virheeseen{FreakOfNatureOrNaturalDisaster}");
            }
        }
    }
}
