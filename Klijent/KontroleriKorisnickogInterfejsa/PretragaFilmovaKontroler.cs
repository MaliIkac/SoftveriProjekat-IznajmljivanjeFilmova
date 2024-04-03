using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using Domen.KorisneKlase.UI;
using Klijent.Gui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Klijent.KontroleriKorisnickogInterfejsa
{
    public class PretragaFilmovaKontroler
    {
        private static PretragaFilmovaKontroler instanca;
        BindingList<Film> Filmovi { get; set; }
        private PretragaFilmovaKontroler()
        {
        }

        public static PretragaFilmovaKontroler Instanca
        {
            get
            {
                if (instanca is null)
                {
                    instanca = new PretragaFilmovaKontroler();
                }

                return instanca;
            }
        }

        internal void Pretrazi(DataGridView dataGridView1, TextBox txtTekst, ComboBox cmbZanr)
        {
            var kp = Kreiraj(txtTekst, cmbZanr);
            if (kp == null)
            {
                return;
            }

            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.PretraziFilmove, kp);
            if (odgovor.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je nasao sledece filmove po zadatoj vrednosti!");
                Filmovi = new BindingList<Film>(odgovor.Object as List<Film>);
                dataGridView1.DataSource = Filmovi;
            }
            else
            {
                MessageBox.Show("Sistem ne moze da nadje filmove po zadatoj vrednosti");
            }
        }

        internal void Prikazi(DataGridView dataGridView)
        {

            var film = dataGridView.SelectedRows[0].DataBoundItem as Film;

            if (film == null)
            {
                MessageBox.Show("Nije selektovan red");
            }

            UnosFilmaGui gui = new UnosFilmaGui(film);
            gui.ShowDialog();
        }

        private KriterijumPretrage Kreiraj(TextBox txtTekst, ComboBox cmbZanr)
        {
            var tekst = txtTekst.Text;
            var zanr = cmbZanr.SelectedItem.ToString();

            if (string.IsNullOrEmpty(tekst) && string.IsNullOrEmpty(zanr))
            {
                MessageBox.Show("Unesite neki kriterijum za pretragu");
                return null;
            }

            var dictionary = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(tekst))
            {
                dictionary.Add("Tekst", tekst);
            }

            if (!string.IsNullOrEmpty(zanr))
            {
                dictionary.Add("Zanr", zanr);
            }

            return new KriterijumPretrage(dictionary);
        }

        internal void Load(DataGridView dataGridView1, ComboBox cmbZanr)
        {
            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.VratiListuFilmova);
            if (odgovor.UspesnoIzvrsenaSO)
            {
                Filmovi = new BindingList<Film>(odgovor.Object as List<Film>);
                dataGridView1.DataSource = Filmovi;
            }

            var zanrovi = Enum.GetNames(typeof(Zanrovi)).ToList<string>();
            zanrovi.Insert(0, string.Empty);
            cmbZanr.DataSource = cmbZanr.DataSource = zanrovi;
        }
    }
}
