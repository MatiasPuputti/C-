using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Palindromi
{
    class Program
    {
        /*Ohjelman aloitusmetodi, jolla halusin saada static void mainin näyttämään siistimmältä.*/
        static void Main(string[] args) => Aloitus();

        /*Ohjelman Suoritusmetodi. */
        static void Aloitus()                                                   
        {
            /*Suorittaa ohjelmaa kunnes rivin 26 ehto täyttyy.*/
            string syote;
            do                                                  
            {
                Write("Anna teksti (Tyhjä lopettaa):");
                syote = ReadLine();

                /*Poistaa sanasta/lauseesta virheelliset merkit.*/
                Poistamerkit(syote);

                /*Kääntää saamansa sanan/lauseen.*/
                Kaanna(Poistamerkit(syote));

                /*Tarkistaa vastaako alkuperäinen sana käännettyä sanaa.*/
                Tarkista(syote, Kaanna(Poistamerkit(syote)));   

            } while (syote != "");
        }

        /*Poistaa virheelliset merkit syötteestä.*/
        static string Poistamerkit(string Sana)
        {
            var charsToRemove = new string[] { " ", ".", ":", ";", ",", "!", "?" };
            foreach (var c in charsToRemove)
            {
                Sana = Sana.Replace(c, string.Empty);
            }
            return Sana;
        }

        /*Kääntää saamansa syötteen ja palauttaa käännetyn syötteen.*/
        static string Kaanna(string kaannos)
        {
            kaannos = new string(kaannos.Reverse().ToArray());
            return kaannos;
        }

        /*Tarkistaa vastaavatko alkuperäinen syöte ja käännetty syöte toisiaan.*/
        static void Tarkista(string alkuperainen, string kaanetty)
        {
            if (alkuperainen == kaanetty)
            {
                WriteLine($"{kaanetty} on palindromi.");
                WriteLine();
            }
            else
            {
                WriteLine($"{alkuperainen} ei ole palindromi.");
                WriteLine();
            }
        }           
    }
}                                                                               /*Matias Puputti 4/2/2018 */
