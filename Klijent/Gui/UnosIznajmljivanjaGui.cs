using Klijent.KontroleriKorisnickogInterfejsa;
using System;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class UnosIznajmljivanjaGui : Form
    {
        public UnosIznajmljivanjaGui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            UnosIznajmljivanjaKontroler.Instanca.Load(cmbClan, cmbFIlm, cmbPrimerak, dataGridView1);
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            UnosIznajmljivanjaKontroler.Instanca.Unos(txtRok, cmbClan);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            UnosIznajmljivanjaKontroler.Instanca.Dodaj(cmbPrimerak, dataGridView1);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            UnosIznajmljivanjaKontroler.Instanca.Minus(dataGridView1);
        }

        private void cmbFIlm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnosIznajmljivanjaKontroler.Instanca.IzmenaCombo(cmbFIlm, cmbPrimerak);
        }
    }
}
