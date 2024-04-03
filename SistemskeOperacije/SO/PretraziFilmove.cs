using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class PretraziFilmove : OpstaSistemskaOperacija
    {
        public List<Film> Lista { get; set; }
        public PretraziFilmove(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var kp = Odo as KriterijumPretrage;
            var film1 = new Film();

            Lista = broker.VratiEntitete(film1, film1.Search(kp)).Cast<Film>().ToList();

            if (!Lista.Any())
            {
                throw new InvalidOperationException("Sistem ne moze da pronadje entitet po zadatom kriterijumu");
            }

            var glumci = broker.VratiEntitete(new FilmGlumac()).Cast<FilmGlumac>().ToList();
            var primerci = broker.VratiEntitete(new Primerak()).Cast<Primerak>().ToList();

            foreach (Film film in Lista)
            {
                film.Glumci = glumci.Where(glumac => glumac.Film.FilmId == film.FilmId).ToList();
                film.Primerci = primerci.Where(primerak => primerak.Film.FilmId == film.FilmId).ToList();
            }
        }
    }
}
