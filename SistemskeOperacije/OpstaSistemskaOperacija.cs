using BazaPodataka;
using Domen.KorisneKlase;
using System;
using System.Data.SqlClient;

namespace SistemskeOperacije
{
    public abstract class OpstaSistemskaOperacija
    {
        protected Broker broker;
        public OpstiDomenskiObjekat Odo;
        public OpstaSistemskaOperacija(OpstiDomenskiObjekat odo)
        {
            broker = new Broker();
            this.Odo = odo;
        }
        protected abstract void Operacija();
       
        public void Izvrsi()
        {
            try
            {
                broker.OtvoriKonekciju();
                broker.PokreniTransakciju();
                Operacija();
                broker.Commit();
            }
            catch (SqlException e)
            {
                Console.WriteLine("GRESKA JE DO BAZE: " + e.StackTrace);
                Console.WriteLine("GRESKA JE DO BAZE: " + e.Message);

                broker.Rolback();
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                broker.Rolback();
                throw;
            }
            finally
            {
                broker.ZatvoriKonekciju();
            }
        }

        
    }
}
