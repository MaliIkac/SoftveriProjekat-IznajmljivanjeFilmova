using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen.KonceptualneKlase
{
    [Serializable]
    public class Glumac : OpstiDomenskiObjekat
    {
        public int GlumacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Glumac()
        {
        }

        public Glumac(int glumacId, string ime, string prezime)
        {
            GlumacId = glumacId;
            Ime = ime;
            Prezime = prezime;
        }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string NazivTabele()
        {
            return "Glumac ";
        }

        public string NazivTabeleDodatno()
        {
            return "Glumac g";
        }

        public string InsertValues()
        {
            return "";
        }

        public string Join()
        {
            return "";
        }

        public string Id()
        {
            return $"glumacId = {GlumacId}";
        }

        public string Search(KriterijumPretrage kriterijum)
        {
            throw new NotImplementedException();
        }

        public List<OpstiDomenskiObjekat> Select(SqlDataReader reader)
        {
            var entiteti = new List<OpstiDomenskiObjekat>();
            while (reader.Read())
            {

                var glumacId = Convert.ToInt32(reader["glumacId"]);
                var ime = reader["ime"].ToString();
                var prezime = reader["prezime"].ToString();

                entiteti.Add(new Glumac(glumacId, ime, prezime));
            }

            return entiteti;
        }

        public string UpdateValues()
        {
            throw new NotImplementedException();
        }
    }
}
