using System;

namespace AsiakasRekisteri
{
    class Yritys :Asiakas
    {
        public string YTunnus { get; set; }
        public override string AsiakasId
        {
            get
            {
                return YTunnus;
            }
            set
            {
                if (value.Length == 9)
                {
                    YTunnus = value;
                }
                else
                {
                    throw new Exception("Y-tunnuksen pituus pitää olla 9 merkkiä.");
                }
            }

        }
        public Yritys(string ytunnus, string nimi)
            :base(nimi)
        {
            YTunnus = ytunnus;
        }
    }
}
