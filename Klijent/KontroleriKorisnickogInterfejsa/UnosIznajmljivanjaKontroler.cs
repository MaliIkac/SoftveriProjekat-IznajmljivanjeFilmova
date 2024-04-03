using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Klijent.KontroleriKorisnickogInterfejsa
{
    public class UnosIznajmljivanjaKontroler
    {
        private static UnosIznajmljivanjaKontroler instanca;
        BindingList<IznajmljivanjePrimerak> Primerci;

        private UnosIznajmljivanjaKontroler()
        {
        }

        public static UnosIznajmljivanjaKontroler Instanca
        {
            get
            {
                if (instanca is null)
                {
                    instanca = new UnosIznajmljivanjaKontroler();
                }

                return instanca;
            }
        }

        internal void Unos(TextBox txtRok, ComboBox cmbClan)
        {
            var iznajmljivanje = Kreiraj(txtRok, cmbClan);
            if (iznajmljivanje == null)
            {
                return;
            }

            var odg = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.ZapamtiNovoIznajmljivanje, iznajmljivanje);
            if (odg.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je zapamtio iznajmljivanje filma");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti novo iznajmljivanje filma");
            }
        }

        internal void IzmenaCombo(ComboBox cmbFIlm, ComboBox cmbPrimerak)
        {
            var film = cmbFIlm.SelectedItem as Film;
            cmbPrimerak.DataSource = film.Primerci.Where(primerak => primerak.Raspolozivost).ToList(); 
        }

        internal void Minus(DataGridView dataGridView1)
        {
            var primerak = dataGridView1.SelectedRows[0].DataBoundItem as IznajmljivanjePrimerak;
            Primerci.Remove(primerak);
            dataGridView1.DataSource = Primerci;
        }

        internal void Dodaj(ComboBox cmbPrimerak, DataGridView dataGridView1)
        {
            var primerak = KreirajPrimerak(cmbPrimerak);
            if (primerak == null)
            {
                return;
            }

            Primerci.Add(primerak);
            dataGridView1.DataSource = Primerci;
        }

        private IznajmljivanjePrimerak KreirajPrimerak(ComboBox cmbPrimerak)
        {
            var primerak = cmbPrimerak.SelectedItem as Primerak;

            if(Primerci.Any(p => p.Primerak.PrimerakId == primerak.PrimerakId))
            {
                MessageBox.Show("Vec ste uneli izabrani primerak!");
                return null;
            }

            return new IznajmljivanjePrimerak(null, primerak);
        }

        private Iznajmljivanje Kreiraj(TextBox txtRok, ComboBox cmbClan)
        {
            if (!int.TryParse(txtRok.Text, out var rok))
            {
                MessageBox.Show("Unesite rok za vracanje");
            }

            if (rok <= 0)
            {
                MessageBox.Show("Rok mora biti veci od 0 dana");
                return null;
            }
            var clan = cmbClan.SelectedItem as Clan;

            var iznajmljivanje = new Iznajmljivanje(0, DateTime.Now, DateTime.Now.AddDays(rok), clan)
            {
                Primerci = Primerci.ToList()
            };

            return iznajmljivanje;
        }

        internal void Load(ComboBox cmbClan, ComboBox cmbFIlm, ComboBox cmbPrimerak, DataGridView dataGridView1)
        {
            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.VratiListuClanova);

            if (odgovor.UspesnoIzvrsenaSO)
            {
                cmbClan.DataSource = odgovor.Object as List<Clan>;
            }

            odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.VratiListuFilmova);

            if (odgovor.UspesnoIzvrsenaSO)
            {
                var filmovi = odgovor.Object as List<Film>;
                cmbFIlm.DataSource = odgovor.Object as List<Film>;
                cmbPrimerak.DataSource = filmovi[0].Primerci.Where(primerak => primerak.Raspolozivost).ToList();
            }

            Primerci = new BindingList<IznajmljivanjePrimerak>();
            dataGridView1.DataSource = Primerci;
        }
    }
}
