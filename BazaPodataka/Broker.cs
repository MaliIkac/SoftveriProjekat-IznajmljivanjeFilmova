using BazaPodataka.Exstensions;
using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BazaPodataka
{
    public class Broker
    {
        public SqlTransaction Transaction { get; set; }
        public SqlConnection Connection { get; set; }

        public Broker()
        {
            
            Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AplikacijaSoftveri;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        public int Dodaj(OpstiDomenskiObjekat opstiDomenskiObjekat)
        {
            var command = new SqlCommand("", Connection, Transaction);
            command.SetCommandText(opstiDomenskiObjekat);
            Console.WriteLine(command.CommandText);
            
            var result = command.Execute(opstiDomenskiObjekat);
            return result == 0 ? throw new Exception("Greska prilikom unosa") : result;
        }

        public void Izmeni(OpstiDomenskiObjekat opstiDomenskiObjekat)
        {
            var command = new SqlCommand("", Connection, Transaction)
            {
                CommandText = $"UPDATE { opstiDomenskiObjekat.NazivTabele()} SET {opstiDomenskiObjekat.UpdateValues()} { opstiDomenskiObjekat.Id()}"
            };

            Console.WriteLine(command.CommandText);

            if (command.ExecuteNonQuery() == 0)
            {
                throw new Exception("Nije azuriran nijedan red");
            }
        }

        public List<OpstiDomenskiObjekat> VratiEntitete(OpstiDomenskiObjekat opstiDomenskiObjekat, string kriterijumPretrage = "")
        {
            var command = new SqlCommand($"", Connection, Transaction)
            {
                CommandText = $"SELECT * FROM { opstiDomenskiObjekat.NazivTabeleDodatno()} { opstiDomenskiObjekat.Join()} { kriterijumPretrage}"
            };

            Console.WriteLine(command.CommandText);

            using (var executeReader = command.ExecuteReader())
            {
                return opstiDomenskiObjekat.Select(executeReader);
            }
        }
        public void Obrisi(OpstiDomenskiObjekat opstiDomenskiObjekat)
        {
            var command = new SqlCommand("", Connection, Transaction)
            {
                CommandText = $"DELETE FROM {opstiDomenskiObjekat.NazivTabele()} {opstiDomenskiObjekat.Id()}"
            };

            Console.WriteLine(command.CommandText);
            command.ExecuteNonQuery();
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rolback()
        {
            Transaction.Rollback();
        }

        public void PokreniTransakciju()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void OtvoriKonekciju()
        {
            Connection.Open();
        }

        public void ZatvoriKonekciju()
        {
            Connection.Close();
        }
    }
}
