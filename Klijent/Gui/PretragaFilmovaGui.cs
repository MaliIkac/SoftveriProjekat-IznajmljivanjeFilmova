using Klijent.KontroleriKorisnickogInterfejsa;
using System;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class PretragaFilmovaGui : Form
    {
        public PretragaFilmovaGui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            PretragaFilmovaKontroler.Instanca.Load(dataGridView1, cmbZanr);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            PretragaFilmovaKontroler.Instanca.Pretrazi(dataGridView1, txtTekst, cmbZanr);
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            PretragaFilmovaKontroler.Instanca.Load(dataGridView1, cmbZanr);
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            PretragaFilmovaKontroler.Instanca.Prikazi(dataGridView1);
        }
    }
}
