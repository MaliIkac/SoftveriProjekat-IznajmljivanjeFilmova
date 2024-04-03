using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class UcitajIznajmljivanje : OpstaSistemskaOperacija
    {
        public UcitajIznajmljivanje(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var iznajmljivanje = Odo as Iznajmljivanje;
            Odo = broker.VratiEntitete(iznajmljivanje, iznajmljivanje.Id())?.Cast<Iznajmljivanje>()?.FirstOrDefault();
            if (Odo == null)
            {
                throw new Exception($"Clan {iznajmljivanje.IznajmljivanjeId} ne postoji u sistemu");
            }
        }
    }
}
