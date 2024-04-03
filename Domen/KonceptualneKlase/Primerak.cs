using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.KonceptualneKlase
{
    [Serializable]
    public class Primerak : OpstiDomenskiObjekat
    {
        public Film Film { get; set; } 
        public int PrimerakId { get; set; }
        public bool Raspolozivost { get; set; }

        public Primerak()
        {
        }

        public Primerak(Film film, int primerakId, bool raspolozivost)
        {
            Film = film;
            PrimerakId = primerakId;
            Raspolozivost = raspolozivost;
        }

        public override bool Equals(object obj)
        {
            return obj is Primerak primerak &&
                   EqualityComparer<Film>.Default.Equals(Film, primerak.Film) &&
                   PrimerakId == primerak.PrimerakId &&
                   Raspolozivost == primerak.Raspolozivost;
        }

        public override string ToString()
        {
            return "Redni broj primerka: " + PrimerakId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string NazivTabele()
        {
            return "Primerak";
        }

        public string NazivTabeleDodatno()
        {
            return "Primerak p";
        }
        public string InsertValues()
        {
            var raspolozivost = Raspolozivost ? 1 : 0;
            return $"{Film.FilmId}, {raspolozivost}";
        }

        public string Join()
        {
            return "join Film f ON (f.FilmId = p.FilmId)";
        }

        public string Id()
        {
            return $"WHERE primerakId = {PrimerakId}";
        }

        public string Search(KriterijumPretrage kriterijum)
        {
            throw new NotImplementedException();
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
                var film = new Film(filmId, naziv, godinaIzdavanja, zanr);
                var primerakId = Convert.ToInt32(reader["primerakId"]);
                var raspolozivost = Convert.ToBoolean(reader["raspolozivost"]);

                entiteti.Add(new Primerak(film, primerakId, raspolozivost));
            }

            return entiteti;
        }

        public string UpdateValues()
        {
            var raspolozivost = Raspolozivost ? 1 : 0;
            return $"raspolozivost = {raspolozivost}";
        }
    }
}
