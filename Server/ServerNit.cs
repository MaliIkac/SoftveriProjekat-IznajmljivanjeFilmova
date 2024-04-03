using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Server
{
    public class ServerNit
    {
        private Socket socket;
        readonly List<Socket> konekcijeTrenutne = new List<Socket>();

        private static ServerNit server;
        private ServerNit()
        {

        }
        public static ServerNit Server
        {
            get
            {
                if (server is null)
                {
                    server = new ServerNit();
                }

                return server;
            }
        }

        public bool PokreniServer()
        {
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090));
                socket.Listen(5);
                konekcijeTrenutne.Add(socket);
                new Thread(ThreadPrihvatiKorisnike).Start();
                return true;
            }
            catch (SocketException)
            {
                socket.Close();
                return false;
            }
            catch (IOException)
            {
                socket.Close();
                return false;
            }
        }

        public bool ZaustaviServer()
        {
            try
            {
                konekcijeTrenutne.ForEach(soket => soket.Close());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ThreadPrihvatiKorisnike()
        {
            while (true)
            {
                try
                {
                    var klijentskiSoketPovezivanje = socket.Accept();
                    konekcijeTrenutne.Add(klijentskiSoketPovezivanje);
                    var klijent = new KlijentObrada(klijentskiSoketPovezivanje);
                    new Thread(klijent.Handle).Start();
                }
                catch (SocketException e)
                {
                    Console.WriteLine(e.StackTrace);
                    return;
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.StackTrace);
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    return;
                }
            }
        }
    }
}
