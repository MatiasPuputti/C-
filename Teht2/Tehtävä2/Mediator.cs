// Matias Puputti 3.10.2019
using System;

namespace Tehtävä2
{
    //Ohjeen määrittelemä Mediator luokka.
    sealed class Mediator
    {
        private static Mediator instance = new Mediator();
        public static Mediator Instance { get { return instance; } }
        private Mediator() { }
        public event EventHandler<JobChangedEventArgs> JobChanged;

        public void OnJobChanged(object sender, Job job)
        {
            Delegate JobChangeDelegate = JobChanged as EventHandler<JobChangedEventArgs>;
            if (JobChangeDelegate != null)
            {
                JobChangedEventArgs Event1 = new JobChangedEventArgs();
                Event1.Job = job; 
                JobChanged(sender, Event1);
            }
        }
    }
}
