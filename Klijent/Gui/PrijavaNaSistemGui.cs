using Klijent.KontroleriKorisnickogInterfejsa;
using System;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class PrijavaNaSistemGui : Form
    {
        public PrijavaNaSistemGui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(PrijavaNaSistemKontroler.Instanca.Prijavi(txtKorisnickoIme, txtSifra)== true){
                GlavniMeniGui gm=new GlavniMeniGui();
                gm.Visible = true;
                this.Visible = false;
            }
            
        }
    }
}
