using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klijent.Gui
{
    public partial class GlavniMeniGui : Form
    {
        public GlavniMeniGui()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UnosClanaGui gui = new UnosClanaGui();
            gui.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BrisanjeClanaGui gui = new BrisanjeClanaGui();
            gui.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UnosFilmaGui gui = new UnosFilmaGui();
            gui.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PretragaFilmovaGui gui = new PretragaFilmovaGui();
            gui.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            PretragaIznajmljivanjaGui gui = new PretragaIznajmljivanjaGui();
            gui.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UnosIznajmljivanjaGui gui = new UnosIznajmljivanjaGui();
            gui.ShowDialog();
        }

       
    }
}
