using Domen.KorisneKlase;


namespace SistemskeOperacije.SO
{
    public class ObrisiClana : OpstaSistemskaOperacija
    {
        public ObrisiClana(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            broker.Obrisi(Odo);
        }
    }
}
