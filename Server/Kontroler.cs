using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using SistemskeOperacije;
using SistemskeOperacije.SO;
using System;
using System.Collections.Generic;

namespace Server
{
    public class Kontroler
    {
        private static Kontroler instanca;
        private Kontroler()
        {

        }
        public static Kontroler Instanca
        {
            get
            {
                if (instanca is null) instanca = new Kontroler();
                return instanca;
            }
        }

        internal void RazduziIznajmmljivanje(Iznajmljivanje @object)
        {
            OpstaSistemskaOperacija oso = new RazduziIznajmljivanje(@object);
            oso.Izvrsi();
        }

        internal List<Iznajmljivanje> PretraziIznajmljivanja(KriterijumPretrage @object)
        {
            OpstaSistemskaOperacija oso = new PretraziIznajmljivanja(@object);
            oso.Izvrsi();
            return ((PretraziIznajmljivanja)oso).Lista;
        }

        internal void ZapamtiNovoIznajmljivanje(Iznajmljivanje @object)
        {
            OpstaSistemskaOperacija oso = new ZapamtiNovoIznajmljivanje(@object);
            oso.Izvrsi();
        }

        internal Film UcitajFilm(Film @object)
        {
            OpstaSistemskaOperacija oso = new UcitajFilm(@object);
            oso.Izvrsi();
            return ((UcitajFilm)oso).Odo as Film;
        }

        internal List<Film> PretraziFilmove(KriterijumPretrage @object)
        {
            OpstaSistemskaOperacija oso = new PretraziFilmove(@object);
            oso.Izvrsi();
            return ((PretraziFilmove)oso).Lista;
        }

        internal List<Film> VratiListuFilmova()
        {
            OpstaSistemskaOperacija oso = new VratiListuFilmova(null);
            oso.Izvrsi();
            return ((VratiListuFilmova)oso).Lista;
        }

        internal void ZapamtiFilm(Film @object)
        {
            OpstaSistemskaOperacija oso = new ZapamtiFilm(@object);
            oso.Izvrsi();
        }

        internal List<Glumac> VratiListuGlumaca()
        {
            OpstaSistemskaOperacija oso = new VratiListuGlumaca(null);
            oso.Izvrsi();
            return ((VratiListuGlumaca)oso).Lista;
        }

        internal void ObrisiClana(Clan @object)
        {
            OpstaSistemskaOperacija oso = new ObrisiClana(@object);
            oso.Izvrsi();
        }

        internal Clan UcitajClana(Clan @object)
        {
            OpstaSistemskaOperacija oso = new UcitajClana(@object);
            oso.Izvrsi();
            return ((UcitajClana)oso).Odo as Clan;
        }

        internal List<Clan> PretraziClanove(KriterijumPretrage @object)
        {
            OpstaSistemskaOperacija oso = new PretraziClanove(@object);
            oso.Izvrsi();
            return ((PretraziClanove)oso).Lista;
        }

        internal List<Clan> VratiListuClanova()
        {
            OpstaSistemskaOperacija oso = new VratiListuClanova(null);
            oso.Izvrsi();
            return ((VratiListuClanova)oso).Lista;
        }

        


        internal void ZapamtiNovogClana(Clan @object)
        {
            OpstaSistemskaOperacija oso = new ZapamtiNovogClana(@object);
            oso.Izvrsi();
        }

        internal List<Iznajmljivanje> VratiListuIznajmljivanja()
        {
            OpstaSistemskaOperacija oso = new VratiListuIznajmljivanja(null);
            oso.Izvrsi();
            return ((VratiListuIznajmljivanja)oso).Lista;
        }

        internal void PrijaviAdministratora(Administrator @object)
        {
            OpstaSistemskaOperacija oso = new PrijaviAdministratora(@object);
            oso.Izvrsi();
        }

        internal Iznajmljivanje UcitajIznajmljivanje(Iznajmljivanje @object)
        {
            OpstaSistemskaOperacija oso = new UcitajIznajmljivanje(@object);
            oso.Izvrsi();
            return ((UcitajIznajmljivanje)oso).Odo as Iznajmljivanje;
        }
    }
}
