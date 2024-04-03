using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.KorisneKlase
{
    public interface OpstiDomenskiObjekat
    {
        string NazivTabele();
        string NazivTabeleDodatno();

        string InsertValues();
        string UpdateValues();
        string Join();
        string Id();
        string Search(KriterijumPretrage kriterijum);
        List<OpstiDomenskiObjekat> Select(SqlDataReader reader);
    }
}
