using Domen.KonceptualneKlase;
using Domen.KorisneKlase;

namespace SistemskeOperacije.SO
{
    public class ZapamtiNovoIznajmljivanje : OpstaSistemskaOperacija
    {
        public ZapamtiNovoIznajmljivanje(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var iznajmljivanje = Odo as Iznajmljivanje;
            iznajmljivanje.IznajmljivanjeId = broker.Dodaj(iznajmljivanje);

            foreach (var primerak in iznajmljivanje.Primerci)
            {
                primerak.Iznajmljivanje = iznajmljivanje;
                primerak.Primerak.Raspolozivost = false;
                broker.Dodaj(primerak);
                broker.Izmeni(primerak.Primerak);
            }
        }
    }
}
