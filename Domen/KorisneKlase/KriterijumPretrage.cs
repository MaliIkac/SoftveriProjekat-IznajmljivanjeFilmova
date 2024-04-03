using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.KorisneKlase
{
    [Serializable]
    public class KriterijumPretrage : OpstiDomenskiObjekat
    {
        public Dictionary<string, object> Kriterijumi = new Dictionary<string, object>();

        public KriterijumPretrage(Dictionary<string, object> kriterijumi)
        {
            Kriterijumi = kriterijumi;
        }

        public string Id()
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

        public string NazivTabele()
        {
            throw new NotImplementedException();
        }

        public string NazivTabeleDodatno()
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

    public static class KriterijumiPretrageKeys
    {
        public const string Tekst = "Tekst";
        public const string Clan = "Clan";
        public const string Zanr = "Zanr";
    }
}
