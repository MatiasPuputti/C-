// Matias Puputti 3.10.2019
using System.Collections.Generic;

namespace Tehtävä2
{
    //Ohjeen määrittelemä Employee luokka.
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Job> Jobs = new List<Job>();
    }
}
