using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBansos
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btntentangaplikasi_Click(object sender, EventArgs e)
        {
            this.Hide();
            tentangApk panggil = new tentangApk();
            panggil.Show();
        }

        private void btnInputanData_Click(object sender, EventArgs e)
        {
            this.Hide();
            inputData panggil = new inputData();
            panggil.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 panggil = new Form1();
            panggil.Show();
        }
    }
}
