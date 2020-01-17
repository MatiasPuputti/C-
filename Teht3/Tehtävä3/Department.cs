//Matias Puputti 10.11.2019
using System.Collections.Generic;
using System.Linq;

namespace Tehtävä3
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public int  EmployeeCount { get { return Employees.Count(); } }

        private Department()
        {
            Employees = new List<Employee>();
        }

        public Department(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {EmployeeCount}";
        }
    }
}
