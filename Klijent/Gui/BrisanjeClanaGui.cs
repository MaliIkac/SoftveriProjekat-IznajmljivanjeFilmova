using Klijent.KontroleriKorisnickogInterfejsa;
using System;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class BrisanjeClanaGui : Form
    {
        public BrisanjeClanaGui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            BrisanjeClanaKontroler.Instanca.Load(dataGridView1);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            BrisanjeClanaKontroler.Instanca.Pretrazi(dataGridView1, txtTekst);
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            BrisanjeClanaKontroler.Instanca.Load(dataGridView1);
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            BrisanjeClanaKontroler.Instanca.Obrisi(dataGridView1);
        }
    }
}
