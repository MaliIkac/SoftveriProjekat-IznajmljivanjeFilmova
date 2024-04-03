using Domen.KorisneKlase;
using Server.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije.SO
{
    public class PrijaviAdministratora : OpstaSistemskaOperacija
    {
        public PrijaviAdministratora(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            if (!Storage.Instanca.PostojiAdministrator(Odo as Administrator))
            {
                throw new Exception("Ne postoji administrator sa unetim kredencijalima");
            }
        }
    }
}
