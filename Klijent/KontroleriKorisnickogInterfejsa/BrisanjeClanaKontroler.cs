using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Klijent.KontroleriKorisnickogInterfejsa
{
    public class BrisanjeClanaKontroler
    {
        private static BrisanjeClanaKontroler instanca;
        BindingList<Clan> Clanovi { get; set; }

        private BrisanjeClanaKontroler()
        {
        }

        public static BrisanjeClanaKontroler Instanca
        {
            get
            {
                if (instanca is null)
                {
                    instanca = new BrisanjeClanaKontroler();
                }

                return instanca;
            }
        }

        internal void Pretrazi(DataGridView dataGridView1, TextBox txtTekst)
        {
            var kp = Kreiraj(txtTekst);

            if (kp == null)
            {
                return;
            }
            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.PretraziClanove, kp);

            if (odgovor.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je nasao clanove video kluba po zadatoj vrednosti!");
                Clanovi = new BindingList<Clan>(odgovor.Object as List<Clan>);
                dataGridView1.DataSource = Clanovi;
            }
            else
            {
                MessageBox.Show("Sistem ne moze da nadje clanove video kluba po zadatoj vrednosti!");
            }
        }

        internal void Obrisi(DataGridView dataGridView1)
        {
            var clan = dataGridView1.SelectedRows[0].DataBoundItem as Clan;

            if (clan == null)
            {
                MessageBox.Show("Nije selektovan red");
            }

            var result = MessageBox.Show("Da li ste sigurni da zelite da obrisete clana?", "Potvrda", MessageBoxButtons.YesNo);
            
            if (result == DialogResult.No)
            {
                return;
            }

            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.ObrisiClana, clan);
            
            if (odgovor.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je uspesno obrisao clana video kluba!");
                Load(dataGridView1);
            }
            else
            {
                MessageBox.Show("Sistem nije uspeo da obrise clana video kluba");
            }
        }

        internal void Load(DataGridView dataGridView1)
        {
            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.VratiListuClanova);
            if (odgovor.UspesnoIzvrsenaSO)
            {
                Clanovi = new BindingList<Clan>(odgovor.Object as List<Clan>);
                dataGridView1.DataSource = Clanovi;
            }
        }

        private KriterijumPretrage Kreiraj(TextBox txtTekst)
        {
            var tekst = txtTekst.Text;
            if (string.IsNullOrEmpty(tekst))
            {
                MessageBox.Show("Unesite tekst za pretragu");
                return null;
            }

            var dictionary = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(tekst))
            {
                dictionary.Add("Tekst", tekst);
            }

            return new KriterijumPretrage(dictionary);
        }
    }
}
