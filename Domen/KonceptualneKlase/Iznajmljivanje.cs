using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.KonceptualneKlase
{
    [Serializable]
    public class Iznajmljivanje : OpstiDomenskiObjekat
    {
        [Browsable(false)]
        public int IznajmljivanjeId { get; set; }
        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime RokZaVracanje { get; set; }
        public Clan Clan { get; set; } 
        public List<IznajmljivanjePrimerak> Primerci { get; set; } 

        public Iznajmljivanje()
        {
        }

        public Iznajmljivanje(int iznajmljivanjeId, DateTime datumIznajmljivanja, DateTime rokZaVracanje, Clan clan)
        {
            IznajmljivanjeId = iznajmljivanjeId;
            DatumIznajmljivanja = datumIznajmljivanja;
            RokZaVracanje = rokZaVracanje;
            Clan = clan;
        }

        public override bool Equals(object obj)
        {
            return obj is Iznajmljivanje iznajmljivanje &&
                   IznajmljivanjeId == iznajmljivanje.IznajmljivanjeId &&
                   DatumIznajmljivanja == iznajmljivanje.DatumIznajmljivanja &&
                   RokZaVracanje == iznajmljivanje.RokZaVracanje &&
                   EqualityComparer<Clan>.Default.Equals(Clan, iznajmljivanje.Clan);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string NazivTabele()
        {
            return "Iznajmljivanje";
        }

        public string NazivTabeleDodatno()
        {
            return "Iznajmljivanje i";
        }

        public string InsertValues()
        {
            return $"'{DatumIznajmljivanja.ToString("yyyy-MM-dd")}', '{RokZaVracanje.ToString("yyyy-MM-dd")}', {Clan.ClanId}";
        }

        public string Join()
        {
            return "JOIN Clan c ON (c.clanId = i.clanId)";
        }

        public string Id()
        {
            return $"WHERE iznajmljivanjeId = {IznajmljivanjeId}";
        }

        public string Search(KriterijumPretrage kriterijum)
        {
            var searchText = "WHERE ";

            if (kriterijum.Kriterijumi.TryGetValue(KriterijumiPretrageKeys.Tekst, out var tekst))
            {
                searchText += $"(i.DatumIznajmljivanja = '{Convert.ToDateTime(tekst)}') ";
            }

            if (kriterijum.Kriterijumi.TryGetValue(KriterijumiPretrageKeys.Clan, out var clan))
            {
                searchText += tekst == null ? $"(c.ClanId ={Convert.ToInt32(clan) }) " : $"AND (c.ClanId ={Convert.ToInt32(clan)}) ";
            }

            return searchText;
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
                var clan = new Clan(clanId, ime, prezime, kontakt);

                var iznajmljivanjeId = Convert.ToInt32(reader["iznajmljivanjeId"]);
                var datumIznajmljivanja = Convert.ToDateTime(reader["datumIznajmljivanja"]);
                var rokZaVracanje = Convert.ToDateTime(reader["rokZaVracanje"]);

                entiteti.Add(new Iznajmljivanje(iznajmljivanjeId, datumIznajmljivanja, rokZaVracanje, clan));
            }

            return entiteti;
        }

        public string UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
