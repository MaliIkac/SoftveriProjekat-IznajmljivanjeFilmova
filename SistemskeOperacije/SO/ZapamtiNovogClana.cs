using Domen.KorisneKlase;


namespace SistemskeOperacije.SO
{
    public class ZapamtiNovogClana : OpstaSistemskaOperacija
    {
        public ZapamtiNovogClana(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            broker.Dodaj(Odo);
        }
    }
}
