// Matias Puputti 3.10.2019
using System;

namespace Tehtävä2
{
    //Ohjeen määrittelemä Job luokka.
    class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
