using Domen.KonceptualneKlase;
using Klijent.KontroleriKorisnickogInterfejsa;
using System;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class UnosFilmaGui : Form
    {
        public UnosFilmaGui(Film film = null)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            UnosFilmaKontroler.Instanca.Load(cmbGlumac, cmbZanr, dataGridView1);
            UnosFilmaKontroler.Instanca.Prikaz(film, txtNaziv, txtBrojPrimeraka, txtGodina, dataGridView1, btnMinus, btnPlus, btnUnos);
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            UnosFilmaKontroler.Instanca.Unos(txtNaziv, txtBrojPrimeraka, txtGodina, cmbZanr);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            UnosFilmaKontroler.Instanca.Dodaj(cmbGlumac, dataGridView1);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            UnosFilmaKontroler.Instanca.Minus(dataGridView1);
        }
    }
}
