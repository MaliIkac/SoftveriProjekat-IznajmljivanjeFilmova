using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class PretraziClanove : OpstaSistemskaOperacija
    {
        public List<Clan> Lista { get; set; }
        public PretraziClanove(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var kp = Odo as KriterijumPretrage;
            var clan = new Clan();
            Lista = broker.VratiEntitete(clan, clan.Search(kp)).Cast<Clan>().ToList();

            if (!Lista.Any())
            {
                throw new InvalidOperationException("Sistem ne moze da pronadje entitet po zadatom kriterijumu");
            }
        }
    }
}
