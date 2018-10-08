using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Town_V3
{
    public partial class mob_hover_pocetna : Form
    {
        string user;
        public mob_hover_pocetna(string user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            unos_mob_hover umh = new unos_mob_hover();
            umh.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lista_hover_mob lhm = new Lista_hover_mob(user);
            this.Hide();
            lhm.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lista_racuni_mob_hover lrmh = new Lista_racuni_mob_hover();
            lrmh.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
