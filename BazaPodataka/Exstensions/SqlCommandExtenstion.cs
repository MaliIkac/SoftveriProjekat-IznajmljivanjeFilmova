using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Data.SqlClient;

namespace BazaPodataka.Exstensions
{
    public static class SqlCommandExtenstion
    {
        public static int Execute(this SqlCommand command, OpstiDomenskiObjekat odo)
        {
            if(odo is FilmGlumac || odo is Primerak || odo is IznajmljivanjePrimerak)
            {
                return command.ExecuteNonQuery();
            }

            return Convert.ToInt32(command.ExecuteScalar());
        }

        public static void SetCommandText(this SqlCommand command, OpstiDomenskiObjekat opstiDomenskiObjekat)
        {
            command.CommandText = $"INSERT INTO {opstiDomenskiObjekat.NazivTabele()} VALUES({opstiDomenskiObjekat.InsertValues()}); ";

            if (opstiDomenskiObjekat is FilmGlumac || opstiDomenskiObjekat is Primerak || opstiDomenskiObjekat is IznajmljivanjePrimerak)
            {
                return;
            }

            command.CommandText += "SELECT SCOPE_IDENTITY();";
        }
    }
}
