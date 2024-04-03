using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class RazduziIznajmljivanje : OpstaSistemskaOperacija
    {
        public RazduziIznajmljivanje(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var iznajmljivanje = Odo as Iznajmljivanje;

            var ip = new IznajmljivanjePrimerak()
            {
                Iznajmljivanje = iznajmljivanje
            };

            var primerci =  broker.VratiEntitete(ip, $"WHERE ip.iznajmljivanjeId = {iznajmljivanje.IznajmljivanjeId}")?.Cast<IznajmljivanjePrimerak>().Select(e => e.Primerak);

            if (primerci != null)
            {
                foreach(var primerak in primerci)
                {
                    primerak.Raspolozivost = true;
                    broker.Izmeni(primerak);
                }
            }

            broker.Obrisi(ip);
            broker.Obrisi(iznajmljivanje);
        }
    }
}
