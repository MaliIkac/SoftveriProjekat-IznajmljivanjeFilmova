using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Linq;


namespace SistemskeOperacije.SO
{
    public class UcitajFilm : OpstaSistemskaOperacija
    {
        public UcitajFilm(OpstiDomenskiObjekat objekat) : base(objekat)
        {

        }

        protected override void Operacija()
        {
            var film = Odo as Film;
            Odo = broker.VratiEntitete(film, film.Id())?.Cast<Film>()?.FirstOrDefault();
            if (Odo == null)
            {
                throw new Exception($"Clan {film.FilmId} ne postoji u sistemu");
            }
        }
    }
}
