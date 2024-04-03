using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class ZapamtiFilm : OpstaSistemskaOperacija
    {
        public ZapamtiFilm(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var film = Odo as Film;

            var filmovi = broker.VratiEntitete(film).Cast<Film>().ToList();

            if (filmovi.Any(f => f.Naziv.Equals(film.Naziv, StringComparison.InvariantCultureIgnoreCase) && f.GodinaIzdavanja.Year == film.GodinaIzdavanja.Year))
            {
                throw new InvalidOperationException("Postoji vec film sa ovim nazivom i da je izdat iste godine");
            }

            film.FilmId = broker.Dodaj(film);

            foreach(var primerak in film.Primerci)
            {
                primerak.Film = film;
                broker.Dodaj(primerak);
            }

            foreach (var glumac in film.Glumci)
            {
                glumac.Film = film;
                broker.Dodaj(glumac);
            }
        }
        
  }
}
