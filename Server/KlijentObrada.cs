using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using Domen.TransferKlase;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{
    public class KlijentObrada
    {
        readonly BinaryFormatter formantter = new BinaryFormatter();
        readonly NetworkStream stream;
        readonly Socket socket;
        public KlijentObrada(Socket socket)
        {
            this.socket = socket;
            this.stream = new NetworkStream(socket);
        }
        public void Handle()
        {
            bool signal = false;
            while (!signal)
            {
                try
                {
                    var zahtevServer = (ZahtevServer)formantter.Deserialize(stream);
                    var odgovor = ObradiZahtev(zahtevServer);
                    formantter.Serialize(stream, odgovor);
                }
                catch (Exception)
                {
                    socket.Close();
                    signal = true;
                }
            }
        }

        public Odgovor ObradiZahtev(ZahtevServer zahtevServer)
        {
            try
            {
                switch (zahtevServer.SistemskaOperacija)
                {
                    case SistemskaOperacija.PrijavaAdministratora: return PrijavaAdministratora((Administrator)zahtevServer.Object);
                    case SistemskaOperacija.ZapamtiNovogClana: return ZapamtiNovogClana((Clan)zahtevServer.Object);
                    case SistemskaOperacija.VratiListuClanova: return VratiListuClanova();
                    case SistemskaOperacija.PretraziClanove: return PretraziClanove((KriterijumPretrage)zahtevServer.Object);
                    case SistemskaOperacija.UcitajClana: return UcitajClana((Clan)zahtevServer.Object);
                    case SistemskaOperacija.ObrisiClana: return ObrisiClana((Clan)zahtevServer.Object);
                    case SistemskaOperacija.VratiListuGlumaca: return VratiListuGlumaca();
                    case SistemskaOperacija.ZapamtiFilm: return ZapamtiFilm((Film)zahtevServer.Object);
                    case SistemskaOperacija.VratiListuFilmova: return VratiListuFilmova();
                    case SistemskaOperacija.PretraziFilmove: return PretraziFilmove((KriterijumPretrage)zahtevServer.Object);
                    case SistemskaOperacija.UcitajFilm: return UcitajFilm((Film)zahtevServer.Object);
                    case SistemskaOperacija.ZapamtiNovoIznajmljivanje: return ZapamtiNovoIznajmljivanje((Iznajmljivanje)zahtevServer.Object);
                    case SistemskaOperacija.VratiListuIznajmljivanja: return VratiListuIznajmljivanja();
                    case SistemskaOperacija.PretraziIznajmljivanja: return PretraziIznajmljivanja((KriterijumPretrage)zahtevServer.Object);
                    case SistemskaOperacija.UcitajIznajmljivanje: return UcitajIznajmljivanje((Iznajmljivanje)zahtevServer.Object);
                    case SistemskaOperacija.RazduziIznajmmljivanje: return RazduziIznajmmljivanje((Iznajmljivanje)zahtevServer.Object);
                    default: return new Odgovor(false, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new Odgovor(false, null);
            }
        }

        private Odgovor PrijavaAdministratora(Administrator @object)
        {
            Kontroler.Instanca.PrijaviAdministratora(@object);
            return new Odgovor(true, null);
        }

        private Odgovor RazduziIznajmmljivanje(Iznajmljivanje @object)
        {
            Kontroler.Instanca.RazduziIznajmmljivanje(@object);
            return new Odgovor(true, @object);
        }

        private Odgovor PretraziIznajmljivanja(KriterijumPretrage @object)
        {
            var lista = Kontroler.Instanca.PretraziIznajmljivanja(@object);
            return new Odgovor(true, lista);
        }

        private Odgovor ZapamtiNovoIznajmljivanje(Iznajmljivanje @object)
        {
            Kontroler.Instanca.ZapamtiNovoIznajmljivanje(@object);
            return new Odgovor(true, @object);
        }

        private Odgovor UcitajFilm(Film @object)
        {
            var lista = Kontroler.Instanca.UcitajFilm(@object);
            return new Odgovor(true, lista);
        }

        private Odgovor PretraziFilmove(KriterijumPretrage @object)
        {
            var lista = Kontroler.Instanca.PretraziFilmove(@object);
            return new Odgovor(true, lista);
        }

        private Odgovor VratiListuFilmova()
        {
            var lista = Kontroler.Instanca.VratiListuFilmova();
            return new Odgovor(true, lista);
        }

        private Odgovor ZapamtiFilm(Film @object)
        {
            Kontroler.Instanca.ZapamtiFilm(@object);
            return new Odgovor(true, @object);
        }

        private Odgovor VratiListuGlumaca()
        {
            var lista = Kontroler.Instanca.VratiListuGlumaca();
            return new Odgovor(true, lista);
        }

        private Odgovor ObrisiClana(Clan @object)
        {
            Kontroler.Instanca.ObrisiClana(@object);
            return new Odgovor(true, @object);
        }

        private Odgovor UcitajClana(Clan @object)
        {
            var lista = Kontroler.Instanca.UcitajClana(@object);
            return new Odgovor(true, lista);
        }

        private Odgovor PretraziClanove(KriterijumPretrage @object)
        {
            var lista = Kontroler.Instanca.PretraziClanove(@object);
            return new Odgovor(true, lista);
        }

        private Odgovor VratiListuClanova()
        {
            var lista = Kontroler.Instanca.VratiListuClanova();
            return new Odgovor(true, lista);
        }

        

        private Odgovor ZapamtiNovogClana(Clan @object)
        {
            Kontroler.Instanca.ZapamtiNovogClana(@object);
            return new Odgovor(true, @object);
        }

        private Odgovor VratiListuIznajmljivanja()
        {
            var lista = Kontroler.Instanca.VratiListuIznajmljivanja();
            return new Odgovor(true, lista);
        }

        private Odgovor UcitajIznajmljivanje(Iznajmljivanje @object)
        {
            var lista = Kontroler.Instanca.UcitajIznajmljivanje(@object);
            return new Odgovor(true, lista);
        }
    }
}
