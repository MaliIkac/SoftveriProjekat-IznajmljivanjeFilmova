using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.KorisneKlase
{
    [Serializable]
    public class Administrator : OpstiDomenskiObjekat
    {
        public string Korisnicko { get; set; }
        public string Sifra { get; set; }

        public Administrator(string korisnicko, string sifra)
        {
            Korisnicko = korisnicko;
            Sifra = sifra;
        }

        public override bool Equals(object obj)
        {
            return obj is Administrator administrator &&
                   Korisnicko == administrator.Korisnicko &&
                   Sifra == administrator.Sifra;
        }

        public string NazivTabele()
        {
            throw new NotImplementedException();
        }

        public string NazivTabeleDodatno()
        {
            throw new NotImplementedException();
        }

        public string InsertValues()
        {
            throw new NotImplementedException();
        }

        public string Join()
        {
            throw new NotImplementedException();
        }

        public string Id()
        {
            throw new NotImplementedException();
        }

        public string Search(KriterijumPretrage kriterijum)
        {
            throw new NotImplementedException();
        }

        public List<OpstiDomenskiObjekat> Select(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        public string UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
