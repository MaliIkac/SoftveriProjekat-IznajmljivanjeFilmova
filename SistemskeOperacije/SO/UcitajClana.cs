using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Linq;

namespace SistemskeOperacije.SO
{
    public class UcitajClana : OpstaSistemskaOperacija
    {
        public UcitajClana(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var clan = Odo as Clan;
            Odo = broker.VratiEntitete(clan, clan.Id())?.Cast<Clan>()?.FirstOrDefault();
            if(Odo == null)
            {
                throw new Exception($"Clan {clan.ClanId} ne postoji u sistemu");
            }
        }
    }
}
