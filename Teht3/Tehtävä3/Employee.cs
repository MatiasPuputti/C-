//Matias Puputti 10.11.2019
using System;

namespace Tehtävä3
{
    public class Employee
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }
        public int Age
        {
            get
            {
                if (DateOfBirth.HasValue)
                {
                    DateTime Today = DateTime.Now;
                    int? Years = 0;

                    if (Today.Month < DateOfBirth?.Month)
                    {
                        Years = Today.Year - DateOfBirth?.Year - 1;
                    }

                    else if (Today.Month == DateOfBirth?.Month)
                    {
                        if (Today.Day >= DateOfBirth?.Day)
                        {
                            Years = Today.Year - DateOfBirth?.Year;
                        }
                        if (Today.Day < DateOfBirth?.Day)
                        {
                            Years = Today.Year - DateOfBirth?.Year - 1;
                        }
                    }

                    else
                    {
                        Years = Today.Year - DateOfBirth?.Year;
                    }
                    return Years ?? 0;
                }
                else
                {
                    return 0;
                }

            }

        }
        double _salary;
        public double Salary
        {
            get
            {
                return Math.Round(_salary, 2);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Negatiivinen palkka");
                }
                else
                {
                    _salary = value;
                }
            }
        }
        public Employee(int id, string first, string last, DateTime? dob, double salary)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;
            Salary = salary;
            StartDate = DateTime.Now;
            EndDate = null;
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName}";
        }

    }
}
