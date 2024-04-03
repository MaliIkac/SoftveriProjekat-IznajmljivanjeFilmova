using Domen.KorisneKlase;
using System;

namespace Domen.TransferKlase
{
    [Serializable]
    public class ZahtevServer
    {
        public SistemskaOperacija SistemskaOperacija { get; set; }
        public object Object { get; set; }

        public ZahtevServer(SistemskaOperacija sistemskaOperacija, object @object)
        {
            SistemskaOperacija = sistemskaOperacija;
            Object = @object;
        }
    }
}
