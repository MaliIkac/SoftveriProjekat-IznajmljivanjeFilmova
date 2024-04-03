using System;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        public FrmServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ServerNit.Server.PokreniServer())
            {
                MessageBox.Show("Server je pokrenut. Cekaju se novi korisnici da se uloguju.");
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
                MessageBox.Show("Server ne moze da se pokrene. Korisnici ne mogu da se povezu.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ServerNit.Server.ZaustaviServer())
            {
                MessageBox.Show("Server je zaustavljen. Korisnici ne mogu da se povezu");
                button1.Enabled = true;
                button2.Enabled = false;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = true;
                MessageBox.Show("Server ne moze da se zaustavi. Korisnici i dalje mogu da koriste server");
            }
        }
    }
}
