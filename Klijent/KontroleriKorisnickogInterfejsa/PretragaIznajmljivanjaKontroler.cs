using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Klijent.KontroleriKorisnickogInterfejsa
{
    public class PretragaIznajmljivanjaKontroler
    {
        private static PretragaIznajmljivanjaKontroler instanca;
        BindingList<Iznajmljivanje> Iznajmljivanja { get; set; }

        private PretragaIznajmljivanjaKontroler()
        {
        }

        public static PretragaIznajmljivanjaKontroler Instanca
        {
            get
            {
                if (instanca == null)
                {
                    instanca = new PretragaIznajmljivanjaKontroler();
                }

                return instanca;
            }
        }

        internal void Pretrazi(DataGridView dataGridView1, ComboBox cmbClan, TextBox txtDatum)
        {
            var kp = Kreiraj(cmbClan, txtDatum);
            if (kp == null)
            {
                return;
            }

            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.PretraziIznajmljivanja, kp);
            if (odgovor.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je nasao iznajmljivanja filmova po zadatoj vrednosti");
                Iznajmljivanja = new BindingList<Iznajmljivanje>(odgovor.Object as List<Iznajmljivanje>);
                dataGridView1.DataSource = Iznajmljivanja;
            }
            else
            {
                MessageBox.Show("Sistem ne moze da nadje iznajmljivanja filmova po zadatoj vrednosti");
            }
        }

        internal void Razduzi(DataGridView dataGridView1, ComboBox cmbClan)
        {
            var iznajmljivanje = dataGridView1.SelectedRows[0].DataBoundItem as Iznajmljivanje;

            if (iznajmljivanje == null)
            {
                MessageBox.Show("Nije selektovan red");
            }

            var result = MessageBox.Show("Da li ste sigurni da zelite da razduzite iznajmljivanje?", "Potvrda", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                return;
            }

            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.RazduziIznajmmljivanje, iznajmljivanje);

            if (odgovor.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je razduzio iznajmljivanje filma");
                Load(dataGridView1, cmbClan);
            }
            else
            {
                MessageBox.Show("Sistem ne moze da razduzi iznajmljivanje filma");
            }
        }

        private KriterijumPretrage Kreiraj(ComboBox cmbClan, TextBox txtDatum)
        {
            
            var clan = cmbClan.SelectedItem as Clan;
           

            if (clan.ClanId == 0)
            {
                MessageBox.Show("Izaberite clana za pretragu");
                return null;
            }

          

           
            var dictionary = new Dictionary<string, object>();

           

            if (clan.ClanId != 0)
            {
                dictionary.Add("Clan", clan.ClanId);
            }

            return new KriterijumPretrage(dictionary);
        }


        internal void Load(DataGridView dataGridView1, ComboBox cmbClan)
        {
            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.VratiListuIznajmljivanja);
            if (odgovor.UspesnoIzvrsenaSO)
            {
                Iznajmljivanja = new BindingList<Iznajmljivanje>(odgovor.Object as List<Iznajmljivanje>);
                dataGridView1.DataSource = Iznajmljivanja;
            }

            odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.VratiListuClanova);
            if (odgovor.UspesnoIzvrsenaSO)
            {
                var listaClnova = odgovor.Object as List<Clan>;
                listaClnova.Insert(0,new Clan(0, "", "", ""));
                cmbClan.DataSource = odgovor.Object as List<Clan>;
            }
        }
    }
}
