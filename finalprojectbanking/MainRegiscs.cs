using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalprojectbanking
{
    public partial class MainRegiscs : Form
    {
        public MainRegiscs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AdminRegisterForm().ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new UserRegis().ShowDialog();
            this.Hide();
        }

        private void MainRegiscs_Load(object sender, EventArgs e)
        {

        }
    }
}
