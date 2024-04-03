using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen.KonceptualneKlase
{
    [Serializable]
    public class FilmGlumac : OpstiDomenskiObjekat
    {
        [Browsable(false)]
        public Film Film { get; set; }
        public Glumac Glumac { get; set; }

        public FilmGlumac()
        {
        }

        public FilmGlumac(Film film, Glumac glumac)
        {
            Film = film;
            Glumac = glumac;
        }

        public override bool Equals(object obj)
        {
            return obj is FilmGlumac glumac &&
                   EqualityComparer<Film>.Default.Equals(Film, glumac.Film) &&
                   EqualityComparer<Glumac>.Default.Equals(Glumac, glumac.Glumac);
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
            return "FilmGlumac";
        }

        public string NazivTabeleDodatno()
        {
            return "FilmGlumac fg";
        }

        public string InsertValues()
        {
            return $"{Film.FilmId},'{Glumac.GlumacId}'";
        }

        public string Join()
        {
            return "JOIN Film f ON (fg.FilmId = f.FilmId) JOIN Glumac g ON (g.GlumacId = fg.GlumacId)";
        }

        public string Id()
        {
            return $"filmId = {Film.FilmId}";
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


                var glumacId = Convert.ToInt32(reader["glumacId"]);
                var ime = reader["ime"].ToString();
                var prezime = reader["prezime"].ToString();

                Glumac glumac = new Glumac(glumacId, ime, prezime);

                entiteti.Add(new FilmGlumac(film, glumac));
            }

            return entiteti;
        }

        public string UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
