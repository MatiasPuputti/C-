//Matias Puputti 10.11.2019
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Reflection;

namespace Tehtävä3
{
    public static class Application
    {
        static List<MenuItem> Menu;
        static void WriteResult<T>(int itemid, List<T> result)
        {
            string row;
            //otsikkorivit
            WriteLine();
            WriteLine(Menu.Where(mi => mi.Id == itemid).First().Name.ToUpper());
            WriteLine("-".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '-'));
            //sarakeotsikkorivit
            if (result.Count > 0)
            {
                row = "";
                foreach (PropertyInfo property in result[0].GetType().GetProperties())
                {
                    row += $"{property.Name}".PadRight(16) + " | ";
                }
                WriteLine(row);
            }
            WriteLine("-".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '-'));
            //datarivit
            foreach (object item in result)
            {
                row = "";
                foreach (PropertyInfo property in item.GetType().GetProperties())
                {
                    row += $"{property.GetValue(item, null).ToString()}".PadRight(16) + " | ";
                }
                WriteLine(row);
            }
            WriteLine("-".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '-'));
            WriteLine();
            Write("Paina Enter jatkaaksesi.");
            ReadLine();
        }
        public static void InitializeMenu()
        {
            Menu = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Name = "50-vuotiaat työntekijät" },
                new MenuItem() { Id = 2, Name = "Osastot yli 50 henkilöä" },
                new MenuItem() { Id = 3, Name = "Sukunimen työntekijät" },
                new MenuItem() { Id = 4, Name = "Osastojen isoimmat palkat" },
                new MenuItem() { Id = 5, Name = "Viisi yleisintä sukunimeä" },
                new MenuItem() { Id = 6, Name = "Osastojen ikäjakaumat" }
            };

            Menu[0].ItemSelected += AgeHandler;
            Menu[1].ItemSelected += DepartmentSizeHandler;
            Menu[2].ItemSelected += LastnameHandler;
            Menu[3].ItemSelected += BigestSalaryHandler;
            Menu[4].ItemSelected += MostCommonLastNameHandler;
            Menu[5].ItemSelected += AgeDistrubationhandler;

            void AgeHandler(object sender, MenuItemEventArgs e)
            {
                var hlo1 = from hloo in Data.Employees
                           where hloo.Age == 50
                           select new
                           {
                              Nimi = hloo.Name,
                              Ikä = hloo.Age,
                              Osasto = hloo.Department
                           };
                WriteResult(e.Itemid, hlo1.ToList());

            }

            void DepartmentSizeHandler(object sender, MenuItemEventArgs e)
            {
                var Departments = from deps in Data.Departments
                                  where deps.EmployeeCount > 50
                                  select new
                                    { 
                                      deps.Id,
                                      Nimi = deps.Name,
                                      Vahvuus =  deps.EmployeeCount
                                    };

                WriteResult(e.Itemid, Departments.ToList());
            }

            void LastnameHandler(object sender, MenuItemEventArgs e)
            {
                WriteLine("Anna sukunimi:");
                string Sukunimi = ReadLine();

                var Lastnames = from empl in Data.Employees
                                  where empl.LastName == Sukunimi
                                  select new
                                  {
                                      empl.Id,
                                      Name = $"{empl.FirstName}  {empl.LastName}"
                                  };
                WriteResult(e.Itemid, Lastnames.ToList());
            }

            void BigestSalaryHandler(object sender, MenuItemEventArgs ei)
            {
                var Results = from Palkka in Data.Departments.SelectMany(d => d.Employees, (d, e) => new { Osasto = d.Name, Palkka = e.Salary })
                              group Palkka by Palkka.Osasto into g
                              select new
                              {
                                  Osasto = g.Key,
                                  Maksimipalkka = g.Select(d => d.Palkka).Max()
                              };

                WriteResult(ei.Itemid, Results.ToList());
            }

            void MostCommonLastNameHandler(object sender, MenuItemEventArgs e)
            {
                var result = Data.Employees
                                        .GroupBy(henk => henk.LastName)
                                        .OrderByDescending(grp => grp.Count())
                                        .Take(5)
                                        .Select(grhenk => new
                                        {
                                            Sukunimi = grhenk.Key,
                                            Lkm = grhenk.Count()
                                        }).ToList();

                WriteResult(e.Itemid, result);
            }

            void AgeDistrubationhandler(object sender, MenuItemEventArgs e)
            {

                var Result = Data.Departments.Select(dep => new
                {
                    Nimi = dep.Name,
                    Alle30v = dep.Employees.Where(emp => emp.Age < 30).Count(),
                    välillä30_50v = dep.Employees.Where(emp => emp.Age > 30 && emp.Age < 50).Count(),
                    Yli50v = dep.Employees.Where(emp => emp.Age > 50).Count()
                }).ToList();

                WriteResult(e.Itemid, Result);
            }
        }

        static void Initialize()
        {
            Data.GenerateData();
            InitializeMenu();
        }
        
        static int ReadFromMenu()
        {
            string syöte;
            int Valinta = 0;
            bool Syötevaarin = true;

                Clear();
                WriteLine("Vaihtoehdot");

                foreach (var items in Menu)
                {
                    WriteLine(items.ToString());
                }

                Write("Valitse (0 = lopetus):");
                syöte = ReadLine();


                while (Syötevaarin)
                {
                    List<string> sallitut = new List<string>() { "0", "1", "2", "3", "4", "5", "6" };

                    for (int i = 0; i < sallitut.Count(); i++)
                    {
                        if (syöte == sallitut[i])
                        {
                            Valinta = Int32.Parse(syöte);
                            Syötevaarin = false; 
                        }
                    }
                    
                    if(Syötevaarin)
                    {
                        Clear();
                        WriteLine("Vaihtoehdot");
                        foreach (var items in Menu)
                        {
                            WriteLine(items.ToString());
                        }
                        Write("Syöte väärin, valitse numeroiden 0 - 6 Väliltä: ");
                        syöte = ReadLine();
                    }
                }

            return Valinta;
        }

        public static void Run()
        {
            Initialize();
            int Valinta = ReadFromMenu();

            while (Valinta != 0)
            {
                Menu[Valinta - 1].Select();
                Valinta = ReadFromMenu();
            }
            WriteLine("Ohjelma päättyi, paina enter.");
            ReadLine();
        }       
    }
}
