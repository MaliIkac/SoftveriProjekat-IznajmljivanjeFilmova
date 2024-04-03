using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.KonceptualneKlase
{
    [Serializable] 
    public class IznajmljivanjePrimerak : OpstiDomenskiObjekat
    {
        [Browsable(false)]
        public Iznajmljivanje Iznajmljivanje { get; set; }
        public Primerak Primerak { get; set; }

        public IznajmljivanjePrimerak()
        {
        }

        public IznajmljivanjePrimerak(Iznajmljivanje iznajmljivanje, Primerak primerak)
        {
            Iznajmljivanje = iznajmljivanje;
            Primerak = primerak;
        }

        public override bool Equals(object obj)
        {
            return obj is IznajmljivanjePrimerak primerak &&
                   EqualityComparer<Iznajmljivanje>.Default.Equals(Iznajmljivanje, primerak.Iznajmljivanje) &&
                   EqualityComparer<Primerak>.Default.Equals(Primerak, primerak.Primerak);
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
            return "IznajmljivanjePrimerak";
        }

        public string NazivTabeleDodatno()
        {
            return "IznajmljivanjePrimerak ip";
        }

        public string InsertValues()
        {
            return $"{Iznajmljivanje.IznajmljivanjeId},{Primerak.Film.FilmId}, {Primerak.PrimerakId}";
        }

        public string Join()
        {
            return "JOIN Primerak p ON (p.PrimerakId = ip.PrimerakId AND p.FilmId = ip.FilmId) JOIN Film f ON (p.FilmId = f.FilmId) JOIN Iznajmljivanje i ON (i.IznajmljivanjeId = ip.IznajmljivanjeId)";
        }

        public string Id()
        {
            return $"WHERE iznajmljivanjeId = {Iznajmljivanje.IznajmljivanjeId}";
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
                var primerak = new Primerak(film, primerakId, raspolozivost);

                var iznajmljivanjeId = Convert.ToInt32(reader["iznajmljivanjeId"]);
                var datumIznajmljivanja = Convert.ToDateTime(reader["datumIznajmljivanja"]);
                var rokZaVracanje = Convert.ToDateTime(reader["rokZaVracanje"]);
                var i = new Iznajmljivanje(iznajmljivanjeId, datumIznajmljivanja, rokZaVracanje, null);
                entiteti.Add(new IznajmljivanjePrimerak(i, primerak));
            }

            return entiteti;
        }

        public string UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
