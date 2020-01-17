using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Kansioden_koko
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*Method for running the program, and since the end user is the enemy i have hard coded the folder path here.*/
                WriteLine($"Steam kansion koko: {Koonmuunto(DirSize(new DirectoryInfo("D:/Steam")))}GB");
            }

            /*Catch block and error message if the program encounters errors.*/
            catch (Exception e)
            {
                WriteLine("Ohjelman suoritus päättyi odottamattomasti virheilmoituksella: ");
                WriteLine(e.Message);
            }

            /*Readline to keep the console window open.*/
            ReadLine();
        }
        static double DirSize(DirectoryInfo d)
        {
            /*Variable for the size of the directory.*/
            double size = 0;
            
            /*Gets all the file sizes in the specified directory.*/
            FileInfo[] fis = d.GetFiles();

            /*Sums all the sizes.*/
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            
            /*Gets paths of subdirectories.*/
            DirectoryInfo[] dis = d.GetDirectories();

            /*Sums all the subdirectory files.*/
            foreach (DirectoryInfo di in dis)
            {
                /*Sums sizes by calling the earlier loop recursively.*/
                size += DirSize(di);
            }

            /*Returns the size of all the files under specified folder.*/
            return size;
        }

        /*Converts the size from bytes to gigabytes, since this is the more readable and appropriate multiple for the use */
        static string Koonmuunto(double koko)
        {
            koko = koko / (1073741824);
            string koko2;
            koko2 = String.Format("{0:0.00}", koko);
            return koko2;

        }
    }
}
          
    
        
        




