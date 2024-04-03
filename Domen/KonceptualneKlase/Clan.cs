using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.KonceptualneKlase
{
    [Serializable]
    public class Clan : OpstiDomenskiObjekat
    {
        [Browsable(false)]
        public int ClanId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Kontakt { get; set; }

        public Clan()
        {
        }

        public Clan(int clanId, string ime, string prezime, string kontakt)
        {
            ClanId = clanId;
            Ime = ime;
            Prezime = prezime;
            Kontakt = kontakt;
        }

        public override bool Equals(object obj)
        {
            return obj is Clan clan &&
                   ClanId == clan.ClanId &&
                   Ime == clan.Ime &&
                   Prezime == clan.Prezime &&
                   Kontakt == clan.Kontakt;
        }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string NazivTabele()
        {
            return "Clan";
        }

        public string InsertValues()
        {
            return $"'{Ime}','{Prezime}','{Kontakt}'";
        }

        public string Join()
        {
            return "";
        }

        public string Id()
        {
            return $"WHERE clanId = {ClanId}";
        }

        public string Search(KriterijumPretrage kriterijum)
        {
            if(kriterijum.Kriterijumi.TryGetValue(KriterijumiPretrageKeys.Tekst, out var tekst))
            {
                return $"WHERE c.Ime LIKE '%{tekst}%' OR c.Prezime LIKE '%{tekst}%' OR c.Kontakt LIKE '%{tekst}%'";
            }

            return string.Empty;
        }

        public List<OpstiDomenskiObjekat> Select(SqlDataReader reader)
        {
            var entiteti = new List<OpstiDomenskiObjekat>();
            while (reader.Read())
            {
                var clanId = Convert.ToInt32(reader["clanId"]);
                var ime = reader["ime"].ToString();
                var prezime = reader["prezime"].ToString();
                var kontakt = reader["kontakt"].ToString();

                entiteti.Add(new Clan(clanId, ime, prezime, kontakt));
            }

            return entiteti;
        }

        public string NazivTabeleDodatno()
        {
            return "Clan c";
        }

        public string UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
