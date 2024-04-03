using System;

namespace Domen.TransferKlase
{
    [Serializable]
    public class Odgovor
    {
        public bool UspesnoIzvrsenaSO { get; set; }
        public object Object { get; set; }

        public Odgovor(bool uspesnoIzvrsenaSO, object @object)
        {
            UspesnoIzvrsenaSO = uspesnoIzvrsenaSO;
            Object = @object;
        }
    }
}
