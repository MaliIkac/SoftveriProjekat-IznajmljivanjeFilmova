using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.KonceptualneKlase
{
    [Serializable]
    public class Film : OpstiDomenskiObjekat
    {
        [Browsable(false)]
        public int FilmId { get; set; }
        public string Naziv { get; set; }
        public DateTime GodinaIzdavanja { get; set; }
        public string Zanr { get; set; }
        public List<FilmGlumac> Glumci { get; set; } 
        public List<Primerak> Primerci { get; set; } 

        public Film()
        {
        }

        public Film(int filmId, string naziv, DateTime godinaIzdavanja, string zanr)
        {
            FilmId = filmId;
            Naziv = naziv;
            GodinaIzdavanja = godinaIzdavanja;
            Zanr = zanr;
        }

        public override string ToString()
        {
            return Naziv;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string NazivTabele()
        {
            return "Film";
        }

        public string NazivTabeleDodatno()
        {
            return "Film f";
        }
        public string InsertValues()
        {
            return $"'{Naziv}', '{GodinaIzdavanja.ToString()}', '{Zanr}'";
        }

        public string Join()
        {
            return "";
        }

        public string Id()
        {
            return $"filmId = {FilmId}";
        }

        public string Search(KriterijumPretrage kriterijum)
        {
            var searchText = "WHERE ";

            if (kriterijum.Kriterijumi.TryGetValue(KriterijumiPretrageKeys.Tekst, out var tekst))
            {
                searchText += $"(f.Naziv LIKE '%{tekst}%') ";
            }

            if (kriterijum.Kriterijumi.TryGetValue(KriterijumiPretrageKeys.Zanr, out var zanr))
            {
                searchText += tekst == null ? $"(f.Zanr LIKE '%{zanr}%') " :  $"AND (f.Zanr LIKE '%{zanr}%') ";
            }

            return searchText;
        }

        public List<OpstiDomenskiObjekat> Select(SqlDataReader reader)
        {
            var entiteti = new List<OpstiDomenskiObjekat>();
            while (reader.Read())
            {
                var filmId = Convert.ToInt32(reader["filmId"]);
                var naziv = reader["naziv"].ToString();
                var godinaIzdavanja = Convert.ToDateTime(reader["godinaIzdavanja"]);
                var zanr = reader["zanr"].ToString();

                entiteti.Add(new Film(filmId, naziv, godinaIzdavanja, zanr));
            }

            return entiteti;
        }

        public string UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
