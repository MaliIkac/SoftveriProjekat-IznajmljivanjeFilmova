using Domen.KorisneKlase;
using Klijent.Gui;
using System.Windows.Forms;

namespace Klijent.KontroleriKorisnickogInterfejsa
{
    public class PrijavaNaSistemKontroler
    {
        private static PrijavaNaSistemKontroler instanca;

        private PrijavaNaSistemKontroler()
        {
        }

        public static PrijavaNaSistemKontroler Instanca
        {
            get
            {
                if (instanca is null)
                {
                    instanca = new PrijavaNaSistemKontroler();
                }

                return instanca;
            }
        }

        internal bool Prijavi(TextBox txtKorisnickoIme, TextBox txtSifra)
        {
            var admin = Kreiraj(txtKorisnickoIme, txtSifra);
            var odg = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.PrijavaAdministratora, admin);
            if (odg.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Uspesna prijava!");
                
                return true;
                
            }
            else
            {
                MessageBox.Show("Niste uneli odgovarajuce podatke!");
                return false;
            }
        }

        private Administrator Kreiraj(TextBox txtKorisnickoIme, TextBox txtSifra)
        {
            var ime = txtKorisnickoIme.Text;
            var prezime = txtSifra.Text;
            return new Administrator(ime, prezime);
        }
    }
}
