namespace AsiakasRekisteri
{
    abstract class Asiakas : IAsiakas
    {
        public virtual string AsiakasId { get; set; }
        public virtual string Nimi { get; set; }
        public Program.AsiakasTila Tila { get; set; }

        public Asiakas (string Arvo)
        {
            Nimi = Arvo;
            Tila = (Program.AsiakasTila)1;
        }

        public override string ToString()
        {
            return $"{AsiakasId} {Nimi}";
        }
    }
}
