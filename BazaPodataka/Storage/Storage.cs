using Domen.KorisneKlase;
using System.Collections.Generic;
using System.Linq;

namespace Server.Storage
{
    public class Storage
    {
        private static Storage instanca;
        public List<Administrator> Administratori = new List<Administrator>()
        {
            new Administrator("iva", "iva"),
            new Administrator("anja","anja")
        };

        private Storage()
        {

        }

        public static Storage Instanca
        {
            get
            {
                if (instanca == null) instanca = new Storage();
                return instanca;
            }
        }

        public bool PostojiAdministrator(Administrator administrator)
        {
            return Administratori.Any(admin => admin.Korisnicko == administrator.Korisnicko && admin.Sifra == administrator.Sifra);
        }
    }
}
