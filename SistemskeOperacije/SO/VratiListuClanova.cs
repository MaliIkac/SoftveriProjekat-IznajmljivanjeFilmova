using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System.Collections.Generic;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class VratiListuClanova : OpstaSistemskaOperacija
    {
        public List<Clan> Lista { get; set; }
        public VratiListuClanova(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            Lista = broker.VratiEntitete(new Clan()).Cast<Clan>().ToList();
        }
    }
}
