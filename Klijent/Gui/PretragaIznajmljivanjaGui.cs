using Klijent.KontroleriKorisnickogInterfejsa;
using System;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class PretragaIznajmljivanjaGui : Form
    {
        public PretragaIznajmljivanjaGui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            PretragaIznajmljivanjaKontroler.Instanca.Load(dataGridView1, cmbClan);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            PretragaIznajmljivanjaKontroler.Instanca.Pretrazi(dataGridView1, cmbClan, txtDatum);
            
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            PretragaIznajmljivanjaKontroler.Instanca.Load(dataGridView1, cmbClan);
        }

        private void btnRazduzi_Click(object sender, EventArgs e)
        {
            PretragaIznajmljivanjaKontroler.Instanca.Razduzi(dataGridView1, cmbClan);
        }
    }
}
