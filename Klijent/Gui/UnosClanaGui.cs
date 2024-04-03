using Klijent.KontroleriKorisnickogInterfejsa;
using System;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class UnosClanaGui : Form
    {
        public UnosClanaGui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UnosClanaKontroler.Instanca.Kreiraj(txtIme, txtPrezime, txtKontakt);
        }
    }
}
