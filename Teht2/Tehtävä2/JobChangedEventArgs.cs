// Matias Puputti 3.10.2019

namespace Tehtävä2
{
    //Ohjeen määrittelemä EventArgs.
    class JobChangedEventArgs : System.EventArgs
    {
        public Job Job { get; set; }
    }
}
