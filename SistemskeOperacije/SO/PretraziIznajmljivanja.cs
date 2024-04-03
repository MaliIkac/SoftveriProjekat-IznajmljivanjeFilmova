using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemskeOperacije.SO
{
    public class PretraziIznajmljivanja : OpstaSistemskaOperacija
    {
        public List<Iznajmljivanje> Lista { get; set; }
        public PretraziIznajmljivanja(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var kp = Odo as KriterijumPretrage;
            var iznajmljivanjeEntity = new Iznajmljivanje();

            Lista = broker.VratiEntitete(iznajmljivanjeEntity, iznajmljivanjeEntity.Search(kp)).Cast<Iznajmljivanje>().ToList();

            if (!Lista.Any())
            {
                throw new InvalidOperationException("Sistem ne moze da pronadje entitet po zadatom kriterijumu");
            }

            var primerciIznajmljeni = broker.VratiEntitete(new IznajmljivanjePrimerak()).Cast<IznajmljivanjePrimerak>().ToList();

            foreach (var iznajmljivanje in Lista)
            {
                iznajmljivanje.Primerci = primerciIznajmljeni.Where(primerak => primerak.Iznajmljivanje.IznajmljivanjeId == iznajmljivanje.IznajmljivanjeId).ToList();
            }
        }
    }
}
