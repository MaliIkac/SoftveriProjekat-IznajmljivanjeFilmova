using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System.Collections.Generic;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class VratiListuGlumaca : OpstaSistemskaOperacija
    {
        public List<Glumac> Lista { get; set; }
        public VratiListuGlumaca(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            Lista = broker.VratiEntitete(new Glumac()).Cast<Glumac>().ToList();
        }
    }
}
