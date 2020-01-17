using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace NoppaPeli
{
    //Virhesietoinen Program class.
    class Program
    {
        static void Main(string[] args)                                                                                                                                                                         //				                ***
        {                                                                                                                                                                                                       //                           *       *
            try                                                                                                                                                                                                 //                         *           *
            {                                                                                                                                                                                                   //                        *   Matias    * 
                Sovellus.Aja();                                                                                                                                                                                 //                       *    Puputti    *
            }                                                                                                                                                                                                   //                       *    NEA18SPC   *
            catch (Exception i)                                                                                                                                                                                 //                       *    27.3.2019  *
            {                                                                                                                                                                                                   //                        *             * 
                WriteLine("Ohjelman suoritus päättyi virheeseen.");                                                                                                                                                          //                         *           *
                WriteLine($"Virhe:{i.Message}");                                                                                                                                                                //                           *       * 
            }                                                                                                                                                                                                   //                              ***  
            WriteLine("Paina Enter lopettaaksesi...");
            ReadLine();
        }
    }
}