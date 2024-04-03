using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System.Windows.Forms;

namespace Klijent.KontroleriKorisnickogInterfejsa
{
    public class UnosClanaKontroler
    {
        private static UnosClanaKontroler instanca;
        private UnosClanaKontroler()
        {
        }

        public static UnosClanaKontroler Instanca
        {
            get
            {
                if (instanca is null)
                {
                    instanca = new UnosClanaKontroler();
                }

                return instanca;
            }
        }

        internal void Kreiraj(TextBox txtIme, TextBox txtPrezime, TextBox txtKontakt)
        {
            var clan = KreiranClana(txtIme, txtPrezime, txtKontakt);
            if (clan == null)
            {
                return;
            }

            var odg = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.ZapamtiNovogClana, clan);
            if (odg.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je zapamtio novog clana");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti novog clana video kluba. Pokusajte ponovo!");
            }
        }

        private Clan KreiranClana(TextBox txtIme, TextBox txtPrezime, TextBox txtKontakt)
        {
            var ime = txtIme.Text;
            var prezime = txtPrezime.Text;
            var kontakt = txtKontakt.Text;

            if (!Validacija(ime, prezime, kontakt))
            {
                return null;
            }

            return new Clan(0, ime, prezime, kontakt);
        }

        private bool Validacija(string ime, string prezime, string kontakt)
        {
            if (string.IsNullOrEmpty(ime))
            {
                MessageBox.Show("Morate uneti ime");
                return false;
            }

            if (string.IsNullOrEmpty(prezime))
            {
                MessageBox.Show("Morate uneti prezime");
                return false;
            }

            if (string.IsNullOrEmpty(kontakt))
            {
                MessageBox.Show("Morate uneti kontakt");
                return false;
            }

            return true;
        }
    }
}
