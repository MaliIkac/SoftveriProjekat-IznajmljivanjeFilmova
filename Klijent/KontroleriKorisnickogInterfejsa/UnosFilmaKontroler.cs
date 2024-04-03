using Domen.KonceptualneKlase;
using Domen.KorisneKlase;
using Domen.KorisneKlase.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Klijent.KontroleriKorisnickogInterfejsa
{
    public class UnosFilmaKontroler
    {
        private static UnosFilmaKontroler instanca;
        BindingList<FilmGlumac> Glumci { get; set; }
        private UnosFilmaKontroler()
        {
        }

        public static UnosFilmaKontroler Instanca
        {
            get
            {
                if (instanca is null)
                {
                    instanca = new UnosFilmaKontroler();
                }

                return instanca;
            }
        }

        internal void Prikaz(Film film, TextBox txtNaziv, TextBox txtBrojPrimeraka, TextBox txtGodina, DataGridView dataGridView1, Button btnMinus, Button btnPlus, Button btnUnos)
        {
            if (film != null)
            {
                txtNaziv.Text = film.Naziv;
                txtBrojPrimeraka.Text = film.Primerci.Count.ToString();
                txtGodina.Text = film.GodinaIzdavanja.ToString();
                Glumci = new BindingList<FilmGlumac>(film.Glumci);
                dataGridView1.DataSource = Glumci;
                btnMinus.Visible = false;
                btnPlus.Visible = false;
                btnUnos.Visible = false;
            }
        }

      
        internal void Minus(DataGridView dataGridView1)
        {
            var filmGlumac = dataGridView1.SelectedRows[0].DataBoundItem as FilmGlumac;

            if (filmGlumac == null)
            {
                MessageBox.Show("Nije selektovan red");
                return;
            }

            Glumci.Remove(filmGlumac);
            dataGridView1.DataSource = Glumci;
        }

        internal void Dodaj(ComboBox cmbGlumac, DataGridView dataGridView1)
        {
            var filmGlumac = KreirajGlumcaZaFilm(cmbGlumac);

            if (filmGlumac == null)
            {
                return;
            }

            Glumci.Add(filmGlumac);
            dataGridView1.DataSource = Glumci;
        }

        private FilmGlumac KreirajGlumcaZaFilm(ComboBox cmbGlumac)
        {
            var glumac = cmbGlumac.SelectedItem as Glumac;

            if (Glumci.Any(g => g.Glumac.GlumacId == glumac.GlumacId))
            {
                MessageBox.Show($"Vec ste uneli {glumac.Ime} {glumac.Prezime} glumca za film");
                return null;
            }
            return new FilmGlumac(null, glumac);
        }

        internal void Unos(TextBox txtNaziv, TextBox txtBrojPrimeraka, TextBox txtGodina, ComboBox cmbZanr)
        {
            var film = Kreiraj(txtNaziv, txtBrojPrimeraka, txtGodina, cmbZanr);

            if (film == null)
            {
                return;
            }

            var odg = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.ZapamtiFilm, film);
            if (odg.UspesnoIzvrsenaSO)
            {
                MessageBox.Show("Sistem je uspesno zapamtio nov film");
            }
            else
            {
                MessageBox.Show("Sistem ne moze da zapamti novi film");
            }
        }

        private Film Kreiraj(TextBox txtNaziv, TextBox txtBrojPrimeraka, TextBox txtGodina, ComboBox cmbZanr)
        {
            var naziv = txtNaziv.Text;

            if (string.IsNullOrEmpty(naziv))
            {
                MessageBox.Show("Morate uneti naziv");
                return null;
            }

            if (!int.TryParse(txtGodina.Text, out var godina))
            {
                MessageBox.Show("Unesite broj za godinu");
            }

            if (godina <= 0)
            {
                MessageBox.Show("Godina mora biti veci od 0 dana");
                return null;
            }

            var zanr = cmbZanr.SelectedItem.ToString();

            var film = new Film(0, naziv, new DateTime(godina, 1,1), zanr);

            if (!int.TryParse(txtBrojPrimeraka.Text, out var brojPrimeraka))
            {
                MessageBox.Show("Unesite broj za broj primeraka");
            }

            if (brojPrimeraka <= 0)
            {
                MessageBox.Show("Broj primeraka mora biti veci od 0");
                return null;
            }

            film.Primerci = new List<Primerak>();
            for (var i = 0; i < brojPrimeraka; i++)
            {
                film.Primerci.Add(new Primerak(film, 0, true));
            }

            film.Glumci = Glumci.ToList();

            return film;
        }

        internal void Load(ComboBox cmbGlumac, ComboBox cmbZanr, DataGridView dataGridView1)
        {
            var odgovor = KomunikacijaServer.Instanca.TransferSync(SistemskaOperacija.VratiListuGlumaca);
            if (odgovor.UspesnoIzvrsenaSO)
            {
                cmbGlumac.DataSource = odgovor.Object as List<Glumac>;
            }

            cmbZanr.DataSource = Enum.GetNames(typeof(Zanrovi)).ToList<string>();
            Glumci = new BindingList<FilmGlumac>();
            dataGridView1.DataSource = Glumci;
        }
        
    }
}
