using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System.Collections.Generic;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class VratiListuIznajmljivanja : OpstaSistemskaOperacija
    {
        public List<Iznajmljivanje> Lista { get; set; }
        public VratiListuIznajmljivanja(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            Lista = broker.VratiEntitete(new Iznajmljivanje()).Cast<Iznajmljivanje>().ToList();

            var primerciIznajmljeni = broker.VratiEntitete(new IznajmljivanjePrimerak()).Cast<IznajmljivanjePrimerak>().ToList();

            foreach (var iznajmljivanje in Lista)
            {
                iznajmljivanje.Primerci = primerciIznajmljeni.Where(primerak => primerak.Iznajmljivanje.IznajmljivanjeId == iznajmljivanje.IznajmljivanjeId).ToList();
            }
        }
    }
}
