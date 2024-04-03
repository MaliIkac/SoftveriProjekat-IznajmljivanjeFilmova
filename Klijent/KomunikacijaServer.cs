using Domen.KorisneKlase;
using Domen.TransferKlase;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;


namespace Klijent
{
    public class KomunikacijaServer
    {
        public Socket Socket;
        readonly NetworkStream NetworkStream;
        readonly BinaryFormatter BinaruFormatter = new BinaryFormatter();
        private static KomunikacijaServer instanca;
        private KomunikacijaServer()
        {
            try
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Socket.Connect("localhost", 9090);

                NetworkStream = new NetworkStream(Socket);
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.StackTrace);
                Environment.Exit(1);
            }
        }

        public static KomunikacijaServer Instanca
        {
            get
            {
                if (instanca is null)
                {
                    instanca = new KomunikacijaServer();
                }

                return instanca;
            }
        }

        public Odgovor TransferSync(SistemskaOperacija sistemskaOperacija, object podaci = null)
        {
            try
            {
                var zahtev = new ZahtevServer(sistemskaOperacija, podaci);
                BinaruFormatter.Serialize(NetworkStream, zahtev);

                var odgovor = BinaruFormatter.Deserialize(NetworkStream) as Odgovor;
                return odgovor;
            }
            catch (Exception ex)
            {
                Socket.Close();
                MessageBox.Show(ex.StackTrace);
                Environment.Exit(1);
                return new Odgovor(false, null);
            }
        }
    }
}
