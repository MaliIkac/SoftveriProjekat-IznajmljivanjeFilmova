using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System.Collections.Generic;
using System.Linq;

namespace SistemskeOperacije.SO
{
    public class VratiListuFilmova : OpstaSistemskaOperacija
    {
        public List<Film> Lista { get; set; }
        public VratiListuFilmova(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            Lista = broker.VratiEntitete(new Film()).Cast<Film>().ToList();

            var glumci = broker.VratiEntitete(new FilmGlumac()).Cast<FilmGlumac>().ToList();
            var primerci = broker.VratiEntitete(new Primerak()).Cast<Primerak>().ToList();

            foreach(Film film in Lista)
            {
                film.Glumci = glumci.Where(glumac => glumac.Film.FilmId == film.FilmId).ToList();
                film.Primerci = primerci.Where(primerak => primerak.Film.FilmId == film.FilmId).ToList();
            }

        }
    }
}
